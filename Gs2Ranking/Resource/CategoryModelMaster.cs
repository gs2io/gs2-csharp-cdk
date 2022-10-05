/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Ranking.Model;
using Gs2Cdk.Gs2Ranking.Ref;

namespace Gs2Cdk.Gs2Ranking.Resource
{
    public class CategoryModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly long? _minimumValue;
        private readonly long? _maximumValue;
        private readonly string _orderDirection;
        private readonly string _scope;
        private readonly bool? _uniqueByUserId;
        private readonly int? _calculateFixedTimingHour;
        private readonly int? _calculateFixedTimingMinute;
        private readonly int? _calculateIntervalMinutes;
        private readonly string _entryPeriodEventId;
        private readonly string _accessPeriodEventId;
        private readonly string _generation;

        public CategoryModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                string orderDirection,
                string scope,
                bool? uniqueByUserId,
                int? calculateIntervalMinutes,
                string description = null,
                string metadata = null,
                long? minimumValue = null,
                long? maximumValue = null,
                int? calculateFixedTimingHour = null,
                int? calculateFixedTimingMinute = null,
                string entryPeriodEventId = null,
                string accessPeriodEventId = null,
                string generation = null
        ): base("Ranking_CategoryModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._minimumValue = minimumValue;
            this._maximumValue = maximumValue;
            this._orderDirection = orderDirection;
            this._scope = scope;
            this._uniqueByUserId = uniqueByUserId;
            this._calculateFixedTimingHour = calculateFixedTimingHour;
            this._calculateFixedTimingMinute = calculateFixedTimingMinute;
            this._calculateIntervalMinutes = calculateIntervalMinutes;
            this._entryPeriodEventId = entryPeriodEventId;
            this._accessPeriodEventId = accessPeriodEventId;
            this._generation = generation;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Ranking::CategoryModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._minimumValue != null) {
                properties["MinimumValue"] = this._minimumValue;
            }
            if (this._maximumValue != null) {
                properties["MaximumValue"] = this._maximumValue;
            }
            if (this._orderDirection != null) {
                properties["OrderDirection"] = this._orderDirection.ToString();
            }
            if (this._scope != null) {
                properties["Scope"] = this._scope.ToString();
            }
            if (this._uniqueByUserId != null) {
                properties["UniqueByUserId"] = this._uniqueByUserId;
            }
            if (this._calculateFixedTimingHour != null) {
                properties["CalculateFixedTimingHour"] = this._calculateFixedTimingHour;
            }
            if (this._calculateFixedTimingMinute != null) {
                properties["CalculateFixedTimingMinute"] = this._calculateFixedTimingMinute;
            }
            if (this._calculateIntervalMinutes != null) {
                properties["CalculateIntervalMinutes"] = this._calculateIntervalMinutes;
            }
            if (this._entryPeriodEventId != null) {
                properties["EntryPeriodEventId"] = this._entryPeriodEventId;
            }
            if (this._accessPeriodEventId != null) {
                properties["AccessPeriodEventId"] = this._accessPeriodEventId;
            }
            if (this._generation != null) {
                properties["Generation"] = this._generation;
            }
            return properties;
        }

        public CategoryModelMasterRef Ref(
                string namespaceName
        ) {
            return new CategoryModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrCategoryModelId() {
            return new GetAttr(
                "Item.CategoryModelId"
            );
        }
    }
}
