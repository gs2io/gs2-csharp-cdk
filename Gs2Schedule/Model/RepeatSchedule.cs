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
using Gs2Cdk.Gs2Schedule.Model.Options;

namespace Gs2Cdk.Gs2Schedule.Model
{
    public class RepeatSchedule {
        private int repeatCount;
        private string repeatCountString;
        private long? currentRepeatStartAt;
        private string currentRepeatStartAtString;
        private long? currentRepeatEndAt;
        private string currentRepeatEndAtString;
        private long? lastRepeatEndAt;
        private string lastRepeatEndAtString;
        private long? nextRepeatStartAt;
        private string nextRepeatStartAtString;

        public RepeatSchedule(
            int repeatCount,
            RepeatScheduleOptions options = null
        ){
            this.repeatCount = repeatCount;
            this.currentRepeatStartAt = options?.currentRepeatStartAt;
            this.currentRepeatEndAt = options?.currentRepeatEndAt;
            this.lastRepeatEndAt = options?.lastRepeatEndAt;
            this.nextRepeatStartAt = options?.nextRepeatStartAt;
        }


        public RepeatSchedule(
            string repeatCount,
            RepeatScheduleOptions options = null
        ){
            this.repeatCountString = repeatCount;
            this.currentRepeatStartAt = options?.currentRepeatStartAt;
            this.currentRepeatStartAtString = options?.currentRepeatStartAtString;
            this.currentRepeatEndAt = options?.currentRepeatEndAt;
            this.currentRepeatEndAtString = options?.currentRepeatEndAtString;
            this.lastRepeatEndAt = options?.lastRepeatEndAt;
            this.lastRepeatEndAtString = options?.lastRepeatEndAtString;
            this.nextRepeatStartAt = options?.nextRepeatStartAt;
            this.nextRepeatStartAtString = options?.nextRepeatStartAtString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.repeatCountString != null) {
                properties["repeatCount"] = this.repeatCountString;
            } else {
                if (this.repeatCount != null) {
                    properties["repeatCount"] = this.repeatCount;
                }
            }
            if (this.currentRepeatStartAtString != null) {
                properties["currentRepeatStartAt"] = this.currentRepeatStartAtString;
            } else {
                if (this.currentRepeatStartAt != null) {
                    properties["currentRepeatStartAt"] = this.currentRepeatStartAt;
                }
            }
            if (this.currentRepeatEndAtString != null) {
                properties["currentRepeatEndAt"] = this.currentRepeatEndAtString;
            } else {
                if (this.currentRepeatEndAt != null) {
                    properties["currentRepeatEndAt"] = this.currentRepeatEndAt;
                }
            }
            if (this.lastRepeatEndAtString != null) {
                properties["lastRepeatEndAt"] = this.lastRepeatEndAtString;
            } else {
                if (this.lastRepeatEndAt != null) {
                    properties["lastRepeatEndAt"] = this.lastRepeatEndAt;
                }
            }
            if (this.nextRepeatStartAtString != null) {
                properties["nextRepeatStartAt"] = this.nextRepeatStartAtString;
            } else {
                if (this.nextRepeatStartAt != null) {
                    properties["nextRepeatStartAt"] = this.nextRepeatStartAt;
                }
            }

            return properties;
        }

        public static RepeatSchedule FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RepeatSchedule(
                properties.TryGetValue("repeatCount", out var repeatCount) ? new Func<int>(() =>
                {
                    return repeatCount switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new RepeatScheduleOptions {
                    currentRepeatStartAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("currentRepeatStartAt", out var currentRepeatStartAt) ? currentRepeatStartAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    currentRepeatEndAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("currentRepeatEndAt", out var currentRepeatEndAt) ? currentRepeatEndAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    lastRepeatEndAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("lastRepeatEndAt", out var lastRepeatEndAt) ? lastRepeatEndAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    nextRepeatStartAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("nextRepeatStartAt", out var nextRepeatStartAt) ? nextRepeatStartAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
