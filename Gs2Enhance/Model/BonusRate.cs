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
using Gs2Cdk.Gs2Enhance.Model;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class BonusRate {
        private float? rate;
        private string rateString;
        private int? weight;
        private string weightString;

        public BonusRate(
            float? rate,
            int? weight,
            BonusRateOptions options = null
        ){
            this.rate = rate;
            this.weight = weight;
        }


        public BonusRate(
            string rate,
            string weight,
            BonusRateOptions options = null
        ){
            this.rateString = rate;
            this.weightString = weight;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.rateString != null) {
                properties["rate"] = this.rateString;
            } else {
                if (this.rate != null) {
                    properties["rate"] = this.rate;
                }
            }
            if (this.weightString != null) {
                properties["weight"] = this.weightString;
            } else {
                if (this.weight != null) {
                    properties["weight"] = this.weight;
                }
            }

            return properties;
        }

        public static BonusRate FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BonusRate(
                properties.TryGetValue("rate", out var rate) ? new Func<float?>(() =>
                {
                    return rate switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("weight", out var weight) ? new Func<int?>(() =>
                {
                    return weight switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new BonusRateOptions {
                }
            );

            return model;
        }
    }
}
