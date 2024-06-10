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

namespace Gs2Cdk.Gs2Ranking2.StampSheet
{
    public class CreateClusterRankingReceivedRewardByUserId : ConsumeAction {
        private string namespaceName;
        private string rankingName;
        private string clusterName;
        private string userId;
        private long? season;
        private string? seasonString;
        private string timeOffsetToken;


        public CreateClusterRankingReceivedRewardByUserId(
            string namespaceName,
            string rankingName,
            string clusterName,
            long? season = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rankingName = rankingName;
            this.clusterName = clusterName;
            this.season = season;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public CreateClusterRankingReceivedRewardByUserId(
            string namespaceName,
            string rankingName,
            string clusterName,
            string season = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rankingName = rankingName;
            this.clusterName = clusterName;
            this.seasonString = season;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.rankingName != null) {
                properties["rankingName"] = this.rankingName;
            }
            if (this.clusterName != null) {
                properties["clusterName"] = this.clusterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.seasonString != null) {
                properties["season"] = this.seasonString;
            } else {
                if (this.season != null) {
                    properties["season"] = this.season;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static CreateClusterRankingReceivedRewardByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new CreateClusterRankingReceivedRewardByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["rankingName"],
                    (string)properties["clusterName"],
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
                return new CreateClusterRankingReceivedRewardByUserId(
                    properties["namespaceName"].ToString(),
                    properties["rankingName"].ToString(),
                    properties["clusterName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("season", out var season) ? season.ToString() : null;
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
            return "Gs2Ranking2:CreateClusterRankingReceivedRewardByUserId";
        }

        public static string StaticAction() {
            return "Gs2Ranking2:CreateClusterRankingReceivedRewardByUserId";
        }
    }
}
