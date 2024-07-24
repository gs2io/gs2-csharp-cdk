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
using Gs2Cdk.Gs2Ranking.Model.Enums;
using Gs2Cdk.Gs2Ranking.Model.Options;

namespace Gs2Cdk.Gs2Ranking.Model
{
    public class CategoryModel {
        private string name;
        private bool? sum;
        private string sumString;
        private CategoryModelOrderDirection? orderDirection;
        private CategoryModelScope? scope;
        private string metadata;
        private long? minimumValue;
        private string minimumValueString;
        private long? maximumValue;
        private string maximumValueString;
        private GlobalRankingSetting globalRankingSetting;
        private string entryPeriodEventId;
        private string accessPeriodEventId;
        private bool? uniqueByUserId;
        private string uniqueByUserIdString;
        private int? calculateFixedTimingHour;
        private string calculateFixedTimingHourString;
        private int? calculateFixedTimingMinute;
        private string calculateFixedTimingMinuteString;
        private int? calculateIntervalMinutes;
        private string calculateIntervalMinutesString;
        private Scope[] additionalScopes;
        private string[] ignoreUserIds;
        private string generation;

        public CategoryModel(
            string name,
            bool? sum,
            CategoryModelOrderDirection orderDirection,
            CategoryModelScope scope,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.sum = sum;
            this.orderDirection = orderDirection;
            this.scope = scope;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.maximumValue = options?.maximumValue;
            this.globalRankingSetting = options?.globalRankingSetting;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.accessPeriodEventId = options?.accessPeriodEventId;
            this.uniqueByUserId = options?.uniqueByUserId;
            this.calculateFixedTimingHour = options?.calculateFixedTimingHour;
            this.calculateFixedTimingMinute = options?.calculateFixedTimingMinute;
            this.calculateIntervalMinutes = options?.calculateIntervalMinutes;
            this.additionalScopes = options?.additionalScopes;
            this.ignoreUserIds = options?.ignoreUserIds;
            this.generation = options?.generation;
        }

        public static CategoryModel ScopeIsGlobal(
            string name,
            bool? sum,
            CategoryModelOrderDirection orderDirection,
            GlobalRankingSetting globalRankingSetting,
            bool? uniqueByUserId,
            int? calculateIntervalMinutes,
            CategoryModelScopeIsGlobalOptions options = null
        ){
            return (new CategoryModel(
                name,
                sum,
                orderDirection,
                CategoryModelScope.Global,
                new CategoryModelOptions {
                    globalRankingSetting = globalRankingSetting,
                    uniqueByUserId = uniqueByUserId,
                    calculateIntervalMinutes = calculateIntervalMinutes,
                    metadata = options?.metadata,
                    minimumValue = options?.minimumValue,
                    maximumValue = options?.maximumValue,
                    entryPeriodEventId = options?.entryPeriodEventId,
                    accessPeriodEventId = options?.accessPeriodEventId,
                    calculateFixedTimingHour = options?.calculateFixedTimingHour,
                    calculateFixedTimingMinute = options?.calculateFixedTimingMinute,
                    additionalScopes = options?.additionalScopes,
                    ignoreUserIds = options?.ignoreUserIds,
                    generation = options?.generation,
                }
            ));
        }

        public static CategoryModel ScopeIsScoped(
            string name,
            bool? sum,
            CategoryModelOrderDirection orderDirection,
            CategoryModelScopeIsScopedOptions options = null
        ){
            return (new CategoryModel(
                name,
                sum,
                orderDirection,
                CategoryModelScope.Scoped,
                new CategoryModelOptions {
                    metadata = options?.metadata,
                    minimumValue = options?.minimumValue,
                    maximumValue = options?.maximumValue,
                    entryPeriodEventId = options?.entryPeriodEventId,
                    accessPeriodEventId = options?.accessPeriodEventId,
                    calculateFixedTimingHour = options?.calculateFixedTimingHour,
                    calculateFixedTimingMinute = options?.calculateFixedTimingMinute,
                    additionalScopes = options?.additionalScopes,
                    ignoreUserIds = options?.ignoreUserIds,
                    generation = options?.generation,
                }
            ));
        }


