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
    
    public enum SimpleItemVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class SimpleItemVerifyTypeExt
    {
        public static string Str(this SimpleItemVerifyType self) {
            switch (self) {
                case SimpleItemVerifyType.Less:
                    return "less";
                case SimpleItemVerifyType.LessEqual:
                    return "lessEqual";
                case SimpleItemVerifyType.Greater:
                    return "greater";
                case SimpleItemVerifyType.GreaterEqual:
                    return "greaterEqual";
                case SimpleItemVerifyType.Equal:
                    return "equal";
                case SimpleItemVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static SimpleItemVerifyType New(string value) {
            switch (value) {
                case "less":
                    return SimpleItemVerifyType.Less;
                case "lessEqual":
                    return SimpleItemVerifyType.LessEqual;
                case "greater":
                    return SimpleItemVerifyType.Greater;
                case "greaterEqual":
                    return SimpleItemVerifyType.GreaterEqual;
                case "equal":
                    return SimpleItemVerifyType.Equal;
                case "notEqual":
                    return SimpleItemVerifyType.NotEqual;
            }
            return SimpleItemVerifyType.Less;
        }
    }
}
