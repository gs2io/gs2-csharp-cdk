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


namespace Gs2Cdk.Gs2Experience.StampSheet.Enums
{
    
    public enum VerifyRankCapByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyRankCapByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyRankCapByUserIdVerifyType self) {
            switch (self) {
                case VerifyRankCapByUserIdVerifyType.Less:
                    return "less";
                case VerifyRankCapByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyRankCapByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyRankCapByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyRankCapByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyRankCapByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyRankCapByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyRankCapByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyRankCapByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyRankCapByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyRankCapByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyRankCapByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyRankCapByUserIdVerifyType.NotEqual;
            }
            return VerifyRankCapByUserIdVerifyType.Less;
        }
    }
}
