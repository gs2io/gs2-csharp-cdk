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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.Model.Enums;
using Gs2Cdk.Gs2Limit.Model.Options;

namespace Gs2Cdk.Gs2Limit.Model
{
    public class LimitModel {
        private string name;
        private LimitModelResetType? resetType;
        private string metadata;
        private int? resetDayOfMonth;
        private string resetDayOfMonthString;
        private LimitModelResetDayOfWeek? resetDayOfWeek;
        private int? resetHour;
        private string resetHourString;
        private long? anchorTimestamp;
        private string anchorTimestampString;
        private int? days;
        private string daysString;

        public LimitModel(
            string name,
            LimitModelResetType resetType,
            LimitModelOptions options = null
        ){
            this.name = name;
            this.resetType = resetType;
            this.metadata = options?.metadata;
            this.resetDayOfMonth = options?.resetDayOfMonth;
            this.resetDayOfWeek = options?.resetDayOfWeek;
            this.resetHour = options?.resetHour;
            this.anchorTimestamp = options?.anchorTimestamp;
            this.days = options?.days;
        }

        public static LimitModel ResetTypeIsNotReset(
            string name,
            LimitModelResetTypeIsNotResetOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.NotReset,
                new LimitModelOptions {
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsDaily(
            string name,
            int? resetHour,
            LimitModelResetTypeIsDailyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Daily,
                new LimitModelOptions {
                    resetHour = resetHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsWeekly(
            string name,
            LimitModelResetDayOfWeek resetDayOfWeek,
            int? resetHour,
            LimitModelResetTypeIsWeeklyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Weekly,
                new LimitModelOptions {
                    resetDayOfWeek = resetDayOfWeek,
                    resetHour = resetHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsMonthly(
            string name,
            int? resetDayOfMonth,
            int? resetHour,
            LimitModelResetTypeIsMonthlyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Monthly,
                new LimitModelOptions {
                    resetDayOfMonth = resetDayOfMonth,
                    resetHour = resetHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsDays(
            string name,
            long? anchorTimestamp,
            int? days,
            LimitModelResetTypeIsDaysOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Days,
                new LimitModelOptions {
                    anchorTimestamp = anchorTimestamp,
                    days = days,
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
            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.resetDayOfMonthString != null) {
                properties["resetDayOfMonth"] = this.resetDayOfMonthString;
            } else {
                if (this.resetDayOfMonth != null) {
                    properties["resetDayOfMonth"] = this.resetDayOfMonth;
                }
            }
            if (this.resetDayOfWeek != null) {
                properties["resetDayOfWeek"] = this.resetDayOfWeek.Value.Str(
                );
            }
            if (this.resetHourString != null) {
                properties["resetHour"] = this.resetHourString;
            } else {
                if (this.resetHour != null) {
                    properties["resetHour"] = this.resetHour;
                }
            }
            if (this.anchorTimestampString != null) {
                properties["anchorTimestamp"] = this.anchorTimestampString;
            } else {
                if (this.anchorTimestamp != null) {
                    properties["anchorTimestamp"] = this.anchorTimestamp;
                }
            }
            if (this.daysString != null) {
                properties["days"] = this.daysString;
            } else {
                if (this.days != null) {
                    properties["days"] = this.days;
                }
            }

            return properties;
        }

        public static LimitModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new LimitModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("resetType", out var resetType) ? new Func<LimitModelResetType>(() =>
                {
                    return resetType switch {
                        LimitModelResetType e => e,
                        string s => LimitModelResetTypeExt.New(s),
                        _ => LimitModelResetType.NotReset
                    };
                })() : default,
                new LimitModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    resetDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetDayOfMonth", out var resetDayOfMonth) ? resetDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    resetDayOfWeek = properties.TryGetValue("resetDayOfWeek", out var resetDayOfWeek) ? LimitModelResetDayOfWeekExt.New(resetDayOfWeek as string) : null,
                    resetHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetHour", out var resetHour) ? resetHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    anchorTimestamp = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("anchorTimestamp", out var anchorTimestamp) ? anchorTimestamp switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    days = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("days", out var days) ? days switch {
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
