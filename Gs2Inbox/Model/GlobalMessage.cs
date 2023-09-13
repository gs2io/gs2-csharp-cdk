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
using Gs2Cdk.Gs2Inbox.Model;
using Gs2Cdk.Gs2Inbox.Model.Options;

namespace Gs2Cdk.Gs2Inbox.Model
{
    public class GlobalMessage {
        private string name;
        private string metadata;
        private AcquireAction[] readAcquireActions;
        private TimeSpan_ expiresTimeSpan;
        private long? expiresAt;

        public GlobalMessage(
            string name,
            string metadata,
            GlobalMessageOptions options = null
        ){
            this.name = name;
            this.metadata = metadata;
            this.readAcquireActions = options?.readAcquireActions;
            this.expiresTimeSpan = options?.expiresTimeSpan;
            this.expiresAt = options?.expiresAt;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.readAcquireActions != null) {
                properties["readAcquireActions"] = this.readAcquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.expiresTimeSpan != null) {
                properties["expiresTimeSpan"] = this.expiresTimeSpan?.Properties(
                );
            }
            if (this.expiresAt != null) {
                properties["expiresAt"] = this.expiresAt;
            }

            return properties;
        }

        public static GlobalMessage FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GlobalMessage(
                (string)properties["name"],
                (string)properties["metadata"],
                new GlobalMessageOptions {
                    readAcquireActions = properties.TryGetValue("readAcquireActions", out var readAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return readAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    expiresTimeSpan = properties.TryGetValue("expiresTimeSpan", out var expiresTimeSpan) ? new Func<TimeSpan_>(() =>
                    {
                        return expiresTimeSpan switch {
                            TimeSpan_ v => v,
                            Dictionary<string, object> v => TimeSpan_.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    expiresAt = properties.TryGetValue("expiresAt", out var expiresAt) ? (long?)expiresAt : null
                }
            );

            return model;
        }
    }
}
