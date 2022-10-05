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
using Gs2Cdk.Gs2Mission.Resource;

namespace Gs2Cdk.Gs2Mission.Model
{

    public static class CounterScopeModelResetTypeExt
    {
        public static string ToString(this CounterScopeModel.ResetType self)
        {
            switch (self) {
                case CounterScopeModel.ResetType.NotReset:
                    return "notReset";
                case CounterScopeModel.ResetType.Daily:
                    return "daily";
                case CounterScopeModel.ResetType.Weekly:
                    return "weekly";
                case CounterScopeModel.ResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }
    }

    public static class CounterScopeModelResetDayOfWeekExt
    {
        public static string ToString(this CounterScopeModel.ResetDayOfWeek self)
        {
            switch (self) {
                case CounterScopeModel.ResetDayOfWeek.Sunday:
                    return "sunday";
                case CounterScopeModel.ResetDayOfWeek.Monday:
                    return "monday";
                case CounterScopeModel.ResetDayOfWeek.Tuesday:
                    return "tuesday";
                case CounterScopeModel.ResetDayOfWeek.Wednesday:
                    return "wednesday";
                case CounterScopeModel.ResetDayOfWeek.Thursday:
                    return "thursday";
                case CounterScopeModel.ResetDayOfWeek.Friday:
                    return "friday";
                case CounterScopeModel.ResetDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }

    public class CounterScopeModel
    {

        public enum ResetType
        {
            NotReset,
            Daily,
            Weekly,
            Monthly
        }

        public enum ResetDayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
	    private readonly ResetType _resetType;
	    private readonly int? _resetDayOfMonth;
	    private readonly ResetDayOfWeek? _resetDayOfWeek;
	    private readonly int? _resetHour;

        public CounterScopeModel(
                ResetType resetType,
                int? resetDayOfMonth = null,
                ResetDayOfWeek? resetDayOfWeek = null,
                int? resetHour = null
        )
        {
            this._resetType = resetType;
            this._resetDayOfMonth = resetDayOfMonth;
            this._resetDayOfWeek = resetDayOfWeek;
            this._resetHour = resetHour;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._resetType != null) {
                properties["ResetType"] = this._resetType.ToString();
            }
            if (this._resetDayOfMonth != null) {
                properties["ResetDayOfMonth"] = this._resetDayOfMonth;
            }
            if (this._resetDayOfWeek != null) {
                properties["ResetDayOfWeek"] = this._resetDayOfWeek.ToString();
            }
            if (this._resetHour != null) {
                properties["ResetHour"] = this._resetHour;
            }
            return properties;
        }
    }
}
