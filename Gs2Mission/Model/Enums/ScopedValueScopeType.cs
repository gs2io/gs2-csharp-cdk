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


namespace Gs2Cdk.Gs2Mission.Model.Enums
{
    
    public enum ScopedValueScopeType {
        ResetTiming,
        VerifyAction
    }

    public static class ScopedValueScopeTypeExt
    {
        public static string Str(this ScopedValueScopeType self) {
            switch (self) {
                case ScopedValueScopeType.ResetTiming:
                    return "resetTiming";
                case ScopedValueScopeType.VerifyAction:
                    return "verifyAction";
            }
            return "unknown";
        }

        public static ScopedValueScopeType New(string value) {
            switch (value) {
                case "resetTiming":
                    return ScopedValueScopeType.ResetTiming;
                case "verifyAction":
                    return ScopedValueScopeType.VerifyAction;
            }
            return ScopedValueScopeType.ResetTiming;
        }
    }
}
