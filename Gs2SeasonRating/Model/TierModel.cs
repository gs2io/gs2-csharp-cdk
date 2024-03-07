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
using Gs2Cdk.Gs2SeasonRating.Model;
using Gs2Cdk.Gs2SeasonRating.Model.Options;

namespace Gs2Cdk.Gs2SeasonRating.Model
{
    public class TierModel {
        private int raiseRankBonus;
        private int entryFee;
        private int minimumChangePoint;
        private int maximumChangePoint;
        private string metadata;

        public TierModel(
            int raiseRankBonus,
            int entryFee,
            int minimumChangePoint,
            int maximumChangePoint,
            TierModelOptions options = null
        ){
            this.raiseRankBonus = raiseRankBonus;
            this.entryFee = entryFee;
            this.minimumChangePoint = minimumChangePoint;
            this.maximumChangePoint = maximumChangePoint;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.raiseRankBonus != null) {
                properties["raiseRankBonus"] = this.raiseRankBonus;
            }
            if (this.entryFee != null) {
                properties["entryFee"] = this.entryFee;
            }
            if (this.minimumChangePoint != null) {
                properties["minimumChangePoint"] = this.minimumChangePoint;
            }
            if (this.maximumChangePoint != null) {
                properties["maximumChangePoint"] = this.maximumChangePoint;
            }

            return properties;
        }

        public static TierModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TierModel(
                new Func<int>(() =>
                {
                    return properties["raiseRankBonus"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["entryFee"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["minimumChangePoint"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["maximumChangePoint"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new TierModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
