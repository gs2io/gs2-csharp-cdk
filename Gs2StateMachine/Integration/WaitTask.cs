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
using Gs2Cdk.Gs2StateMachine.Integration;

namespace Gs2Cdk.Gs2StateMachine.Integration
{
    public class WaitTask : ITask
    {
        public readonly string Name;
        internal readonly List<Result> Results = new List<Result>();
        internal readonly List<Event> Events = new List<Event>();

        public WaitTask(string name)
        {
            this.Name = name;
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

        public WaitTask Result(string resultName, Dictionary<IVariable, string> emitEventArgumentVariableNames, string nextTaskName)
        {
            this.Results.Add(
                new Result(
                    resultName,
                    resultName,
                    emitEventArgumentVariableNames
                )
            );
            var eventArguments = emitEventArgumentVariableNames.Keys.ToArray();
            this.Transition(new Event(resultName, eventArguments, nextTaskName));
            return this;
        }

        public string Gsl()
        {
            var output = new List<string> {$"WaitTask {this.Name} {"{"}"};
            foreach (var @event in this.Events)
            {
                var argumentsPart = string.Join(", ", @event.Arguments.Select(arg => arg.Gsl()));
                output.Add($"Event {@event.Name}({argumentsPart});".Indent(2));
            }
            output.Add("}".Indent(2));
            output.Add("");
            return string.Join(Environment.NewLine, output);
        }

        public string Mermaid()
        {
            var output = new List<string>();
            foreach (var @event in this.Events)
            {
                if (@event.NextTaskName != "Error")
                {
                    output.Add($"{{stateMachineName}}_{@event.FromTaskName}([{{{@event.FromTaskName}}}]) -->|{@event.Name}| {{stateMachineName}}_{@event.NextTaskName}");
                }
            }
            return string.Join(Environment.NewLine, output);
        }
    }
}
