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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class RandomDisplayItemModel {
        private string name;
        private AcquireAction[] acquireActions;
        private int stock;
        private int weight;
        private string metadata;
        private ConsumeAction[] consumeActions;

        public RandomDisplayItemModel(
            string name,
            AcquireAction[] acquireActions,
            int stock,
            int weight,
            RandomDisplayItemModelOptions options = null
        ){
            this.name = name;
            this.acquireActions = acquireActions;
            this.stock = stock;
            this.weight = weight;
            this.metadata = options?.metadata;
            this.consumeActions = options?.consumeActions;
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
            if (this.consumeActions != null) {
                properties["consumeActions"] = this.consumeActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.stock != null) {
                properties["stock"] = this.stock;
            }
            if (this.weight != null) {
                properties["weight"] = this.weight;
            }

            return properties;
        }

        public static RandomDisplayItemModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RandomDisplayItemModel(
                (string)properties["name"],
                new Func<AcquireAction[]>(() =>
                {
                    return properties["acquireActions"] switch {
                        Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                        _ => null
                    };
                })(),
                (int)properties["stock"],
                (int)properties["weight"],
                new RandomDisplayItemModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    consumeActions = properties.TryGetValue("consumeActions", out var consumeActions) ? new Func<ConsumeAction[]>(() =>
                    {
                        return consumeActions switch {
                            ConsumeAction[] v => v,
                            List<ConsumeAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
