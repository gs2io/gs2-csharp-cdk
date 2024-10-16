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


namespace Gs2Cdk.Gs2Ranking2.StampSheet.Enums
{
    
    public enum VerifyGlobalRankingScoreByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyGlobalRankingScoreByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyGlobalRankingScoreByUserIdVerifyType self) {
            switch (self) {
                case VerifyGlobalRankingScoreByUserIdVerifyType.Less:
                    return "less";
                case VerifyGlobalRankingScoreByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyGlobalRankingScoreByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyGlobalRankingScoreByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyGlobalRankingScoreByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyGlobalRankingScoreByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyGlobalRankingScoreByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyGlobalRankingScoreByUserIdVerifyType.NotEqual;
            }
            return VerifyGlobalRankingScoreByUserIdVerifyType.Less;
        }
    }
}
