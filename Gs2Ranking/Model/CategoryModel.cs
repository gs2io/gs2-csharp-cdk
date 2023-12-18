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
        private CategoryModelOrderDirection? orderDirection;
        private CategoryModelScope? scope;
        private string metadata;
        private long? minimumValue;
        private long? maximumValue;
        private bool? uniqueByUserId;
        private bool? sum;
        private int? calculateFixedTimingHour;
        private int? calculateFixedTimingMinute;
        private int? calculateIntervalMinutes;
        private Scope[] additionalScopes;
        private string entryPeriodEventId;
        private string accessPeriodEventId;
        private string[] ignoreUserIds;
        private string generation;

        public CategoryModel(
            string name,
            CategoryModelOrderDirection orderDirection,
            CategoryModelScope scope,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.orderDirection = orderDirection;
            this.scope = scope;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.maximumValue = options?.maximumValue;
            this.uniqueByUserId = options?.uniqueByUserId;
            this.sum = options?.sum;
            this.calculateFixedTimingHour = options?.calculateFixedTimingHour;
            this.calculateFixedTimingMinute = options?.calculateFixedTimingMinute;
            this.calculateIntervalMinutes = options?.calculateIntervalMinutes;
            this.additionalScopes = options?.additionalScopes;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.accessPeriodEventId = options?.accessPeriodEventId;
            this.ignoreUserIds = options?.ignoreUserIds;
            this.generation = options?.generation;
        }

        public static CategoryModel ScopeIsGlobal(
            string name,
            CategoryModelOrderDirection orderDirection,
            bool? uniqueByUserId,
            int? calculateIntervalMinutes,
            CategoryModelScopeIsGlobalOptions options = null
        ){
            return (new CategoryModel(
                name,
                orderDirection,
                CategoryModelScope.Global,
                new CategoryModelOptions {
                    uniqueByUserId = uniqueByUserId,
                    calculateIntervalMinutes = calculateIntervalMinutes,
                    metadata = options?.metadata,
                    minimumValue = options?.minimumValue,
                    maximumValue = options?.maximumValue,
                    calculateFixedTimingHour = options?.calculateFixedTimingHour,
                    calculateFixedTimingMinute = options?.calculateFixedTimingMinute,
                    additionalScopes = options?.additionalScopes,
                    entryPeriodEventId = options?.entryPeriodEventId,
                    accessPeriodEventId = options?.accessPeriodEventId,
                    ignoreUserIds = options?.ignoreUserIds,
                    generation = options?.generation,
                }
            ));
        }

        public static CategoryModel ScopeIsScoped(
            string name,
            CategoryModelOrderDirection orderDirection,
            CategoryModelScopeIsScopedOptions options = null
        ){
            return (new CategoryModel(
                name,
                orderDirection,
                CategoryModelScope.Scoped,
                new CategoryModelOptions {
                    metadata = options?.metadata,
                    minimumValue = options?.minimumValue,
                    maximumValue = options?.maximumValue,
                    calculateFixedTimingHour = options?.calculateFixedTimingHour,
                    calculateFixedTimingMinute = options?.calculateFixedTimingMinute,
                    additionalScopes = options?.additionalScopes,
                    entryPeriodEventId = options?.entryPeriodEventId,
                    accessPeriodEventId = options?.accessPeriodEventId,
                    ignoreUserIds = options?.ignoreUserIds,
                    generation = options?.generation,
                }
            ));
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
            if (this.minimumValue != null) {
                properties["minimumValue"] = this.minimumValue;
            }
            if (this.maximumValue != null) {
                properties["maximumValue"] = this.maximumValue;
            }
            if (this.orderDirection != null) {
                properties["orderDirection"] = this.orderDirection?.Str(
                );
            }
            if (this.scope != null) {
                properties["scope"] = this.scope?.Str(
                );
            }
            if (this.uniqueByUserId != null) {
                properties["uniqueByUserId"] = this.uniqueByUserId;
            }
            if (this.sum != null) {
                properties["sum"] = this.sum;
            }
            if (this.calculateFixedTimingHour != null) {
                properties["calculateFixedTimingHour"] = this.calculateFixedTimingHour;
            }
            if (this.calculateFixedTimingMinute != null) {
                properties["calculateFixedTimingMinute"] = this.calculateFixedTimingMinute;
            }
            if (this.calculateIntervalMinutes != null) {
                properties["calculateIntervalMinutes"] = this.calculateIntervalMinutes;
            }
            if (this.additionalScopes != null) {
                properties["additionalScopes"] = this.additionalScopes.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.entryPeriodEventId != null) {
                properties["entryPeriodEventId"] = this.entryPeriodEventId;
            }
            if (this.accessPeriodEventId != null) {
                properties["accessPeriodEventId"] = this.accessPeriodEventId;
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
                (string)properties["name"],
                new Func<CategoryModelOrderDirection>(() =>
                {
                    return properties["orderDirection"] switch {
                        CategoryModelOrderDirection e => e,
                        string s => CategoryModelOrderDirectionExt.New(s),
                        _ => CategoryModelOrderDirection.Asc
                    };
                })(),
                new Func<CategoryModelScope>(() =>
                {
                    return properties["scope"] switch {
                        CategoryModelScope e => e,
                        string s => CategoryModelScopeExt.New(s),
                        _ => CategoryModelScope.Global
                    };
                })(),
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
                    uniqueByUserId = new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("uniqueByUserId", out var uniqueByUserId) ? uniqueByUserId switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    sum = new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("sum", out var sum) ? sum switch {
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
                    entryPeriodEventId = properties.TryGetValue("entryPeriodEventId", out var entryPeriodEventId) ? (string)entryPeriodEventId : null,
                    accessPeriodEventId = properties.TryGetValue("accessPeriodEventId", out var accessPeriodEventId) ? (string)accessPeriodEventId : null,
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
