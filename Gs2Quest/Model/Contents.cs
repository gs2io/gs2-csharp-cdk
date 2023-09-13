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
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.Model.Options;

namespace Gs2Cdk.Gs2Quest.Model
{
    public class Contents {
        private int? weight;
        private string metadata;
        private AcquireAction[] completeAcquireActions;

        public Contents(
            int? weight,
            ContentsOptions options = null
        ){
            this.weight = weight;
            this.metadata = options?.metadata;
            this.completeAcquireActions = options?.completeAcquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.completeAcquireActions != null) {
                properties["completeAcquireActions"] = this.completeAcquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.weight != null) {
                properties["weight"] = this.weight;
            }

            return properties;
        }

        public static Contents FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Contents(
                (int?)properties["weight"],
                new ContentsOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    completeAcquireActions = properties.TryGetValue("completeAcquireActions", out var completeAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return completeAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
