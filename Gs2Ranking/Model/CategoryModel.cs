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
        private bool? uniqueByUserId;
        private string metadata;
        private long? minimumValue;
        private long? maximumValue;
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
            bool? uniqueByUserId,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.orderDirection = orderDirection;
            this.scope = scope;
            this.uniqueByUserId = uniqueByUserId;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.maximumValue = options?.maximumValue;
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
                uniqueByUserId,
                new CategoryModelOptions {
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
            bool? uniqueByUserId,
            CategoryModelScopeIsScopedOptions options = null
        ){
            return (new CategoryModel(
                name,
                orderDirection,
                CategoryModelScope.Scoped,
                uniqueByUserId,
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
                properties["additionalScopes"] = this.additionalScopes.Select(v => v.Properties(
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
    }
}
