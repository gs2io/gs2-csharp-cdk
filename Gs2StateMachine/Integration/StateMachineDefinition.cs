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
using System.Text;
using Gs2Cdk.Core.Model;

namespace Gs2Cdk.Gs2StateMachine.Integration
{
    public class StateMachineDefinition
    {
        public string StateMachineName = "";
        private readonly List<StateMachine> _stateMachines = new List<StateMachine>();

        public void Add(StateMachine stateMachine)
        {
            _stateMachines.Add(stateMachine);
        }

        public void EntryPointStateMachineName(string stateMachineName)
        {
            StateMachineName = stateMachineName;
        }

        public StateMachine StateMachine(string name, IVariable[] variables)
        {
            return new StateMachine(this, name, variables);
        }

        public Task ScriptTask(string name, IVariable[] arguments, string script)
        {
            return new Task(name, arguments, script);
        }

        public SubStateMachineTask SubStateMachineTask(
            string name, string subStateMachineName,
            InParam[] inParams, OutParam[] outParams, string nextTaskName)
        {
            var task = new SubStateMachineTask(name, subStateMachineName, inParams, outParams);
            task.Transition(new Event("Pass",
                outParams.Select(v => v.SubStateMachineVariable).ToArray(),
                nextTaskName));
            return task;
        }

        public InParam InParam(IVariable currentStateMachineVariable, IVariable subStateMachineVariable)
        {
            return new InParam(currentStateMachineVariable, subStateMachineVariable);
        }

        public OutParam OutParam(IVariable subStateMachineVariable, IVariable currentStateMachineVariable)
        {
            return new OutParam(subStateMachineVariable, currentStateMachineVariable);
        }

        public WaitTask WaitTask(string name)
        {
            return new WaitTask(name);
        }

        public PassTask PassTask(string name)
        {
            return new PassTask(name);
        }

        public ErrorTask ErrorTask(string name)
        {
            return new ErrorTask(name);
        }

        public IntType IntType(string name)
        {
            return new IntType(name);
        }

        public FloatType FloatType(string name)
        {
            return new FloatType(name);
        }

        public BoolType BoolType(string name)
        {
            return new BoolType(name);
        }

        public StringType StringType(string name)
        {
            return new StringType(name);
        }

        public ArrayType ArrayType(string name)
        {
            return new ArrayType(name);
        }

        public MapType MapType(string name)
        {
            return new MapType(name);
        }

        public Gs2Cdk.Gs2Script.Model.Script[] AppendScripts(Stack stack, Gs2Cdk.Gs2Script.Model.Namespace scriptNamespace)
        {
            var scripts = new List<Gs2Cdk.Gs2Script.Model.Script>();
            foreach (var stateMachine in _stateMachines)
            {
                foreach (var script in stateMachine.Scripts())
                {
                    var deployScript = new Gs2Cdk.Gs2Script.Model.Script(stack, scriptNamespace.GetName(), script.Name, script.Payload.Trim());
                    deployScript.AddDependsOn(scriptNamespace);
                    scripts.Add(deployScript);
                }
            }

            return scripts.ToArray();
        }

        public string Gsl()
        {
            return string.Join(Environment.NewLine, _stateMachines.Select(machine => machine.Gsl()));
        }

        public string Mermaid()
        {
            var output = new StringBuilder("flowchart TD\n");

            output.Append($"Start ----> {_stateMachines[0].Name}_{{{_stateMachines[0].EntryPointValue}}}".Indent(2)).AppendLine();
            output.Append($"{_stateMachines[0].Name}_Pass ----> Exit".Indent(2)).AppendLine();

            foreach (var stateMachine in _stateMachines)
            {
                output.Append(stateMachine.Mermaid().Indent(2)).AppendLine();
            }

            foreach (var stateMachine in _stateMachines)
            {
                output.Replace($"{{{stateMachine.Name}_entryPoint}}", stateMachine.EntryPointValue);
            }

            return output.ToString();
        }
    }
}
