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
        private CounterScopeModelResetType? resetType;
        private int? resetDayOfMonth;
        private CounterScopeModelResetDayOfWeek? resetDayOfWeek;
        private int? resetHour;

        public CounterScopeModel(
            CounterScopeModelResetType resetType,
            CounterScopeModelOptions options = null
        ){
            this.resetType = resetType;
            this.resetDayOfMonth = options?.resetDayOfMonth;
            this.resetDayOfWeek = options?.resetDayOfWeek;
            this.resetHour = options?.resetHour;
        }

        public static CounterScopeModel ResetTypeIsNotReset(
            CounterScopeModelResetTypeIsNotResetOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelResetType.NotReset,
                new CounterScopeModelOptions {
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsDaily(
            int? resetHour,
            CounterScopeModelResetTypeIsDailyOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelResetType.Daily,
                new CounterScopeModelOptions {
                    resetHour = resetHour,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsWeekly(
            CounterScopeModelResetDayOfWeek resetDayOfWeek,
            int? resetHour,
            CounterScopeModelResetTypeIsWeeklyOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelResetType.Weekly,
                new CounterScopeModelOptions {
                    resetDayOfWeek = resetDayOfWeek,
                    resetHour = resetHour,
                }
            ));
        }

        public static CounterScopeModel ResetTypeIsMonthly(
            int? resetDayOfMonth,
            int? resetHour,
            CounterScopeModelResetTypeIsMonthlyOptions options = null
        ){
            return (new CounterScopeModel(
                CounterScopeModelResetType.Monthly,
                new CounterScopeModelOptions {
                    resetDayOfMonth = resetDayOfMonth,
                    resetHour = resetHour,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.resetDayOfMonth != null) {
                properties["resetDayOfMonth"] = this.resetDayOfMonth;
            }
            if (this.resetDayOfWeek != null) {
                properties["resetDayOfWeek"] = this.resetDayOfWeek.Value.Str(
                );
            }
            if (this.resetHour != null) {
                properties["resetHour"] = this.resetHour;
            }

            return properties;
        }

        public static CounterScopeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CounterScopeModel(
                new Func<CounterScopeModelResetType>(() =>
                {
                    return properties["resetType"] switch {
                        CounterScopeModelResetType e => e,
                        string s => CounterScopeModelResetTypeExt.New(s),
                        _ => CounterScopeModelResetType.NotReset
                    };
                })(),
                new CounterScopeModelOptions {
                    resetDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetDayOfMonth", out var resetDayOfMonth) ? resetDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    resetDayOfWeek = properties.TryGetValue("resetDayOfWeek", out var resetDayOfWeek) ? CounterScopeModelResetDayOfWeekExt.New(resetDayOfWeek as string) : CounterScopeModelResetDayOfWeek.Sunday,
                    resetHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetHour", out var resetHour) ? resetHour switch {
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
