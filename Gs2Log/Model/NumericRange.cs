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
    public class NumericRange {
        private double min;
        private string minString;
        private double max;
        private string maxString;

        public NumericRange(
            double min,
            double max,
            NumericRangeOptions options = null
        ){
            this.min = min;
            this.max = max;
        }


        public NumericRange(
            string min,
            string max,
            NumericRangeOptions options = null
        ){
            this.minString = min;
            this.maxString = max;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.minString != null) {
                properties["min"] = this.minString;
            } else {
                if (this.min != null) {
                    properties["min"] = this.min;
                }
            }
            if (this.maxString != null) {
                properties["max"] = this.maxString;
            } else {
                if (this.max != null) {
                    properties["max"] = this.max;
                }
            }

            return properties;
        }

        public static NumericRange FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new NumericRange(
                properties.TryGetValue("min", out var min) ? new Func<double>(() =>
                {
                    return min switch {
                        double v => v,
                        string v => double.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("max", out var max) ? new Func<double>(() =>
                {
                    return max switch {
                        double v => v,
                        string v => double.Parse(v),
                        _ => 0
                    };
                })() : default,
                new NumericRangeOptions {
                }
            );

            return model;
        }
    }
}
