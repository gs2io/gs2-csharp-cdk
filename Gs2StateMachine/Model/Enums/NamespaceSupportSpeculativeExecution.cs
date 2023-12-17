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


namespace Gs2Cdk.Gs2StateMachine.Model.Enums
{
    
    public enum NamespaceSupportSpeculativeExecution {
        Enable,
        Disable
    }

    public static class NamespaceSupportSpeculativeExecutionExt
    {
        public static string Str(this NamespaceSupportSpeculativeExecution self) {
            switch (self) {
                case NamespaceSupportSpeculativeExecution.Enable:
                    return "enable";
                case NamespaceSupportSpeculativeExecution.Disable:
                    return "disable";
            }
            return "unknown";
        }

        public static NamespaceSupportSpeculativeExecution New(string value) {
            switch (value) {
                case "enable":
                    return NamespaceSupportSpeculativeExecution.Enable;
                case "disable":
                    return NamespaceSupportSpeculativeExecution.Disable;
            }
            return NamespaceSupportSpeculativeExecution.Enable;
        }
    }
}
