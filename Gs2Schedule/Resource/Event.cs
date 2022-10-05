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

    public static class EventScheduleTypeExt
    {
        public static string ToString(this Event.ScheduleType self)
        {
            switch (self) {
                case Event.ScheduleType.Absolute:
                    return "absolute";
                case Event.ScheduleType.Relative:
                    return "relative";
            }
            return "unknown";
        }
    }

    public static class EventRepeatTypeExt
    {
        public static string ToString(this Event.RepeatType self)
        {
            switch (self) {
                case Event.RepeatType.Always:
                    return "always";
                case Event.RepeatType.Daily:
                    return "daily";
                case Event.RepeatType.Weekly:
                    return "weekly";
                case Event.RepeatType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }
    }

    public static class EventRepeatBeginDayOfWeekExt
    {
        public static string ToString(this Event.RepeatBeginDayOfWeek self)
        {
            switch (self) {
                case Event.RepeatBeginDayOfWeek.Sunday:
                    return "sunday";
                case Event.RepeatBeginDayOfWeek.Monday:
                    return "monday";
                case Event.RepeatBeginDayOfWeek.Tuesday:
                    return "tuesday";
                case Event.RepeatBeginDayOfWeek.Wednesday:
                    return "wednesday";
                case Event.RepeatBeginDayOfWeek.Thursday:
                    return "thursday";
                case Event.RepeatBeginDayOfWeek.Friday:
                    return "friday";
                case Event.RepeatBeginDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }

    public static class EventRepeatEndDayOfWeekExt
    {
        public static string ToString(this Event.RepeatEndDayOfWeek self)
        {
            switch (self) {
                case Event.RepeatEndDayOfWeek.Sunday:
                    return "sunday";
                case Event.RepeatEndDayOfWeek.Monday:
                    return "monday";
                case Event.RepeatEndDayOfWeek.Tuesday:
                    return "tuesday";
                case Event.RepeatEndDayOfWeek.Wednesday:
                    return "wednesday";
                case Event.RepeatEndDayOfWeek.Thursday:
                    return "thursday";
                case Event.RepeatEndDayOfWeek.Friday:
                    return "friday";
                case Event.RepeatEndDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }

    public class Event {

        public enum ScheduleType
        {
            Absolute,
            Relative
        }

        public enum RepeatType
        {
            Always,
            Daily,
            Weekly,
            Monthly
        }

        public enum RepeatBeginDayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public enum RepeatEndDayOfWeek
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
	    private readonly ScheduleType _scheduleType;
	    private readonly RepeatType? _repeatType;
	    private readonly long? _absoluteBegin;
	    private readonly long? _absoluteEnd;
	    private readonly int? _repeatBeginDayOfMonth;
	    private readonly int? _repeatEndDayOfMonth;
	    private readonly RepeatBeginDayOfWeek? _repeatBeginDayOfWeek;
	    private readonly RepeatEndDayOfWeek? _repeatEndDayOfWeek;
	    private readonly int? _repeatBeginHour;
	    private readonly int? _repeatEndHour;
	    private readonly string _relativeTriggerName;
	    private readonly int? _relativeDuration;

        public Event(
                string name,
                ScheduleType scheduleType,
                string metadata = null,
                RepeatType? repeatType = null,
                long? absoluteBegin = null,
                long? absoluteEnd = null,
                int? repeatBeginDayOfMonth = null,
                int? repeatEndDayOfMonth = null,
                RepeatBeginDayOfWeek? repeatBeginDayOfWeek = null,
                RepeatEndDayOfWeek? repeatEndDayOfWeek = null,
                int? repeatBeginHour = null,
                int? repeatEndHour = null,
                string relativeTriggerName = null,
                int? relativeDuration = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._scheduleType = scheduleType;
            this._repeatType = repeatType;
            this._absoluteBegin = absoluteBegin;
            this._absoluteEnd = absoluteEnd;
            this._repeatBeginDayOfMonth = repeatBeginDayOfMonth;
            this._repeatEndDayOfMonth = repeatEndDayOfMonth;
            this._repeatBeginDayOfWeek = repeatBeginDayOfWeek;
            this._repeatEndDayOfWeek = repeatEndDayOfWeek;
            this._repeatBeginHour = repeatBeginHour;
            this._repeatEndHour = repeatEndHour;
            this._relativeTriggerName = relativeTriggerName;
            this._relativeDuration = relativeDuration;
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
            if (this._scheduleType != null) {
                properties["ScheduleType"] = this._scheduleType.ToString();
            }
            if (this._repeatType != null) {
                properties["RepeatType"] = this._repeatType.ToString();
            }
            if (this._absoluteBegin != null) {
                properties["AbsoluteBegin"] = this._absoluteBegin;
            }
            if (this._absoluteEnd != null) {
                properties["AbsoluteEnd"] = this._absoluteEnd;
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
    }
}
