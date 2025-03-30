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
    
    public enum VerifyStaminaRecoverValueByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyStaminaRecoverValueByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStaminaRecoverValueByUserIdVerifyType self) {
            switch (self) {
                case VerifyStaminaRecoverValueByUserIdVerifyType.Less:
                    return "less";
                case VerifyStaminaRecoverValueByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyStaminaRecoverValueByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyStaminaRecoverValueByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyStaminaRecoverValueByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyStaminaRecoverValueByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyStaminaRecoverValueByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyStaminaRecoverValueByUserIdVerifyType.NotEqual;
            }
            return VerifyStaminaRecoverValueByUserIdVerifyType.Less;
        }
    }
}
