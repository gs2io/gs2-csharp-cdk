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
    public class TimeseriesValue {
        private string key;
        private double value;
        private string valueString;

        public TimeseriesValue(
            string key,
            double value,
            TimeseriesValueOptions options = null
        ){
            this.key = key;
            this.value = value;
        }


        public TimeseriesValue(
            string key,
            string value,
            TimeseriesValueOptions options = null
        ){
            this.key = key;
            this.valueString = value;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.key != null) {
                properties["key"] = this.key;
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }

            return properties;
        }

        public static TimeseriesValue FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TimeseriesValue(
                properties.TryGetValue("key", out var key) ? new Func<string>(() =>
                {
                    return (string) key;
                })() : default,
                properties.TryGetValue("value", out var value) ? new Func<double>(() =>
                {
                    return value switch {
                        double v => v,
                        string v => double.Parse(v),
                        _ => 0
                    };
                })() : default,
                new TimeseriesValueOptions {
                }
            );

            return model;
        }
    }
}
