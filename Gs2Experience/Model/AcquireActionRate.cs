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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class AcquireActionRate {
        private string name;
        private double[] rates;

        public AcquireActionRate(
            string name,
            double[] rates,
            AcquireActionRateOptions options = null
        ){
            this.name = name;
            this.rates = rates;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.rates != null) {
                properties["rates"] = this.rates;
            }

            return properties;
        }

        public static AcquireActionRate FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AcquireActionRate(
                (string)properties["name"],
                new Func<double[]>(() =>
                {
                    return properties["rates"] switch {
                        double[] v => v.ToArray(),
                        List<double> v => v.ToArray(),
                        _ => null
                    };
                })(),
                new AcquireActionRateOptions {
                }
            );

            return model;
        }
    }
}
