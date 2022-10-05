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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.Ref;

namespace Gs2Cdk.Gs2Limit.Resource
{

    public static class LimitModelResetTypeExt
    {
        public static string ToString(this LimitModel.ResetType self)
        {
            switch (self) {
                case LimitModel.ResetType.NotReset:
                    return "notReset";
                case LimitModel.ResetType.Daily:
                    return "daily";
                case LimitModel.ResetType.Weekly:
                    return "weekly";
                case LimitModel.ResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }
    }

    public static class LimitModelResetDayOfWeekExt
    {
        public static string ToString(this LimitModel.ResetDayOfWeek self)
        {
            switch (self) {
                case LimitModel.ResetDayOfWeek.Sunday:
                    return "sunday";
                case LimitModel.ResetDayOfWeek.Monday:
                    return "monday";
                case LimitModel.ResetDayOfWeek.Tuesday:
                    return "tuesday";
                case LimitModel.ResetDayOfWeek.Wednesday:
                    return "wednesday";
                case LimitModel.ResetDayOfWeek.Thursday:
                    return "thursday";
                case LimitModel.ResetDayOfWeek.Friday:
                    return "friday";
                case LimitModel.ResetDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }

    public class LimitModel {

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
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly ResetType _resetType;
	    private readonly int? _resetDayOfMonth;
	    private readonly ResetDayOfWeek? _resetDayOfWeek;
	    private readonly int? _resetHour;

        public LimitModel(
                string name,
                ResetType resetType,
                string metadata = null,
                int? resetDayOfMonth = null,
                ResetDayOfWeek? resetDayOfWeek = null,
                int? resetHour = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._resetType = resetType;
            this._resetDayOfMonth = resetDayOfMonth;
            this._resetDayOfWeek = resetDayOfWeek;
            this._resetHour = resetHour;
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

        public LimitModelRef Ref(
                string namespaceName
        )
        {
            return new LimitModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
