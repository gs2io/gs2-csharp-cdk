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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Ref;

namespace Gs2Cdk.Gs2Mission.Resource
{

    public static class MissionGroupModelResetTypeExt
    {
        public static string ToString(this MissionGroupModel.ResetType self)
        {
            switch (self) {
                case MissionGroupModel.ResetType.NotReset:
                    return "notReset";
                case MissionGroupModel.ResetType.Daily:
                    return "daily";
                case MissionGroupModel.ResetType.Weekly:
                    return "weekly";
                case MissionGroupModel.ResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }
    }

    public static class MissionGroupModelResetDayOfWeekExt
    {
        public static string ToString(this MissionGroupModel.ResetDayOfWeek self)
        {
            switch (self) {
                case MissionGroupModel.ResetDayOfWeek.Sunday:
                    return "sunday";
                case MissionGroupModel.ResetDayOfWeek.Monday:
                    return "monday";
                case MissionGroupModel.ResetDayOfWeek.Tuesday:
                    return "tuesday";
                case MissionGroupModel.ResetDayOfWeek.Wednesday:
                    return "wednesday";
                case MissionGroupModel.ResetDayOfWeek.Thursday:
                    return "thursday";
                case MissionGroupModel.ResetDayOfWeek.Friday:
                    return "friday";
                case MissionGroupModel.ResetDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }

    public class MissionGroupModel {

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
	    private readonly MissionTaskModel[] _tasks;
	    private readonly ResetType _resetType;
	    private readonly int? _resetDayOfMonth;
	    private readonly ResetDayOfWeek? _resetDayOfWeek;
	    private readonly int? _resetHour;
	    private readonly string _completeNotificationNamespaceId;

        public MissionGroupModel(
                string name,
                ResetType resetType,
                string metadata = null,
                MissionTaskModel[] tasks = null,
                int? resetDayOfMonth = null,
                ResetDayOfWeek? resetDayOfWeek = null,
                int? resetHour = null,
                string completeNotificationNamespaceId = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._tasks = tasks;
            this._resetType = resetType;
            this._resetDayOfMonth = resetDayOfMonth;
            this._resetDayOfWeek = resetDayOfWeek;
            this._resetHour = resetHour;
            this._completeNotificationNamespaceId = completeNotificationNamespaceId;
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
            if (this._tasks != null) {
                properties["Tasks"] = this._tasks.Select(v => v.Properties()).ToArray();
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
            if (this._completeNotificationNamespaceId != null) {
                properties["CompleteNotificationNamespaceId"] = this._completeNotificationNamespaceId;
            }
            return properties;
        }

        public MissionGroupModelRef Ref(
                string namespaceName
        )
        {
            return new MissionGroupModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
