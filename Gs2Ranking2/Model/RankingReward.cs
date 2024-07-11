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
using Gs2Cdk.Gs2Ranking2.Model.Options;

namespace Gs2Cdk.Gs2Ranking2.Model
{
    public class RankingReward {
        private int thresholdRank;
        private string thresholdRankString;
        private string metadata;
        private AcquireAction[] acquireActions;

        public RankingReward(
            int thresholdRank,
            RankingRewardOptions options = null
        ){
            this.thresholdRank = thresholdRank;
            this.metadata = options?.metadata;
            this.acquireActions = options?.acquireActions;
        }


        public RankingReward(
            string thresholdRank,
            RankingRewardOptions options = null
        ){
            this.thresholdRankString = thresholdRank;
            this.metadata = options?.metadata;
            this.acquireActions = options?.acquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.thresholdRankString != null) {
                properties["thresholdRank"] = this.thresholdRankString;
            } else {
                if (this.thresholdRank != null) {
                    properties["thresholdRank"] = this.thresholdRank;
                }
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static RankingReward FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RankingReward(
                new Func<int>(() =>
                {
                    return properties["thresholdRank"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new RankingRewardOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    acquireActions = properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return acquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
