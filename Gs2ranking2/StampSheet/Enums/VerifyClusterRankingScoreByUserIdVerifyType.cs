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
    
    public enum VerifyClusterRankingScoreByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyClusterRankingScoreByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyClusterRankingScoreByUserIdVerifyType self) {
            switch (self) {
                case VerifyClusterRankingScoreByUserIdVerifyType.Less:
                    return "less";
                case VerifyClusterRankingScoreByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyClusterRankingScoreByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyClusterRankingScoreByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyClusterRankingScoreByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyClusterRankingScoreByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyClusterRankingScoreByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyClusterRankingScoreByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyClusterRankingScoreByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyClusterRankingScoreByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyClusterRankingScoreByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyClusterRankingScoreByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyClusterRankingScoreByUserIdVerifyType.NotEqual;
            }
            return VerifyClusterRankingScoreByUserIdVerifyType.Less;
        }
    }
}
