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
    
    public enum VerifyStaminaMaxValueByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyStaminaMaxValueByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStaminaMaxValueByUserIdVerifyType self) {
            switch (self) {
                case VerifyStaminaMaxValueByUserIdVerifyType.Less:
                    return "less";
                case VerifyStaminaMaxValueByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyStaminaMaxValueByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyStaminaMaxValueByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyStaminaMaxValueByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyStaminaMaxValueByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyStaminaMaxValueByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyStaminaMaxValueByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyStaminaMaxValueByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyStaminaMaxValueByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyStaminaMaxValueByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyStaminaMaxValueByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyStaminaMaxValueByUserIdVerifyType.NotEqual;
            }
            return VerifyStaminaMaxValueByUserIdVerifyType.Less;
        }
    }
}