        public CategoryModel(
            string name,
            string sum,
            CategoryModelOrderDirection orderDirection,
            CategoryModelScope scope,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.sumString = sum;
            this.orderDirection = orderDirection;
            this.scope = scope;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.minimumValueString = options?.minimumValueString;
            this.maximumValue = options?.maximumValue;
            this.maximumValueString = options?.maximumValueString;
            this.globalRankingSetting = options?.globalRankingSetting;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.accessPeriodEventId = options?.accessPeriodEventId;
            this.uniqueByUserId = options?.uniqueByUserId;
            this.uniqueByUserIdString = options?.uniqueByUserIdString;
            this.calculateFixedTimingHour = options?.calculateFixedTimingHour;
            this.calculateFixedTimingHourString = options?.calculateFixedTimingHourString;
            this.calculateFixedTimingMinute = options?.calculateFixedTimingMinute;
            this.calculateFixedTimingMinuteString = options?.calculateFixedTimingMinuteString;
            this.calculateIntervalMinutes = options?.calculateIntervalMinutes;
            this.calculateIntervalMinutesString = options?.calculateIntervalMinutesString;
            this.additionalScopes = options?.additionalScopes;
            this.ignoreUserIds = options?.ignoreUserIds;
            this.generation = options?.generation;
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
            if (this.minimumValueString != null) {
                properties["minimumValue"] = this.minimumValueString;
            } else {
                if (this.minimumValue != null) {
                    properties["minimumValue"] = this.minimumValue;
                }
            }
            if (this.maximumValueString != null) {
                properties["maximumValue"] = this.maximumValueString;
            } else {
                if (this.maximumValue != null) {
                    properties["maximumValue"] = this.maximumValue;
                }
            }
            if (this.sumString != null) {
                properties["sum"] = this.sumString;
            } else {
                if (this.sum != null) {
                    properties["sum"] = this.sum;
                }
            }
            if (this.orderDirection != null) {
                properties["orderDirection"] = this.orderDirection.Value.Str(
                );
            }
            if (this.scope != null) {
                properties["scope"] = this.scope.Value.Str(
                );
            }
            if (this.globalRankingSetting != null) {
                properties["globalRankingSetting"] = this.globalRankingSetting?.Properties(
                );
            }
            if (this.entryPeriodEventId != null) {
                properties["entryPeriodEventId"] = this.entryPeriodEventId;
            }
            if (this.accessPeriodEventId != null) {
                properties["accessPeriodEventId"] = this.accessPeriodEventId;
            }
            if (this.uniqueByUserIdString != null) {
                properties["uniqueByUserId"] = this.uniqueByUserIdString;
            } else {
                if (this.uniqueByUserId != null) {
                    properties["uniqueByUserId"] = this.uniqueByUserId;
                }
            }
            if (this.calculateFixedTimingHourString != null) {
                properties["calculateFixedTimingHour"] = this.calculateFixedTimingHourString;
            } else {
                if (this.calculateFixedTimingHour != null) {
                    properties["calculateFixedTimingHour"] = this.calculateFixedTimingHour;
                }
            }
            if (this.calculateFixedTimingMinuteString != null) {
                properties["calculateFixedTimingMinute"] = this.calculateFixedTimingMinuteString;
            } else {
                if (this.calculateFixedTimingMinute != null) {
                    properties["calculateFixedTimingMinute"] = this.calculateFixedTimingMinute;
                }
            }
            if (this.calculateIntervalMinutesString != null) {
                properties["calculateIntervalMinutes"] = this.calculateIntervalMinutesString;
            } else {
                if (this.calculateIntervalMinutes != null) {
                    properties["calculateIntervalMinutes"] = this.calculateIntervalMinutes;
                }
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

        public static CategoryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CategoryModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("sum", out var sum) ? new Func<bool?>(() =>
                {
                    return sum switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                properties.TryGetValue("orderDirection", out var orderDirection) ? new Func<CategoryModelOrderDirection>(() =>
                {
                    return orderDirection switch {
                        CategoryModelOrderDirection e => e,
                        string s => CategoryModelOrderDirectionExt.New(s),
                        _ => CategoryModelOrderDirection.Asc
                    };
                })() : default,
                properties.TryGetValue("scope", out var scope) ? new Func<CategoryModelScope>(() =>
                {
                    return scope switch {
                        CategoryModelScope e => e,
                        string s => CategoryModelScopeExt.New(s),
                        _ => CategoryModelScope.Global
                    };
                })() : default,
                new CategoryModelOptions {
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
                    globalRankingSetting = properties.TryGetValue("globalRankingSetting", out var globalRankingSetting) ? new Func<GlobalRankingSetting>(() =>
                    {
                        return globalRankingSetting switch {
                            GlobalRankingSetting v => v,
                            Dictionary<string, object> v => GlobalRankingSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    entryPeriodEventId = properties.TryGetValue("entryPeriodEventId", out var entryPeriodEventId) ? (string)entryPeriodEventId : null,
                    accessPeriodEventId = properties.TryGetValue("accessPeriodEventId", out var accessPeriodEventId) ? (string)accessPeriodEventId : null,
                    uniqueByUserId = new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("uniqueByUserId", out var uniqueByUserId) ? uniqueByUserId switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    calculateFixedTimingHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("calculateFixedTimingHour", out var calculateFixedTimingHour) ? calculateFixedTimingHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    calculateFixedTimingMinute = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("calculateFixedTimingMinute", out var calculateFixedTimingMinute) ? calculateFixedTimingMinute switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    calculateIntervalMinutes = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("calculateIntervalMinutes", out var calculateIntervalMinutes) ? calculateIntervalMinutes switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
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
