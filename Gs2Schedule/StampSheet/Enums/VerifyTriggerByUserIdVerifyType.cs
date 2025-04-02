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


namespace Gs2Cdk.Gs2Schedule.StampSheet.Enums
{
    
    public enum VerifyTriggerByUserIdVerifyType {
        NotTriggerd,
        Elapsed,
        NotElapsed
    }

    public static class VerifyTriggerByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyTriggerByUserIdVerifyType self) {
            switch (self) {
                case VerifyTriggerByUserIdVerifyType.NotTriggerd:
                    return "notTriggerd";
                case VerifyTriggerByUserIdVerifyType.Elapsed:
                    return "elapsed";
                case VerifyTriggerByUserIdVerifyType.NotElapsed:
                    return "notElapsed";
            }
            return "unknown";
        }

        public static VerifyTriggerByUserIdVerifyType New(string value) {
            switch (value) {
                case "notTriggerd":
                    return VerifyTriggerByUserIdVerifyType.NotTriggerd;
                case "elapsed":
                    return VerifyTriggerByUserIdVerifyType.Elapsed;
                case "notElapsed":
                    return VerifyTriggerByUserIdVerifyType.NotElapsed;
            }
            return VerifyTriggerByUserIdVerifyType.NotTriggerd;
        }
    }
}
