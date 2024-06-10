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
using Gs2Cdk.Gs2Ranking2.Model.Enums;
using Gs2Cdk.Gs2Ranking2.Model.Options;

namespace Gs2Cdk.Gs2Ranking2.Model
{
    public class ClusterRankingModel {
        private string name;
        private ClusterRankingModelClusterType? clusterType;
        private bool? sum;
        private ClusterRankingModelOrderDirection? orderDirection;
        private string metadata;
        private long? minimumValue;
        private long? maximumValue;
        private string entryPeriodEventId;
        private RankingReward[] rankingRewards;
        private string accessPeriodEventId;

        public ClusterRankingModel(
            string name,
            ClusterRankingModelClusterType clusterType,
            bool? sum,
            ClusterRankingModelOrderDirection orderDirection,
            ClusterRankingModelOptions options = null
        ){
            this.name = name;
            this.clusterType = clusterType;
            this.sum = sum;
            this.orderDirection = orderDirection;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.maximumValue = options?.maximumValue;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.rankingRewards = options?.rankingRewards;
            this.accessPeriodEventId = options?.accessPeriodEventId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.clusterType != null) {
                properties["clusterType"] = this.clusterType.Value.Str(
                );
            }
            if (this.minimumValue != null) {
                properties["minimumValue"] = this.minimumValue;
            }
            if (this.maximumValue != null) {
                properties["maximumValue"] = this.maximumValue;
            }
            if (this.sum != null) {
                properties["sum"] = this.sum;
            }
            if (this.orderDirection != null) {
                properties["orderDirection"] = this.orderDirection.Value.Str(
                );
            }
            if (this.entryPeriodEventId != null) {
                properties["entryPeriodEventId"] = this.entryPeriodEventId;
            }
            if (this.rankingRewards != null) {
                properties["rankingRewards"] = this.rankingRewards.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.accessPeriodEventId != null) {
                properties["accessPeriodEventId"] = this.accessPeriodEventId;
            }

            return properties;
        }

        public static ClusterRankingModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ClusterRankingModel(
                (string)properties["name"],
                new Func<ClusterRankingModelClusterType>(() =>
                {
                    return properties["clusterType"] switch {
                        ClusterRankingModelClusterType e => e,
                        string s => ClusterRankingModelClusterTypeExt.New(s),
                        _ => ClusterRankingModelClusterType.Raw
                    };
                })(),
                new Func<bool?>(() =>
                {
                    return properties["sum"] switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })(),
                new Func<ClusterRankingModelOrderDirection>(() =>
                {
                    return properties["orderDirection"] switch {
                        ClusterRankingModelOrderDirection e => e,
                        string s => ClusterRankingModelOrderDirectionExt.New(s),
                        _ => ClusterRankingModelOrderDirection.Asc
                    };
                })(),
                new ClusterRankingModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    minimumValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("minimumValue", out var minimumValue) ? minimumValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    maximumValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("maximumValue", out var maximumValue) ? maximumValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    entryPeriodEventId = properties.TryGetValue("entryPeriodEventId", out var entryPeriodEventId) ? (string)entryPeriodEventId : null,
                    rankingRewards = properties.TryGetValue("rankingRewards", out var rankingRewards) ? new Func<RankingReward[]>(() =>
                    {
                        return rankingRewards switch {
                            RankingReward[] v => v,
                            List<RankingReward> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(RankingReward.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(RankingReward.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    accessPeriodEventId = properties.TryGetValue("accessPeriodEventId", out var accessPeriodEventId) ? (string)accessPeriodEventId : null
                }
            );

            return model;
        }
    }
}
