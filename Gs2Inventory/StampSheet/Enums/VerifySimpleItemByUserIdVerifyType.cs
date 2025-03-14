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
    
    public enum VerifySimpleItemByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifySimpleItemByUserIdVerifyTypeExt
    {
        public static string Str(this VerifySimpleItemByUserIdVerifyType self) {
            switch (self) {
                case VerifySimpleItemByUserIdVerifyType.Less:
                    return "less";
                case VerifySimpleItemByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifySimpleItemByUserIdVerifyType.Greater:
                    return "greater";
                case VerifySimpleItemByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifySimpleItemByUserIdVerifyType.Equal:
                    return "equal";
                case VerifySimpleItemByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifySimpleItemByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifySimpleItemByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifySimpleItemByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifySimpleItemByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifySimpleItemByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifySimpleItemByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifySimpleItemByUserIdVerifyType.NotEqual;
            }
            return VerifySimpleItemByUserIdVerifyType.Less;
        }
    }
}
