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
using Gs2Cdk.Gs2Ranking.Model;
using Gs2Cdk.Gs2Ranking.Model.Options;

namespace Gs2Cdk.Gs2Ranking.Model
{
    public class GlobalRankingSetting {
        private bool? uniqueByUserId;
        private string uniqueByUserIdString;
        private int calculateIntervalMinutes;
        private string calculateIntervalMinutesString;
        private FixedTiming calculateFixedTiming;
        private Scope[] additionalScopes;
        private string[] ignoreUserIds;
        private string generation;

        public GlobalRankingSetting(
            bool? uniqueByUserId,
            int calculateIntervalMinutes,
            GlobalRankingSettingOptions options = null
        ){
            this.uniqueByUserId = uniqueByUserId;
            this.calculateIntervalMinutes = calculateIntervalMinutes;
            this.calculateFixedTiming = options?.calculateFixedTiming;
            this.additionalScopes = options?.additionalScopes;
            this.ignoreUserIds = options?.ignoreUserIds;
            this.generation = options?.generation;
        }


        public GlobalRankingSetting(
            string uniqueByUserId,
            string calculateIntervalMinutes,
            GlobalRankingSettingOptions options = null
        ){
            this.uniqueByUserIdString = uniqueByUserId;
            this.calculateIntervalMinutesString = calculateIntervalMinutes;
            this.calculateFixedTiming = options?.calculateFixedTiming;
            this.additionalScopes = options?.additionalScopes;
            this.ignoreUserIds = options?.ignoreUserIds;
            this.generation = options?.generation;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.uniqueByUserIdString != null) {
                properties["uniqueByUserId"] = this.uniqueByUserIdString;
            } else {
                if (this.uniqueByUserId != null) {
                    properties["uniqueByUserId"] = this.uniqueByUserId;
                }
            }
            if (this.calculateIntervalMinutesString != null) {
                properties["calculateIntervalMinutes"] = this.calculateIntervalMinutesString;
            } else {
                if (this.calculateIntervalMinutes != null) {
                    properties["calculateIntervalMinutes"] = this.calculateIntervalMinutes;
                }
            }
            if (this.calculateFixedTiming != null) {
                properties["calculateFixedTiming"] = this.calculateFixedTiming?.Properties(
                );
            }
            if (this.additionalScopes != null) {
                properties["additionalScopes"] = this.additionalScopes.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.ignoreUserIds != null) {
                properties["ignoreUserIds"] = this.ignoreUserIds;
            }
            if (this.generation != null) {
                properties["generation"] = this.generation;
            }

            return properties;
        }

        public static GlobalRankingSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GlobalRankingSetting(
                properties.TryGetValue("uniqueByUserId", out var uniqueByUserId) ? new Func<bool?>(() =>
                {
                    return uniqueByUserId switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                properties.TryGetValue("calculateIntervalMinutes", out var calculateIntervalMinutes) ? new Func<int>(() =>
                {
                    return calculateIntervalMinutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new GlobalRankingSettingOptions {
                    calculateFixedTiming = properties.TryGetValue("calculateFixedTiming", out var calculateFixedTiming) ? new Func<FixedTiming>(() =>
                    {
                        return calculateFixedTiming switch {
                            FixedTiming v => v,
                            Dictionary<string, object> v => FixedTiming.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    additionalScopes = properties.TryGetValue("additionalScopes", out var additionalScopes) ? new Func<Scope[]>(() =>
                    {
                        return additionalScopes switch {
                            Scope[] v => v,
                            List<Scope> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(Scope.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(Scope.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    ignoreUserIds = properties.TryGetValue("ignoreUserIds", out var ignoreUserIds) ? new Func<string[]>(() =>
                    {
                        return ignoreUserIds switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    generation = properties.TryGetValue("generation", out var generation) ? (string)generation : null
                }
            );

            return model;
        }
    }
}
