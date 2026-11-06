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
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Model.Options;

namespace Gs2Cdk.Gs2Realtime.Model
{
    public class StateMachineSetting {
        private string namespaceId;
        private long? version;
        private string versionString;

        public StateMachineSetting(
            string namespaceId,
            StateMachineSettingOptions options = null
        ){
            this.namespaceId = namespaceId;
            this.version = options?.version;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceId != null) {
                properties["namespaceId"] = this.namespaceId;
            }
            if (this.versionString != null) {
                properties["version"] = this.versionString;
            } else {
                if (this.version != null) {
                    properties["version"] = this.version;
                }
            }

            return properties;
        }

        public static StateMachineSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new StateMachineSetting(
                properties.TryGetValue("namespaceId", out var namespaceId) ? new Func<string>(() =>
                {
                    return (string) namespaceId;
                })() : default,
                new StateMachineSettingOptions {
                    version = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("version", out var version) ? version switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
