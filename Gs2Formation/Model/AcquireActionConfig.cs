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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.Model.Options;

namespace Gs2Cdk.Gs2Formation.Model
{
    public class AcquireActionConfig {
        private string name;
        private Config[] config;

        public AcquireActionConfig(
            string name,
            AcquireActionConfigOptions options = null
        ){
            this.name = name;
            this.config = options?.config;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static AcquireActionConfig FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AcquireActionConfig(
                (string)properties["name"],
                new AcquireActionConfigOptions {
                    config = properties.TryGetValue("config", out var config) ? new Func<Config[]>(() =>
                    {
                        return config switch {
                            Config[] v => v,
                            List<Config> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(Config.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(Config.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
