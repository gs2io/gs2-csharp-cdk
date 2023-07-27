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
    public class StateMachine
    {
        public string Name;
        internal IVariable[] Variables;
        internal List<ITask> Tasks = new List<ITask>();
        internal string EntryPointValue;
        internal StateMachineDefinition StateMachineDefinition;

        public StateMachine(StateMachineDefinition stateMachineDefinition, string name, IVariable[] variables)
        {
            this.StateMachineDefinition = stateMachineDefinition;
            this.Name = name;
            this.Variables = variables;
            this.StateMachineDefinition.Add(this);
        }

        public StateMachine Task(params ITask[] args)
        {
            this.Tasks.AddRange(args);
            return this;
        }

        public StateMachine EntryPoint(string taskName)
        {
            this.EntryPointValue = taskName;
            return this;
        }

        public List<Script> Scripts()
        {
            var scripts = new List<Script>();
            foreach (var task in this.Tasks.OfType<Task>())
            {
                var script = task.ScriptPayload();
                script.Name = $"{this.Name}_{script.Name}";
                scripts.Add(script);
            }
            return scripts;
        }

        public string Gsl()
        {
            var output = new List<string> {$"StateMachine {this.Name} {"{"}"};

            if (this.Variables?.Length > 0)
            {
                var variablesPart = new List<string> {"Variables {"};
                variablesPart.AddRange(this.Variables.Select(variable => $"{variable.Gsl()};".Indent(2)));
                variablesPart.Add("}");
                output.Add(string.Join(Environment.NewLine, variablesPart));
            }

            if (!string.IsNullOrEmpty(this.EntryPointValue))
            {
                output.Add($"EntryPoint {this.EntryPointValue};".Indent(2));
            }

            output.AddRange(this.Tasks.Select(task => task.Gsl().Indent(2)));
            output.AddRange(this.Tasks.SelectMany(task => task.GetEvents().Select(@event => @event.Gsl().Indent(2))));
            output.Add("}");

            return string.Join(Environment.NewLine, output).Replace("{stateMachineName}", this.Name);
        }

        public string Mermaid()
        {
            var output = new List<string> {$"subgraph {this.Name}"};
            output.AddRange(this.Tasks.Select(task => task.Mermaid().Indent(2)));

            foreach (var task in this.Tasks.OfType<SubStateMachineTask>())
            {
                output.Add($"{task.Name} --> {task.SubStateMachineName}_{{task.SubStateMachineName}}_entryPoint");
                output.Add($"{task.SubStateMachineName}_Pass -->|Pass| {{stateMachineName}}_{task.GetEvents()[0].NextTaskName}");
            }

            foreach (var task in this.Tasks.OfType<WaitTask>())
            {
                output.Add($"Player ----->|Interaction| {{stateMachineName}}_{task.GetName()}");
            }

            return string.Join(Environment.NewLine, output).Replace("{stateMachineName}", this.Name);
        }
    }
}
