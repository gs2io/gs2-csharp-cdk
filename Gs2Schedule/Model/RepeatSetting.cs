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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.Model.Enums;
using Gs2Cdk.Gs2Schedule.Model.Options;

namespace Gs2Cdk.Gs2Schedule.Model
{
    public class RepeatSetting {
        private RepeatSettingRepeatType? repeatType;
        private int? beginDayOfMonth;
        private int? endDayOfMonth;
        private RepeatSettingBeginDayOfWeek? beginDayOfWeek;
        private RepeatSettingEndDayOfWeek? endDayOfWeek;
        private int? beginHour;
        private int? endHour;

        public RepeatSetting(
            RepeatSettingRepeatType repeatType,
            RepeatSettingOptions options = null
        ){
            this.repeatType = repeatType;
            this.beginDayOfMonth = options?.beginDayOfMonth;
            this.endDayOfMonth = options?.endDayOfMonth;
            this.beginDayOfWeek = options?.beginDayOfWeek;
            this.endDayOfWeek = options?.endDayOfWeek;
            this.beginHour = options?.beginHour;
            this.endHour = options?.endHour;
        }

        public static RepeatSetting RepeatTypeIsAlways(
            RepeatSettingRepeatTypeIsAlwaysOptions options = null
        ){
            return (new RepeatSetting(
                RepeatSettingRepeatType.Always,
                new RepeatSettingOptions {
                }
            ));
        }

        public static RepeatSetting RepeatTypeIsDaily(
            int? beginHour,
            int? endHour,
            RepeatSettingRepeatTypeIsDailyOptions options = null
        ){
            return (new RepeatSetting(
                RepeatSettingRepeatType.Daily,
                new RepeatSettingOptions {
                    beginHour = beginHour,
                    endHour = endHour,
                }
            ));
        }

        public static RepeatSetting RepeatTypeIsWeekly(
            RepeatSettingBeginDayOfWeek beginDayOfWeek,
            RepeatSettingEndDayOfWeek endDayOfWeek,
            int? beginHour,
            int? endHour,
            RepeatSettingRepeatTypeIsWeeklyOptions options = null
        ){
            return (new RepeatSetting(
                RepeatSettingRepeatType.Weekly,
                new RepeatSettingOptions {
                    beginDayOfWeek = beginDayOfWeek,
                    endDayOfWeek = endDayOfWeek,
                    beginHour = beginHour,
                    endHour = endHour,
                }
            ));
        }

        public static RepeatSetting RepeatTypeIsMonthly(
            int? beginDayOfMonth,
            int? endDayOfMonth,
            int? beginHour,
            int? endHour,
            RepeatSettingRepeatTypeIsMonthlyOptions options = null
        ){
            return (new RepeatSetting(
                RepeatSettingRepeatType.Monthly,
                new RepeatSettingOptions {
                    beginDayOfMonth = beginDayOfMonth,
                    endDayOfMonth = endDayOfMonth,
                    beginHour = beginHour,
                    endHour = endHour,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.repeatType != null) {
                properties["repeatType"] = this.repeatType.Value.Str(
                );
            }
            if (this.beginDayOfMonth != null) {
                properties["beginDayOfMonth"] = this.beginDayOfMonth;
            }
            if (this.endDayOfMonth != null) {
                properties["endDayOfMonth"] = this.endDayOfMonth;
            }
            if (this.beginDayOfWeek != null) {
                properties["beginDayOfWeek"] = this.beginDayOfWeek.Value.Str(
                );
            }
            if (this.endDayOfWeek != null) {
                properties["endDayOfWeek"] = this.endDayOfWeek.Value.Str(
                );
            }
            if (this.beginHour != null) {
                properties["beginHour"] = this.beginHour;
            }
            if (this.endHour != null) {
                properties["endHour"] = this.endHour;
            }

            return properties;
        }

        public static RepeatSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RepeatSetting(
                new Func<RepeatSettingRepeatType>(() =>
                {
                    return properties["repeatType"] switch {
                        RepeatSettingRepeatType e => e,
                        string s => RepeatSettingRepeatTypeExt.New(s),
                        _ => RepeatSettingRepeatType.Always
                    };
                })(),
                new RepeatSettingOptions {
                    beginDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("beginDayOfMonth", out var beginDayOfMonth) ? beginDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    endDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("endDayOfMonth", out var endDayOfMonth) ? endDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    beginDayOfWeek = properties.TryGetValue("beginDayOfWeek", out var beginDayOfWeek) ? RepeatSettingBeginDayOfWeekExt.New(beginDayOfWeek as string) : RepeatSettingBeginDayOfWeek.Sunday,
                    endDayOfWeek = properties.TryGetValue("endDayOfWeek", out var endDayOfWeek) ? RepeatSettingEndDayOfWeekExt.New(endDayOfWeek as string) : RepeatSettingEndDayOfWeek.Sunday,
                    beginHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("beginHour", out var beginHour) ? beginHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    endHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("endHour", out var endHour) ? endHour switch {
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
