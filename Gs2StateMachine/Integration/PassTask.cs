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

namespace Gs2Cdk.Gs2StateMachine.Integration
{
    public class PassTask : ITask
    {
        public string Name;

        public PassTask(string name)
        {
            this.Name = name;
        }

        public string GetName() => this.Name;

        public ITask Transition(Event @event)
        {
            return this;
        }

        public Event[] GetEvents() => new Event[0];

        public string Gsl()
        {
            return "PassTask Pass;\n\n";
        }

        public string Mermaid()
        {
            return string.Format("{0}_{1}[{1}/]\n", "stateMachineName", this.Name);
        }
    }
}
