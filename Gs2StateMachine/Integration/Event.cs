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
    public class Event : IGslElement
    {
        internal string Name;
        internal IVariable[] Arguments;
        internal string FromTaskName;
        internal string NextTaskName;

        public Event(string name, IVariable[] arguments, string nextTaskName)
        {
            this.Name = name;
            this.Arguments = arguments;
            this.NextTaskName = nextTaskName;
        }

        public string Gsl()
        {
            return $"Transition {this.FromTaskName} handling {this.Name} -> {this.NextTaskName};\n";
        }
    }
}
