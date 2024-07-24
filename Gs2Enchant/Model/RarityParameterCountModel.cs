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
    public class RarityParameterCountModel {
        private int count;
        private string countString;
        private int weight;
        private string weightString;

        public RarityParameterCountModel(
            int count,
            int weight,
            RarityParameterCountModelOptions options = null
        ){
            this.count = count;
            this.weight = weight;
        }


        public RarityParameterCountModel(
            string count,
            string weight,
            RarityParameterCountModelOptions options = null
        ){
            this.countString = count;
            this.weightString = weight;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
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

        public static RarityParameterCountModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RarityParameterCountModel(
                properties.TryGetValue("count", out var count) ? new Func<int>(() =>
                {
                    return count switch {
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
                new RarityParameterCountModelOptions {
                }
            );

            return model;
        }
    }
}
