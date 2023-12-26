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
    
    public enum VerifyItemSetByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyItemSetByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyItemSetByUserIdVerifyType self) {
            switch (self) {
                case VerifyItemSetByUserIdVerifyType.Less:
                    return "less";
                case VerifyItemSetByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyItemSetByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyItemSetByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyItemSetByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyItemSetByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyItemSetByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyItemSetByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyItemSetByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyItemSetByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyItemSetByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyItemSetByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyItemSetByUserIdVerifyType.NotEqual;
            }
            return VerifyItemSetByUserIdVerifyType.Less;
        }
    }
}
