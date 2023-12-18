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
using Gs2Cdk.Gs2AdReward.Model;
using Gs2Cdk.Gs2AdReward.Model.Options;

namespace Gs2Cdk.Gs2AdReward.Model
{
    public class AdMob {
        private string[] allowAdUnitIds;

        public AdMob(
            string[] allowAdUnitIds,
            AdMobOptions options = null
        ){
            this.allowAdUnitIds = allowAdUnitIds;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.allowAdUnitIds != null) {
                properties["allowAdUnitIds"] = this.allowAdUnitIds;
            }

            return properties;
        }

        public static AdMob FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AdMob(
                new Func<string[]>(() =>
                {
                    return properties["allowAdUnitIds"] switch {
                        string[] v => v.ToArray(),
                        List<string> v => v.ToArray(),
                        object[] v => v.Select(v2 => v2?.ToString()).ToArray(),
                        { } v => new []{ v.ToString() },
                        _ => null
                    };
                })(),
                new AdMobOptions {
                }
            );

            return model;
        }
    }
}
