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
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.Model.Options;

namespace Gs2Cdk.Gs2Enchant.Model
{
    public class RarityParameterValueModel {
        private string name;
        private string resourceName;
        private long resourceValue;
        private int weight;
        private string metadata;

        public RarityParameterValueModel(
            string name,
            string resourceName,
            long resourceValue,
            int weight,
            RarityParameterValueModelOptions options = null
        ){
            this.name = name;
            this.resourceName = resourceName;
            this.resourceValue = resourceValue;
            this.weight = weight;
            this.metadata = options?.metadata;
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
            if (this.resourceName != null) {
                properties["resourceName"] = this.resourceName;
            }
            if (this.resourceValue != null) {
                properties["resourceValue"] = this.resourceValue;
            }
            if (this.weight != null) {
                properties["weight"] = this.weight;
            }

            return properties;
        }

        public static RarityParameterValueModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RarityParameterValueModel(
                (string)properties["name"],
                (string)properties["resourceName"],
                new Func<long>(() =>
                {
                    return properties["resourceValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["weight"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new RarityParameterValueModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
