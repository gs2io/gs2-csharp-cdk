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
    public class SeasonModel {
        private string name;
        private TierModel[] tiers;
        private string experienceModelId;
        private string metadata;
        private string challengePeriodEventId;

        public SeasonModel(
            string name,
            TierModel[] tiers,
            string experienceModelId,
            SeasonModelOptions options = null
        ){
            this.name = name;
            this.tiers = tiers;
            this.experienceModelId = experienceModelId;
            this.metadata = options?.metadata;
            this.challengePeriodEventId = options?.challengePeriodEventId;
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
            if (this.tiers != null) {
                properties["tiers"] = this.tiers.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.experienceModelId != null) {
                properties["experienceModelId"] = this.experienceModelId;
            }
            if (this.challengePeriodEventId != null) {
                properties["challengePeriodEventId"] = this.challengePeriodEventId;
            }

            return properties;
        }

        public static SeasonModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SeasonModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("tiers", out var tiers) ? new Func<TierModel[]>(() =>
                {
                    return tiers switch {
                        Dictionary<string, object>[] v => v.Select(TierModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ TierModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(TierModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as TierModel).ToArray(),
                        { } v => new []{ v as TierModel },
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("experienceModelId", out var experienceModelId) ? new Func<string>(() =>
                {
                    return (string) experienceModelId;
                })() : default,
                new SeasonModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    challengePeriodEventId = properties.TryGetValue("challengePeriodEventId", out var challengePeriodEventId) ? (string)challengePeriodEventId : null
                }
            );

            return model;
        }
    }
}
