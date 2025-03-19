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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Ranking2.Model;
using Gs2Cdk.Gs2Ranking2.StampSheet.Enums;

namespace Gs2Cdk.Gs2Ranking2.StampSheet
{
    public class VerifyClusterRankingScoreByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string rankingName;
        private string clusterName;
        private VerifyClusterRankingScoreByUserIdVerifyType? verifyType;
        private long score;
        private string scoreString;
        private long? season;
        private string seasonString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyClusterRankingScoreByUserId(
            string namespaceName,
            string rankingName,
            string clusterName,
            VerifyClusterRankingScoreByUserIdVerifyType verifyType,
            long score,
            long? season = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rankingName = rankingName;
            this.clusterName = clusterName;
            this.verifyType = verifyType;
            this.score = score;
            this.season = season;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyClusterRankingScoreByUserId(
            string namespaceName,
            string rankingName,
            string clusterName,
            VerifyClusterRankingScoreByUserIdVerifyType verifyType,
            string score,
            string season = null,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rankingName = rankingName;
            this.clusterName = clusterName;
            this.verifyType = verifyType;
            this.scoreString = score;
            this.seasonString = season;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.rankingName != null) {
                properties["rankingName"] = this.rankingName;
            }
            if (this.clusterName != null) {
                properties["clusterName"] = this.clusterName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.seasonString != null) {
                properties["season"] = this.seasonString;
            } else {
                if (this.season != null) {
                    properties["season"] = this.season;
                }
            }
            if (this.scoreString != null) {
                properties["score"] = this.scoreString;
            } else {
                if (this.score != null) {
                    properties["score"] = this.score;
                }
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyClusterRankingScoreByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyClusterRankingScoreByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["rankingName"],
                    (string)properties["clusterName"],
                    new Func<VerifyClusterRankingScoreByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyClusterRankingScoreByUserIdVerifyType e => e,
                            string s => VerifyClusterRankingScoreByUserIdVerifyTypeExt.New(s),
                            _ => VerifyClusterRankingScoreByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<long>(() =>
                    {
                        return properties["score"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("season", out var season) ? season switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyClusterRankingScoreByUserId(
                    properties["namespaceName"].ToString(),
                    properties["rankingName"].ToString(),
                    properties["clusterName"].ToString(),
                    new Func<VerifyClusterRankingScoreByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyClusterRankingScoreByUserIdVerifyType e => e,
                            string s => VerifyClusterRankingScoreByUserIdVerifyTypeExt.New(s),
                            _ => VerifyClusterRankingScoreByUserIdVerifyType.Less
                        };
                    })(),
                    properties["score"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("season", out var season) ? season.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Ranking2:VerifyClusterRankingScoreByUserId";
        }

        public static string StaticAction() {
            return "Gs2Ranking2:VerifyClusterRankingScoreByUserId";
        }
    }
}
