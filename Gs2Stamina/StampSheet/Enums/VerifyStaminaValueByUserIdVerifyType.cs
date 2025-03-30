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
    
    public enum VerifyStaminaValueByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyStaminaValueByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStaminaValueByUserIdVerifyType self) {
            switch (self) {
                case VerifyStaminaValueByUserIdVerifyType.Less:
                    return "less";
                case VerifyStaminaValueByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyStaminaValueByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyStaminaValueByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyStaminaValueByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyStaminaValueByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyStaminaValueByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyStaminaValueByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyStaminaValueByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyStaminaValueByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyStaminaValueByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyStaminaValueByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyStaminaValueByUserIdVerifyType.NotEqual;
            }
            return VerifyStaminaValueByUserIdVerifyType.Less;
        }
    }
}
