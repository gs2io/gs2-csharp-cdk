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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class ExperienceModel {
        private string name;
        private long? defaultExperience;
        private long defaultRankCap;
        private long maxRankCap;
        private Threshold rankThreshold;
        private string metadata;
        private AcquireActionRate[] acquireActionRates;

        public ExperienceModel(
            string name,
            long? defaultExperience,
            long defaultRankCap,
            long maxRankCap,
            Threshold rankThreshold,
            ExperienceModelOptions options = null
        ){
            this.name = name;
            this.defaultExperience = defaultExperience;
            this.defaultRankCap = defaultRankCap;
            this.maxRankCap = maxRankCap;
            this.rankThreshold = rankThreshold;
            this.metadata = options?.metadata;
            this.acquireActionRates = options?.acquireActionRates;
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
            if (this.defaultExperience != null) {
                properties["defaultExperience"] = this.defaultExperience;
            }
            if (this.defaultRankCap != null) {
                properties["defaultRankCap"] = this.defaultRankCap;
            }
            if (this.maxRankCap != null) {
                properties["maxRankCap"] = this.maxRankCap;
            }
            if (this.rankThreshold != null) {
                properties["rankThreshold"] = this.rankThreshold?.Properties(
                );
            }
            if (this.acquireActionRates != null) {
                properties["acquireActionRates"] = this.acquireActionRates.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static ExperienceModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ExperienceModel(
                (string)properties["name"],
                new Func<long?>(() =>
                {
                    return properties["defaultExperience"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<long>(() =>
                {
                    return properties["defaultRankCap"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<long>(() =>
                {
                    return properties["maxRankCap"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<Threshold>(() =>
                {
                    return properties["rankThreshold"] switch {
                        Threshold v => v,
                        Threshold[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Threshold.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Threshold.FromProperties(v.First()) : null,
                        _ => null
                    };
                })(),
                new ExperienceModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    acquireActionRates = properties.TryGetValue("acquireActionRates", out var acquireActionRates) ? new Func<AcquireActionRate[]>(() =>
                    {
                        return acquireActionRates switch {
                            AcquireActionRate[] v => v,
                            List<AcquireActionRate> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireActionRate.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireActionRate.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
