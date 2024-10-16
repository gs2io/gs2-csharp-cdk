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
    
    public enum VerifySubscribeRankingScoreByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifySubscribeRankingScoreByUserIdVerifyTypeExt
    {
        public static string Str(this VerifySubscribeRankingScoreByUserIdVerifyType self) {
            switch (self) {
                case VerifySubscribeRankingScoreByUserIdVerifyType.Less:
                    return "less";
                case VerifySubscribeRankingScoreByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifySubscribeRankingScoreByUserIdVerifyType.Greater:
                    return "greater";
                case VerifySubscribeRankingScoreByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifySubscribeRankingScoreByUserIdVerifyType.Equal:
                    return "equal";
                case VerifySubscribeRankingScoreByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifySubscribeRankingScoreByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifySubscribeRankingScoreByUserIdVerifyType.NotEqual;
            }
            return VerifySubscribeRankingScoreByUserIdVerifyType.Less;
        }
    }
}
