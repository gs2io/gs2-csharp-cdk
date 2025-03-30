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
    
    public enum VerifyStaminaOverflowValueByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyStaminaOverflowValueByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStaminaOverflowValueByUserIdVerifyType self) {
            switch (self) {
                case VerifyStaminaOverflowValueByUserIdVerifyType.Less:
                    return "less";
                case VerifyStaminaOverflowValueByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyStaminaOverflowValueByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyStaminaOverflowValueByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyStaminaOverflowValueByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyStaminaOverflowValueByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyStaminaOverflowValueByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyStaminaOverflowValueByUserIdVerifyType.NotEqual;
            }
            return VerifyStaminaOverflowValueByUserIdVerifyType.Less;
        }
    }
}
