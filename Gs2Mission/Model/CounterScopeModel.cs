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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Model.Enums;
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class CounterScopeModel {
        private CounterScopeModelScopeType? scopeType;
        private CounterScopeModelResetType? resetType;
        private int? resetDayOfMonth;
        private string resetDayOfMonthString;
        private CounterScopeModelResetDayOfWeek? resetDayOfWeek;
        private int? resetHour;
        private string resetHourString;
        private string conditionName;
        private VerifyAction condition;
        private long? anchorTimestamp;
        private string anchorTimestampString;
        private int? days;
        private string daysString;

        public CounterScopeModel(
            CounterScopeModelScopeType scopeType,
            CounterScopeModelOptions options = null
        ){
            this.scopeType = scopeType;
            this.resetType = options?.resetType;
            this.resetDayOfMonth = options?.resetDayOfMonth;
            this.resetDayOfWeek = options?.resetDayOfWeek;
            this.resetHour = options?.resetHour;
            this.conditionName = options?.conditionName;
            this.condition = options?.condition;
            this.anchorTimestamp = options?.anchorTimestamp;
            this.days = options?.days;
        }

        public static CounterScopeModel ScopeTypeIsResetTiming(
            CounterScopeModelResetType resetType,
            CounterScopeModelScopeTypeIsResetTimingOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelScopeType.ResetTiming,
                new CounterScopeModelOptions {
                    resetType = resetType,
                }
            ));
        }

        public static CounterScopeModel ScopeTypeIsVerifyAction(
            string conditionName,
            VerifyAction condition,
            CounterScopeModelScopeTypeIsVerifyActionOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelScopeType.VerifyAction,
                new CounterScopeModelOptions {
                    conditionName = conditionName,
                    condition = condition,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsNotReset(
            CounterScopeModelScopeType scopeType,
            CounterScopeModelResetTypeIsNotResetOptions options = null
        ){
            return (new CounterScopeModel(
                scopeType,
                new CounterScopeModelOptions {
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsDaily(
            CounterScopeModelScopeType scopeType,
            int? resetHour,
            CounterScopeModelResetTypeIsDailyOptions options = null
        ){
            return (new CounterScopeModel(
                scopeType,
                new CounterScopeModelOptions {
                    resetHour = resetHour,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsWeekly(
            CounterScopeModelScopeType scopeType,
            CounterScopeModelResetDayOfWeek resetDayOfWeek,
            int? resetHour,
            CounterScopeModelResetTypeIsWeeklyOptions options = null
        ){
            return (new CounterScopeModel(
                scopeType,
                new CounterScopeModelOptions {
                    resetDayOfWeek = resetDayOfWeek,
                    resetHour = resetHour,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsMonthly(
            CounterScopeModelScopeType scopeType,
            int? resetDayOfMonth,
            int? resetHour,
            CounterScopeModelResetTypeIsMonthlyOptions options = null
        ){
            return (new CounterScopeModel(
                scopeType,
                new CounterScopeModelOptions {
                    resetDayOfMonth = resetDayOfMonth,
                    resetHour = resetHour,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsDays(
            CounterScopeModelScopeType scopeType,
            long? anchorTimestamp,
            int? days,
            CounterScopeModelResetTypeIsDaysOptions options = null
        ){
            return (new CounterScopeModel(
                scopeType,
                new CounterScopeModelOptions {
                    anchorTimestamp = anchorTimestamp,
                    days = days,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.scopeType != null) {
                properties["scopeType"] = this.scopeType.Value.Str(
                );
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
            if (this.conditionName != null) {
                properties["conditionName"] = this.conditionName;
            }
            if (this.condition != null) {
                properties["condition"] = this.condition?.Properties(
                );
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

        public static CounterScopeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CounterScopeModel(
                properties.TryGetValue("scopeType", out var scopeType) ? new Func<CounterScopeModelScopeType>(() =>
                {
                    return scopeType switch {
                        CounterScopeModelScopeType e => e,
                        string s => CounterScopeModelScopeTypeExt.New(s),
                        _ => CounterScopeModelScopeType.ResetTiming
                    };
                })() : default,
                new CounterScopeModelOptions {
                    resetType = properties.TryGetValue("resetType", out var resetType) ? CounterScopeModelResetTypeExt.New(resetType as string) : null,
                    resetDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetDayOfMonth", out var resetDayOfMonth) ? resetDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    resetDayOfWeek = properties.TryGetValue("resetDayOfWeek", out var resetDayOfWeek) ? CounterScopeModelResetDayOfWeekExt.New(resetDayOfWeek as string) : null,
                    resetHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetHour", out var resetHour) ? resetHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    conditionName = properties.TryGetValue("conditionName", out var conditionName) ? (string)conditionName : null,
                    condition = properties.TryGetValue("condition", out var condition) ? new Func<VerifyAction>(() =>
                    {
                        return condition switch {
                            VerifyAction v => v,
                            Dictionary<string, object> v => VerifyAction.FromProperties(v),
                            _ => null
                        };
                    })() : null,
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
