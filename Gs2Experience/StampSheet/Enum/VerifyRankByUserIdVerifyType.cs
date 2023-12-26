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
    
    public enum VerifyRankByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyRankByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyRankByUserIdVerifyType self) {
            switch (self) {
                case VerifyRankByUserIdVerifyType.Less:
                    return "less";
                case VerifyRankByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyRankByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyRankByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyRankByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyRankByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyRankByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyRankByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyRankByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyRankByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyRankByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyRankByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyRankByUserIdVerifyType.NotEqual;
            }
            return VerifyRankByUserIdVerifyType.Less;
        }
    }
}
