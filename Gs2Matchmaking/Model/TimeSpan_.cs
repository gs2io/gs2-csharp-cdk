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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class TimeSpan_ {
        private int? days;
        private string daysString;
        private int? hours;
        private string hoursString;
        private int? minutes;
        private string minutesString;

        public TimeSpan_(
            int? days,
            int? hours,
            int? minutes,
            TimeSpanOptions options = null
        ){
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
        }


        public TimeSpan_(
            string days,
            string hours,
            string minutes,
            TimeSpanOptions options = null
        ){
            this.daysString = days;
            this.hoursString = hours;
            this.minutesString = minutes;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.daysString != null) {
                properties["days"] = this.daysString;
            } else {
                if (this.days != null) {
                    properties["days"] = this.days;
                }
            }
            if (this.hoursString != null) {
                properties["hours"] = this.hoursString;
            } else {
                if (this.hours != null) {
                    properties["hours"] = this.hours;
                }
            }
            if (this.minutesString != null) {
                properties["minutes"] = this.minutesString;
            } else {
                if (this.minutes != null) {
                    properties["minutes"] = this.minutes;
                }
            }

            return properties;
        }

        public static TimeSpan_ FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TimeSpan_(
                properties.TryGetValue("days", out var days) ? new Func<int?>(() =>
                {
                    return days switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("hours", out var hours) ? new Func<int?>(() =>
                {
                    return hours switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("minutes", out var minutes) ? new Func<int?>(() =>
                {
                    return minutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new TimeSpanOptions {
                }
            );

            return model;
        }
    }
}
