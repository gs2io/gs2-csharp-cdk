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
    
    public enum ItemSetVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class ItemSetVerifyTypeExt
    {
        public static string Str(this ItemSetVerifyType self) {
            switch (self) {
                case ItemSetVerifyType.Less:
                    return "less";
                case ItemSetVerifyType.LessEqual:
                    return "lessEqual";
                case ItemSetVerifyType.Greater:
                    return "greater";
                case ItemSetVerifyType.GreaterEqual:
                    return "greaterEqual";
                case ItemSetVerifyType.Equal:
                    return "equal";
                case ItemSetVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static ItemSetVerifyType New(string value) {
            switch (value) {
                case "less":
                    return ItemSetVerifyType.Less;
                case "lessEqual":
                    return ItemSetVerifyType.LessEqual;
                case "greater":
                    return ItemSetVerifyType.Greater;
                case "greaterEqual":
                    return ItemSetVerifyType.GreaterEqual;
                case "equal":
                    return ItemSetVerifyType.Equal;
                case "notEqual":
                    return ItemSetVerifyType.NotEqual;
            }
            return ItemSetVerifyType.Less;
        }
    }
}
