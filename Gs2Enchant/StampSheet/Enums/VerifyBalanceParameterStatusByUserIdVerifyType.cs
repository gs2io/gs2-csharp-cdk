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


namespace Gs2Cdk.Gs2Enchant.StampSheet.Enums
{
    
    public enum VerifyBalanceParameterStatusByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyBalanceParameterStatusByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyBalanceParameterStatusByUserIdVerifyType self) {
            switch (self) {
                case VerifyBalanceParameterStatusByUserIdVerifyType.Less:
                    return "less";
                case VerifyBalanceParameterStatusByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyBalanceParameterStatusByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyBalanceParameterStatusByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyBalanceParameterStatusByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyBalanceParameterStatusByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyBalanceParameterStatusByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyBalanceParameterStatusByUserIdVerifyType.NotEqual;
            }
            return VerifyBalanceParameterStatusByUserIdVerifyType.Less;
        }
    }
}
