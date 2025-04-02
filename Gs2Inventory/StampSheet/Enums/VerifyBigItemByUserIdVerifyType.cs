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


namespace Gs2Cdk.Gs2Inventory.StampSheet.Enums
{
    
    public enum VerifyBigItemByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyBigItemByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyBigItemByUserIdVerifyType self) {
            switch (self) {
                case VerifyBigItemByUserIdVerifyType.Less:
                    return "less";
                case VerifyBigItemByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyBigItemByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyBigItemByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyBigItemByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyBigItemByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyBigItemByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyBigItemByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyBigItemByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyBigItemByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyBigItemByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyBigItemByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyBigItemByUserIdVerifyType.NotEqual;
            }
            return VerifyBigItemByUserIdVerifyType.Less;
        }
    }
}
