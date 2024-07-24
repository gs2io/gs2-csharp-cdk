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
using Gs2Cdk.Gs2Script.Model;
using Gs2Cdk.Gs2Script.Model.Options;

namespace Gs2Cdk.Gs2Script.Model
{
    public class RandomStatus {
        private long seed;
        private string seedString;
        private RandomUsed[] used;

        public RandomStatus(
            long seed,
            RandomStatusOptions options = null
        ){
            this.seed = seed;
            this.used = options?.used;
        }


        public RandomStatus(
            string seed,
            RandomStatusOptions options = null
        ){
            this.seedString = seed;
            this.used = options?.used;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.seedString != null) {
                properties["seed"] = this.seedString;
            } else {
                if (this.seed != null) {
                    properties["seed"] = this.seed;
                }
            }
            if (this.used != null) {
                properties["used"] = this.used.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static RandomStatus FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RandomStatus(
                properties.TryGetValue("seed", out var seed) ? new Func<long>(() =>
                {
                    return seed switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new RandomStatusOptions {
                    used = properties.TryGetValue("used", out var used) ? new Func<RandomUsed[]>(() =>
                    {
                        return used switch {
                            RandomUsed[] v => v,
                            List<RandomUsed> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(RandomUsed.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(RandomUsed.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
