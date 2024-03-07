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
using Gs2Cdk.Gs2Grade.Model;
using Gs2Cdk.Gs2Grade.Model.Enums;
using Gs2Cdk.Gs2Grade.Model.Options;

namespace Gs2Cdk.Gs2Grade.Model
{
    public class AcquireActionRate {
        private string name;
        private AcquireActionRateMode? mode;
        private double[] rates;
        private string[] bigRates;

        public AcquireActionRate(
            string name,
            AcquireActionRateMode mode,
            AcquireActionRateOptions options = null
        ){
            this.name = name;
            this.mode = mode;
            this.rates = options?.rates;
            this.bigRates = options?.bigRates;
        }

        public static AcquireActionRate ModeIsDouble(
            string name,
            double[] rates,
            AcquireActionRateModeIsDoubleOptions options = null
        ){
            return (new AcquireActionRate(
                name,
                AcquireActionRateMode.Double,
                new AcquireActionRateOptions {
                    rates = rates,
                }
            ));
        }

        public static AcquireActionRate ModeIsBig(
            string name,
            string[] bigRates,
            AcquireActionRateModeIsBigOptions options = null
        ){
            return (new AcquireActionRate(
                name,
                AcquireActionRateMode.Big,
                new AcquireActionRateOptions {
                    bigRates = bigRates,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.mode != null) {
                properties["mode"] = this.mode.Value.Str(
                );
            }
            if (this.rates != null) {
                properties["rates"] = this.rates;
            }
            if (this.bigRates != null) {
                properties["bigRates"] = this.bigRates;
            }

            return properties;
        }

        public static AcquireActionRate FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AcquireActionRate(
                (string)properties["name"],
                new Func<AcquireActionRateMode>(() =>
                {
                    return properties["mode"] switch {
                        AcquireActionRateMode e => e,
                        string s => AcquireActionRateModeExt.New(s),
                        _ => AcquireActionRateMode.Double
                    };
                })(),
                new AcquireActionRateOptions {
                    rates = properties.TryGetValue("rates", out var rates) ? new Func<double[]>(() =>
                    {
                        return rates switch {
                            double[] v => v.ToArray(),
                            List<double> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    bigRates = properties.TryGetValue("bigRates", out var bigRates) ? new Func<string[]>(() =>
                    {
                        return bigRates switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
