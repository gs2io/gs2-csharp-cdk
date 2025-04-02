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
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Model.Options;

namespace Gs2Cdk.Gs2Exchange.Model
{
    public class LogCost {
        private double base_;
        private string baseString;
        private double[] adds;
        private double[] subs;

        public LogCost(
            double base_,
            double[] adds,
            LogCostOptions options = null
        ){
            this.base_ = base_;
            this.adds = adds;
            this.subs = options?.subs;
        }


        public LogCost(
            string base_,
            double[] adds,
            LogCostOptions options = null
        ){
            this.baseString = base_;
            this.adds = adds;
            this.subs = options?.subs;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.baseString != null) {
                properties["base"] = this.baseString;
            } else {
                if (this.base_ != null) {
                    properties["base"] = this.base_;
                }
            }
            if (this.adds != null) {
                properties["adds"] = this.adds;
            }
            if (this.subs != null) {
                properties["subs"] = this.subs;
            }

            return properties;
        }

        public static LogCost FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new LogCost(
                properties.TryGetValue("base", out var base_) ? new Func<double>(() =>
                {
                    return base_ switch {
                        double v => v,
                        string v => double.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("adds", out var adds) ? new Func<double[]>(() =>
                {
                    return adds switch {
                        double[] v => v.ToArray(),
                        List<double> v => v.ToArray(),
                        object[] v => v.Select(v2 => double.Parse(v2?.ToString())).ToArray(),
                        { } v => new []{ double.Parse(v.ToString()) },
                        _ => null
                    };
                })() : null,
                new LogCostOptions {
                    subs = properties.TryGetValue("subs", out var subs) ? new Func<double[]>(() =>
                    {
                        return subs switch {
                            double[] v => v.ToArray(),
                            List<double> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
