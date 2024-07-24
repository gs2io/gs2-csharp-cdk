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
using Gs2Cdk.Gs2MegaField.Model;
using Gs2Cdk.Gs2MegaField.Model.Options;

namespace Gs2Cdk.Gs2MegaField.Model
{
    public class AreaModel {
        private string name;
        private string metadata;
        private LayerModel[] layerModels;

        public AreaModel(
            string name,
            AreaModelOptions options = null
        ){
            this.name = name;
            this.metadata = options?.metadata;
            this.layerModels = options?.layerModels;
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
            if (this.layerModels != null) {
                properties["layerModels"] = this.layerModels.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static AreaModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AreaModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                new AreaModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    layerModels = properties.TryGetValue("layerModels", out var layerModels) ? new Func<LayerModel[]>(() =>
                    {
                        return layerModels switch {
                            LayerModel[] v => v,
                            List<LayerModel> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(LayerModel.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(LayerModel.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
