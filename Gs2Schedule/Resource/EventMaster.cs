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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.Ref;

namespace Gs2Cdk.Gs2Schedule.Resource
{
    public class EventMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly string _scheduleType;
        private readonly long? _absoluteBegin;
        private readonly long? _absoluteEnd;
        private readonly string _repeatType;
        private readonly int? _repeatBeginDayOfMonth;
        private readonly int? _repeatEndDayOfMonth;
        private readonly string _repeatBeginDayOfWeek;
        private readonly string _repeatEndDayOfWeek;
        private readonly int? _repeatBeginHour;
        private readonly int? _repeatEndHour;
        private readonly string _relativeTriggerName;
        private readonly int? _relativeDuration;

        public EventMaster(
                Stack stack,
                string namespaceName,
                string name,
                string scheduleType,
                long? absoluteBegin,
                long? absoluteEnd,
                string repeatType,
                int? repeatBeginDayOfMonth,
                int? repeatEndDayOfMonth,
                string repeatBeginDayOfWeek,
                string repeatEndDayOfWeek,
                int? repeatBeginHour,
                int? repeatEndHour,
                string relativeTriggerName,
                int? relativeDuration,
                string description = null,
                string metadata = null
        ): base("Schedule_EventMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._scheduleType = scheduleType;
            this._absoluteBegin = absoluteBegin;
            this._absoluteEnd = absoluteEnd;
            this._repeatType = repeatType;
            this._repeatBeginDayOfMonth = repeatBeginDayOfMonth;
            this._repeatEndDayOfMonth = repeatEndDayOfMonth;
            this._repeatBeginDayOfWeek = repeatBeginDayOfWeek;
            this._repeatEndDayOfWeek = repeatEndDayOfWeek;
            this._repeatBeginHour = repeatBeginHour;
            this._repeatEndHour = repeatEndHour;
            this._relativeTriggerName = relativeTriggerName;
            this._relativeDuration = relativeDuration;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Schedule::EventMaster";
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
            if (this._scheduleType != null) {
                properties["ScheduleType"] = this._scheduleType.ToString();
            }
            if (this._absoluteBegin != null) {
                properties["AbsoluteBegin"] = this._absoluteBegin;
            }
            if (this._absoluteEnd != null) {
                properties["AbsoluteEnd"] = this._absoluteEnd;
            }
            if (this._repeatType != null) {
                properties["RepeatType"] = this._repeatType.ToString();
            }
            if (this._repeatBeginDayOfMonth != null) {
                properties["RepeatBeginDayOfMonth"] = this._repeatBeginDayOfMonth;
            }
            if (this._repeatEndDayOfMonth != null) {
                properties["RepeatEndDayOfMonth"] = this._repeatEndDayOfMonth;
            }
            if (this._repeatBeginDayOfWeek != null) {
                properties["RepeatBeginDayOfWeek"] = this._repeatBeginDayOfWeek.ToString();
            }
            if (this._repeatEndDayOfWeek != null) {
                properties["RepeatEndDayOfWeek"] = this._repeatEndDayOfWeek.ToString();
            }
            if (this._repeatBeginHour != null) {
                properties["RepeatBeginHour"] = this._repeatBeginHour;
            }
            if (this._repeatEndHour != null) {
                properties["RepeatEndHour"] = this._repeatEndHour;
            }
            if (this._relativeTriggerName != null) {
                properties["RelativeTriggerName"] = this._relativeTriggerName;
            }
            if (this._relativeDuration != null) {
                properties["RelativeDuration"] = this._relativeDuration;
            }
            return properties;
        }

        public EventMasterRef Ref(
                string namespaceName
        ) {
            return new EventMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrEventId() {
            return new GetAttr(
                "Item.EventId"
            );
        }
    }
}
