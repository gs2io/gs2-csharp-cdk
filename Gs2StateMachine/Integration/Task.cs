/*
 * Copyright 2016- Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gs2Cdk.Gs2StateMachine.Integration
{
    public class Task : ITask
    {
        public string Name;
        internal IVariable[] Arguments;
        internal string Script;

        internal List<Event> Events;
        internal List<Result> Results;

        public Task(string name, IVariable[] arguments, string script)
        {
            this.Name = name;
            this.Arguments = arguments;
            this.Script = script;

            this.Events = new List<Event>();
            this.Results = new List<Result>();
        }

        public string GetName()
        {
            return this.Name;
        }

        public ITask Transition(Event @event)
        {
            @event.FromTaskName = this.Name;
            this.Events.Add(@event);
            return this;
        }

        public Event[] GetEvents()
        {
            return this.Events.ToArray();
        }

        public Task Result(string name, Dictionary<IVariable, string> emitEventArgumentVariableNames, string nextTaskName)
        {
            this.Results.Add(new Result(
                name,
                name,
                emitEventArgumentVariableNames
            ));
            Transition(new Event(
                name,
                emitEventArgumentVariableNames.Keys.ToArray(),
                nextTaskName
            ));
            return this;
        }

        public Script ScriptPayload()
        {
            var output = this.Script;
            output += "\n\n";
            foreach (var result in this.Results)
            {
                output += string.Format("if result == '{0}' then\n", result.Name);
                output += string.Format(@"
result = {{
event='{0}',
params={{{1}}},
updatedVariables=args.variables
                ", result.EmitEventName, string.Join(", ", result.EmitEventArgumentVariableNames.Select(v => $"{v.Key.GetName()}={v.Value}").ToArray())).Indent(2);
                output += "end\n";
            }
            return new Script(
                this.Name,
                output
            );
        }

        public string Gsl()
        {
            var output = string.Format("Task {0}({1}) {{\n", this.Name, string.Join(", ", this.Arguments.Select(arg => arg.Gsl()).ToArray()));
            foreach (var @event in this.Events)
            {
                output += string.Format("Event {0}({1});\n", @event.Name, string.Join(", ", @event.Arguments.Select(arg => arg.Gsl()).ToArray())).Indent(2);
            }
            output += string.Format("Script grn:gs2:{0}:{1}:script:{2}:script:{3}_{4}", "region", "ownerId", "scriptNamespaceName", "stateMachineName", this.Name).Indent(2);
            output += "}\n\n";
            return output;
        }

        public string Mermaid()
        {
            var output = "";
            foreach (var @event in this.Events)
            {
                if (@event.NextTaskName == "Error") continue;
                output += string.Format("{0}_{1}[[{1}]] -->|{2}| {0}_{3}\n", "stateMachineName", @event.FromTaskName, @event.Name, @event.NextTaskName);
            }
            return output;
        }
    }
}
