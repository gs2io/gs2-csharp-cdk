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
        private string stockString;
        private int weight;
        private string weightString;
        private string metadata;
        private VerifyAction[] verifyActions;
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
            this.verifyActions = options?.verifyActions;
            this.consumeActions = options?.consumeActions;
        }


        public RandomDisplayItemModel(
            string name,
            AcquireAction[] acquireActions,
            string stock,
            string weight,
            RandomDisplayItemModelOptions options = null
        ){
            this.name = name;
            this.acquireActions = acquireActions;
            this.stockString = stock;
            this.weightString = weight;
            this.metadata = options?.metadata;
            this.verifyActions = options?.verifyActions;
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
            if (this.verifyActions != null) {
                properties["verifyActions"] = this.verifyActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.consumeActions != null) {
                properties["consumeActions"] = this.consumeActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.stockString != null) {
                properties["stock"] = this.stockString;
            } else {
                if (this.stock != null) {
                    properties["stock"] = this.stock;
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

        public static RandomDisplayItemModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RandomDisplayItemModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                {
                    return acquireActions switch {
                        Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ AcquireAction.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as AcquireAction).ToArray(),
                        { } v => new []{ v as AcquireAction },
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("stock", out var stock) ? new Func<int>(() =>
                {
                    return stock switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("weight", out var weight) ? new Func<int>(() =>
                {
                    return weight switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new RandomDisplayItemModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    verifyActions = properties.TryGetValue("verifyActions", out var verifyActions) ? new Func<VerifyAction[]>(() =>
                    {
                        return verifyActions switch {
                            VerifyAction[] v => v,
                            List<VerifyAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(VerifyAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(VerifyAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
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
