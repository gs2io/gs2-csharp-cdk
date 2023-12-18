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


namespace Gs2Cdk.Gs2Inventory.Model.Enums
{
    
    public enum InventoryVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class InventoryVerifyTypeExt
    {
        public static string Str(this InventoryVerifyType self) {
            switch (self) {
                case InventoryVerifyType.Less:
                    return "less";
                case InventoryVerifyType.LessEqual:
                    return "lessEqual";
                case InventoryVerifyType.Greater:
                    return "greater";
                case InventoryVerifyType.GreaterEqual:
                    return "greaterEqual";
                case InventoryVerifyType.Equal:
                    return "equal";
                case InventoryVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static InventoryVerifyType New(string value) {
            switch (value) {
                case "less":
                    return InventoryVerifyType.Less;
                case "lessEqual":
                    return InventoryVerifyType.LessEqual;
                case "greater":
                    return InventoryVerifyType.Greater;
                case "greaterEqual":
                    return InventoryVerifyType.GreaterEqual;
                case "equal":
                    return InventoryVerifyType.Equal;
                case "notEqual":
                    return InventoryVerifyType.NotEqual;
            }
            return InventoryVerifyType.Less;
        }
    }
}
