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

    public static class CategoryModelOrderDirectionExt
    {
        public static string ToString(this CategoryModel.OrderDirection self)
        {
            switch (self) {
                case CategoryModel.OrderDirection.Asc:
                    return "asc";
                case CategoryModel.OrderDirection.Desc:
                    return "desc";
            }
            return "unknown";
        }
    }

    public static class CategoryModelScopeExt
    {
        public static string ToString(this CategoryModel.Scope self)
        {
            switch (self) {
                case CategoryModel.Scope.Global:
                    return "global";
                case CategoryModel.Scope.Scoped:
                    return "scoped";
            }
            return "unknown";
        }
    }

    public class CategoryModel {

        public enum OrderDirection
        {
            Asc,
            Desc
        }

        public enum Scope
        {
            Global,
            Scoped
        }
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly long? _minimumValue;
	    private readonly long? _maximumValue;
	    private readonly OrderDirection _orderDirection;
	    private readonly Scope _scope;
	    private readonly bool? _uniqueByUserId;
	    private readonly int? _calculateFixedTimingHour;
	    private readonly int? _calculateFixedTimingMinute;
	    private readonly int? _calculateIntervalMinutes;
	    private readonly string _entryPeriodEventId;
	    private readonly string _accessPeriodEventId;
	    private readonly string _generation;

        public CategoryModel(
                string name,
                OrderDirection orderDirection,
                Scope scope,
                bool? uniqueByUserId,
                string metadata = null,
                long? minimumValue = null,
                long? maximumValue = null,
                int? calculateFixedTimingHour = null,
                int? calculateFixedTimingMinute = null,
                int? calculateIntervalMinutes = null,
                string entryPeriodEventId = null,
                string accessPeriodEventId = null,
                string generation = null
        )
        {
            this._name = name;
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
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
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

        public CategoryModelRef Ref(
                string namespaceName
        )
        {
            return new CategoryModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
