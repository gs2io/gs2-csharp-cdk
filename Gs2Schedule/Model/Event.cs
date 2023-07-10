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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.Model.Enums;
using Gs2Cdk.Gs2Schedule.Model.Options;

namespace Gs2Cdk.Gs2Schedule.Model
{
    public class Event {
        private string name;
        private EventScheduleType? scheduleType;
        private EventRepeatType? repeatType;
        private string metadata;
        private long? absoluteBegin;
        private long? absoluteEnd;
        private int? repeatBeginDayOfMonth;
        private int? repeatEndDayOfMonth;
        private EventRepeatBeginDayOfWeek? repeatBeginDayOfWeek;
        private EventRepeatEndDayOfWeek? repeatEndDayOfWeek;
        private int? repeatBeginHour;
        private int? repeatEndHour;
        private string relativeTriggerName;

        public Event(
            string name,
            EventScheduleType scheduleType,
            EventRepeatType repeatType,
            EventOptions options = null
        ){
            this.name = name;
            this.scheduleType = scheduleType;
            this.repeatType = repeatType;
            this.metadata = options?.metadata;
            this.absoluteBegin = options?.absoluteBegin;
            this.absoluteEnd = options?.absoluteEnd;
            this.repeatBeginDayOfMonth = options?.repeatBeginDayOfMonth;
            this.repeatEndDayOfMonth = options?.repeatEndDayOfMonth;
            this.repeatBeginDayOfWeek = options?.repeatBeginDayOfWeek;
            this.repeatEndDayOfWeek = options?.repeatEndDayOfWeek;
            this.repeatBeginHour = options?.repeatBeginHour;
            this.repeatEndHour = options?.repeatEndHour;
            this.relativeTriggerName = options?.relativeTriggerName;
        }

        public static Event ScheduleTypeIsAbsolute(
            string name,
            EventRepeatType repeatType,
            long? absoluteBegin,
            long? absoluteEnd,
            EventScheduleTypeIsAbsoluteOptions options = null
        ){
            return (new Event(
                name,
                EventScheduleType.Absolute,
                repeatType,
                new EventOptions {
                    absoluteBegin = absoluteBegin,
                    absoluteEnd = absoluteEnd,
                    metadata = options?.metadata,
                }
            ));
        }

        public static Event ScheduleTypeIsRelative(
            string name,
            EventRepeatType repeatType,
            string relativeTriggerName,
            EventScheduleTypeIsRelativeOptions options = null
        ){
            return (new Event(
                name,
                EventScheduleType.Relative,
                repeatType,
                new EventOptions {
                    relativeTriggerName = relativeTriggerName,
                    metadata = options?.metadata,
                }
            ));
        }

        public static Event RepeatTypeIsAlways(
            string name,
            EventScheduleType scheduleType,
            EventRepeatTypeIsAlwaysOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                EventRepeatType.Always,
                new EventOptions {
                    metadata = options?.metadata,
                }
            ));
        }

        public static Event RepeatTypeIsDaily(
            string name,
            EventScheduleType scheduleType,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsDailyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                EventRepeatType.Daily,
                new EventOptions {
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static Event RepeatTypeIsWeekly(
            string name,
            EventScheduleType scheduleType,
            EventRepeatBeginDayOfWeek repeatBeginDayOfWeek,
            EventRepeatEndDayOfWeek repeatEndDayOfWeek,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsWeeklyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                EventRepeatType.Weekly,
                new EventOptions {
                    repeatBeginDayOfWeek = repeatBeginDayOfWeek,
                    repeatEndDayOfWeek = repeatEndDayOfWeek,
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static Event RepeatTypeIsMonthly(
            string name,
            EventScheduleType scheduleType,
            int? repeatBeginDayOfMonth,
            int? repeatEndDayOfMonth,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsMonthlyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                EventRepeatType.Monthly,
                new EventOptions {
                    repeatBeginDayOfMonth = repeatBeginDayOfMonth,
                    repeatEndDayOfMonth = repeatEndDayOfMonth,
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
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
            if (this.scheduleType != null) {
                properties["scheduleType"] = this.scheduleType?.Str(
                );
            }
            if (this.repeatType != null) {
                properties["repeatType"] = this.repeatType?.Str(
                );
            }
            if (this.absoluteBegin != null) {
                properties["absoluteBegin"] = this.absoluteBegin;
            }
            if (this.absoluteEnd != null) {
                properties["absoluteEnd"] = this.absoluteEnd;
            }
            if (this.repeatBeginDayOfMonth != null) {
                properties["repeatBeginDayOfMonth"] = this.repeatBeginDayOfMonth;
            }
            if (this.repeatEndDayOfMonth != null) {
                properties["repeatEndDayOfMonth"] = this.repeatEndDayOfMonth;
            }
            if (this.repeatBeginDayOfWeek != null) {
                properties["repeatBeginDayOfWeek"] = this.repeatBeginDayOfWeek?.Str(
                );
            }
            if (this.repeatEndDayOfWeek != null) {
                properties["repeatEndDayOfWeek"] = this.repeatEndDayOfWeek?.Str(
                );
            }
            if (this.repeatBeginHour != null) {
                properties["repeatBeginHour"] = this.repeatBeginHour;
            }
            if (this.repeatEndHour != null) {
                properties["repeatEndHour"] = this.repeatEndHour;
            }
            if (this.relativeTriggerName != null) {
                properties["relativeTriggerName"] = this.relativeTriggerName;
            }

            return properties;
        }
    }
}
