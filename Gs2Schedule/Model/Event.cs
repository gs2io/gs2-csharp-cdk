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
 *
 * deny overwrite
 */
using System;
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
        private RepeatSetting repeatSetting;
        private EventRepeatType? repeatType;
        private string metadata;
        private long? absoluteBegin;
        private string absoluteBeginString;
        private long? absoluteEnd;
        private string absoluteEndString;
        private string relativeTriggerName;
        private int? repeatBeginDayOfMonth;
        private string repeatBeginDayOfMonthString;
        private int? repeatEndDayOfMonth;
        private string repeatEndDayOfMonthString;
        private EventRepeatBeginDayOfWeek? repeatBeginDayOfWeek;
        private EventRepeatEndDayOfWeek? repeatEndDayOfWeek;
        private int? repeatBeginHour;
        private string repeatBeginHourString;
        private int? repeatEndHour;
        private string repeatEndHourString;

        public Event(
            string name,
            EventScheduleType scheduleType,
            RepeatSetting repeatSetting,
            EventOptions options = null
        ){
            this.name = name;
            this.scheduleType = scheduleType;
            this.repeatSetting = repeatSetting;
            this.repeatType = options?.repeatType;
            this.metadata = options?.metadata;
            this.absoluteBegin = options?.absoluteBegin;
            this.absoluteEnd = options?.absoluteEnd;
            this.relativeTriggerName = options?.relativeTriggerName;
            this.repeatBeginDayOfMonth = options?.repeatBeginDayOfMonth;
            this.repeatEndDayOfMonth = options?.repeatEndDayOfMonth;
            this.repeatBeginDayOfWeek = options?.repeatBeginDayOfWeek;
            this.repeatEndDayOfWeek = options?.repeatEndDayOfWeek;
            this.repeatBeginHour = options?.repeatBeginHour;
            this.repeatEndHour = options?.repeatEndHour;
        }

        public static Event ScheduleTypeIsAbsolute(
            string name,
            RepeatSetting repeatSetting,
            EventScheduleTypeIsAbsoluteOptions options = null
        ){
            return (new Event(
                name,
                EventScheduleType.Absolute,
                repeatSetting,
                new EventOptions {
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
                }
            ));
        }

        public static Event ScheduleTypeIsRelative(
            string name,
            RepeatSetting repeatSetting,
            string relativeTriggerName,
            EventScheduleTypeIsRelativeOptions options = null
        ){
            return (new Event(
                name,
                EventScheduleType.Relative,
                repeatSetting,
                new EventOptions {
                    relativeTriggerName = relativeTriggerName,
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
                }
            ));
        }

        public static Event RepeatTypeIsAlways(
            string name,
            EventScheduleType scheduleType,
            RepeatSetting repeatSetting,
            EventRepeatTypeIsAlwaysOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                repeatSetting,
                new EventOptions {
                    repeatType = EventRepeatType.Always,
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
                }
            ));
        }

        public static Event RepeatTypeIsDaily(
            string name,
            EventScheduleType scheduleType,
            RepeatSetting repeatSetting,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsDailyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                repeatSetting,
                new EventOptions {
                    repeatType = EventRepeatType.Daily,
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
                }
            ));
        }

        public static Event RepeatTypeIsWeekly(
            string name,
            EventScheduleType scheduleType,
            RepeatSetting repeatSetting,
            EventRepeatBeginDayOfWeek repeatBeginDayOfWeek,
            EventRepeatEndDayOfWeek repeatEndDayOfWeek,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsWeeklyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                repeatSetting,
                new EventOptions {
                    repeatType = EventRepeatType.Weekly,
                    repeatBeginDayOfWeek = repeatBeginDayOfWeek,
                    repeatEndDayOfWeek = repeatEndDayOfWeek,
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
                }
            ));
        }

        public static Event RepeatTypeIsMonthly(
            string name,
            EventScheduleType scheduleType,
            RepeatSetting repeatSetting,
            int? repeatBeginDayOfMonth,
            int? repeatEndDayOfMonth,
            int? repeatBeginHour,
            int? repeatEndHour,
            EventRepeatTypeIsMonthlyOptions options = null
        ){
            return (new Event(
                name,
                scheduleType,
                repeatSetting,
                new EventOptions {
                    repeatType = EventRepeatType.Monthly,
                    repeatBeginDayOfMonth = repeatBeginDayOfMonth,
                    repeatEndDayOfMonth = repeatEndDayOfMonth,
                    repeatBeginHour = repeatBeginHour,
                    repeatEndHour = repeatEndHour,
                    metadata = options?.metadata,
                    absoluteBegin = options?.absoluteBegin,
                    absoluteEnd = options?.absoluteEnd,
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
                properties["scheduleType"] = this.scheduleType.Value.Str(
                );
            }
            if (this.absoluteBeginString != null) {
                properties["absoluteBegin"] = this.absoluteBeginString;
            } else {
                if (this.absoluteBegin != null) {
                    properties["absoluteBegin"] = this.absoluteBegin;
                }
            }
            if (this.absoluteEndString != null) {
                properties["absoluteEnd"] = this.absoluteEndString;
            } else {
                if (this.absoluteEnd != null) {
                    properties["absoluteEnd"] = this.absoluteEnd;
                }
            }
            if (this.relativeTriggerName != null) {
                properties["relativeTriggerName"] = this.relativeTriggerName;
            }
            if (this.repeatSetting != null) {
                properties["repeatSetting"] = this.repeatSetting?.Properties(
                );
            }
            if (this.repeatType != null) {
                properties["repeatType"] = this.repeatType.Value.Str(
                );
            }
            if (this.repeatBeginDayOfMonthString != null) {
                properties["repeatBeginDayOfMonth"] = this.repeatBeginDayOfMonthString;
            } else {
                if (this.repeatBeginDayOfMonth != null) {
                    properties["repeatBeginDayOfMonth"] = this.repeatBeginDayOfMonth;
                }
            }
            if (this.repeatEndDayOfMonthString != null) {
                properties["repeatEndDayOfMonth"] = this.repeatEndDayOfMonthString;
            } else {
                if (this.repeatEndDayOfMonth != null) {
                    properties["repeatEndDayOfMonth"] = this.repeatEndDayOfMonth;
                }
            }
            if (this.repeatBeginDayOfWeek != null) {
                properties["repeatBeginDayOfWeek"] = this.repeatBeginDayOfWeek.Value.Str(
                );
            }
            if (this.repeatEndDayOfWeek != null) {
                properties["repeatEndDayOfWeek"] = this.repeatEndDayOfWeek.Value.Str(
                );
            }
            if (this.repeatBeginHourString != null) {
                properties["repeatBeginHour"] = this.repeatBeginHourString;
            } else {
                if (this.repeatBeginHour != null) {
                    properties["repeatBeginHour"] = this.repeatBeginHour;
                }
            }
            if (this.repeatEndHourString != null) {
                properties["repeatEndHour"] = this.repeatEndHourString;
            } else {
                if (this.repeatEndHour != null) {
                    properties["repeatEndHour"] = this.repeatEndHour;
                }
            }

            return properties;
        }

        public static Event FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Event(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("scheduleType", out var scheduleType) ? new Func<EventScheduleType>(() =>
                {
                    return scheduleType switch {
                        EventScheduleType e => e,
                        string s => EventScheduleTypeExt.New(s),
                        _ => EventScheduleType.Absolute
                    };
                })() : default,
                properties.TryGetValue("repeatSetting", out var repeatSetting) ? new Func<RepeatSetting>(() =>
                {
                    return repeatSetting switch {
                        RepeatSetting v => v,
                        RepeatSetting[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => RepeatSetting.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? RepeatSetting.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                new EventOptions {
                    repeatType = new Func<EventRepeatType?>(() =>
                    {
                        return properties.TryGetValue("repeatType", out var repeatType) ? new Func<EventRepeatType?>(() =>
                        {
                            return repeatType switch {
                                EventRepeatType e => e,
                                string s => EventRepeatTypeExt.New(s),
                                _ => null
                            };
                        })() : null;
                    })(),
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    absoluteBegin = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("absoluteBegin", out var absoluteBegin) ? absoluteBegin switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    absoluteEnd = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("absoluteEnd", out var absoluteEnd) ? absoluteEnd switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    relativeTriggerName = properties.TryGetValue("relativeTriggerName", out var relativeTriggerName) ? (string)relativeTriggerName : null,
                    repeatBeginDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("repeatBeginDayOfMonth", out var repeatBeginDayOfMonth) ? repeatBeginDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    repeatEndDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("repeatEndDayOfMonth", out var repeatEndDayOfMonth) ? repeatEndDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    repeatBeginDayOfWeek = properties.TryGetValue("repeatBeginDayOfWeek", out var repeatBeginDayOfWeek) ? EventRepeatBeginDayOfWeekExt.New(repeatBeginDayOfWeek as string) : null,
                    repeatEndDayOfWeek = properties.TryGetValue("repeatEndDayOfWeek", out var repeatEndDayOfWeek) ? EventRepeatEndDayOfWeekExt.New(repeatEndDayOfWeek as string) : null,
                    repeatBeginHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("repeatBeginHour", out var repeatBeginHour) ? repeatBeginHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    repeatEndHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("repeatEndHour", out var repeatEndHour) ? repeatEndHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
