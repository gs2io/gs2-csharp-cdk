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
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class TimeseriesPoint {
        private long timestamp;
        private string timestampString;
        private TimeseriesValue[] values;

        public TimeseriesPoint(
            long timestamp,
            TimeseriesPointOptions options = null
        ){
            this.timestamp = timestamp;
            this.values = options?.values;
        }


        public TimeseriesPoint(
            string timestamp,
            TimeseriesPointOptions options = null
        ){
            this.timestampString = timestamp;
            this.values = options?.values;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.timestampString != null) {
                properties["timestamp"] = this.timestampString;
            } else {
                if (this.timestamp != null) {
                    properties["timestamp"] = this.timestamp;
                }
            }
            if (this.values != null) {
                properties["values"] = this.values.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static TimeseriesPoint FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TimeseriesPoint(
                properties.TryGetValue("timestamp", out var timestamp) ? new Func<long>(() =>
                {
                    return timestamp switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new TimeseriesPointOptions {
                    values = properties.TryGetValue("values", out var values) ? new Func<TimeseriesValue[]>(() =>
                    {
                        return values switch {
                            TimeseriesValue[] v => v,
                            List<TimeseriesValue> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(TimeseriesValue.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(TimeseriesValue.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
