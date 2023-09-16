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
    public class UnityAd {
        private string[] keys;

        public UnityAd(
            UnityAdOptions options = null
        ){
            this.keys = options?.keys;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.keys != null) {
                properties["keys"] = this.keys;
            }

            return properties;
        }

        public static UnityAd FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnityAd(
                new UnityAdOptions {
                    keys = properties.TryGetValue("keys", out var keys) ? new Func<string[]>(() =>
                    {
                        return keys switch {
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
