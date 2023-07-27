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
    public class SubStateMachineTask : ITask
    {
        internal readonly string Name;
        internal readonly string SubStateMachineName;
        internal readonly InParam[] InParams;
        internal readonly OutParam[] OutParams;
        internal readonly List<Event> Events = new List<Event>();

        public SubStateMachineTask(string name, string subStateMachineName, InParam[] inParams, OutParam[] outParams)
        {
            this.Name = name;
            this.SubStateMachineName = subStateMachineName;
            this.InParams = inParams;
            this.OutParams = outParams;
        }

        public string GetName() => this.Name;

        public ITask Transition(Event @event)
        {
            @event.FromTaskName = this.Name;
            this.Events.Add(@event);
            return this;
        }

        public Event[] GetEvents() => this.Events.ToArray();

        public string Gsl()
        {
            var output = new List<string> {$"SubStateMachineTask {this.Name} {"{"}"};
            output.Add($"using {this.Name};".Indent(2));

            var inParamPart = string.Join(", ", this.InParams.Select(param => $"{param.SubStateMachineVariable.GetName()} <- {param.CurrentStateMachineVariable.GetName()}"));
            output.Add($"in ({inParamPart});".Indent(2));

            var outParamPart = string.Join(", ", this.OutParams.Select(param => $"{param.SubStateMachineVariable.GetName()} -> {param.CurrentStateMachineVariable.GetName()}"));
            output.Add($"out ({outParamPart});".Indent(2));

            output.Add("}");

            return string.Join(Environment.NewLine, output);
        }

        public string Mermaid()
        {
            return $"{this.Name}_{{name}}[/{{name}}/]".Replace("{{name}}", this.Name);
        }
    }
}
