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
    
    public enum BigItemVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class BigItemVerifyTypeExt
    {
        public static string Str(this BigItemVerifyType self) {
            switch (self) {
                case BigItemVerifyType.Less:
                    return "less";
                case BigItemVerifyType.LessEqual:
                    return "lessEqual";
                case BigItemVerifyType.Greater:
                    return "greater";
                case BigItemVerifyType.GreaterEqual:
                    return "greaterEqual";
                case BigItemVerifyType.Equal:
                    return "equal";
                case BigItemVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static BigItemVerifyType New(string value) {
            switch (value) {
                case "less":
                    return BigItemVerifyType.Less;
                case "lessEqual":
                    return BigItemVerifyType.LessEqual;
                case "greater":
                    return BigItemVerifyType.Greater;
                case "greaterEqual":
                    return BigItemVerifyType.GreaterEqual;
                case "equal":
                    return BigItemVerifyType.Equal;
                case "notEqual":
                    return BigItemVerifyType.NotEqual;
            }
            return BigItemVerifyType.Less;
        }
    }
}
