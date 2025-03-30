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


namespace Gs2Cdk.Gs2Stamina.StampSheet.Enums
{
    
    public enum VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyStaminaRecoverIntervalMinutesByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType self) {
            switch (self) {
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Less:
                    return "less";
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.NotEqual;
            }
            return VerifyStaminaRecoverIntervalMinutesByUserIdVerifyType.Less;
        }
    }
}
