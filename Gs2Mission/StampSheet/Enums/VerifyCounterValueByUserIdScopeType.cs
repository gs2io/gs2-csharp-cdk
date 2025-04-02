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


namespace Gs2Cdk.Gs2Mission.StampSheet.Enums
{
    
    public enum VerifyCounterValueByUserIdScopeType {
        ResetTiming,
        VerifyAction
    }

    public static class VerifyCounterValueByUserIdScopeTypeExt
    {
        public static string Str(this VerifyCounterValueByUserIdScopeType self) {
            switch (self) {
                case VerifyCounterValueByUserIdScopeType.ResetTiming:
                    return "resetTiming";
                case VerifyCounterValueByUserIdScopeType.VerifyAction:
                    return "verifyAction";
            }
            return "unknown";
        }

        public static VerifyCounterValueByUserIdScopeType New(string value) {
            switch (value) {
                case "resetTiming":
                    return VerifyCounterValueByUserIdScopeType.ResetTiming;
                case "verifyAction":
                    return VerifyCounterValueByUserIdScopeType.VerifyAction;
            }
            return VerifyCounterValueByUserIdScopeType.ResetTiming;
        }
    }
}
