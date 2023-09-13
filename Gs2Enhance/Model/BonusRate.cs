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
        private int? weight;

        public BonusRate(
            float? rate,
            int? weight,
            BonusRateOptions options = null
        ){
            this.rate = rate;
            this.weight = weight;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.rate != null) {
                properties["rate"] = this.rate;
            }
            if (this.weight != null) {
                properties["weight"] = this.weight;
            }

            return properties;
        }

        public static BonusRate FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BonusRate(
                (float?)properties["rate"],
                (int?)properties["weight"],
                new BonusRateOptions {
                }
            );

            return model;
        }
    }
}
