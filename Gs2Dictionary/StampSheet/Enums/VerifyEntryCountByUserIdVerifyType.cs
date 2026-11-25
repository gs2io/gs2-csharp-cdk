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


namespace Gs2Cdk.Gs2Dictionary.StampSheet.Enums
{
    
    public enum VerifyEntryCountByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyEntryCountByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyEntryCountByUserIdVerifyType self) {
            switch (self) {
                case VerifyEntryCountByUserIdVerifyType.Less:
                    return "less";
                case VerifyEntryCountByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyEntryCountByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyEntryCountByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyEntryCountByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyEntryCountByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyEntryCountByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyEntryCountByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyEntryCountByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyEntryCountByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyEntryCountByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyEntryCountByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyEntryCountByUserIdVerifyType.NotEqual;
            }
            return VerifyEntryCountByUserIdVerifyType.Less;
        }
    }
}
