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
    
    public enum VerifyInventoryCurrentMaxCapacityByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyInventoryCurrentMaxCapacityByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyInventoryCurrentMaxCapacityByUserIdVerifyType self) {
            switch (self) {
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Less:
                    return "less";
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyInventoryCurrentMaxCapacityByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.NotEqual;
            }
            return VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Less;
        }
    }
}
