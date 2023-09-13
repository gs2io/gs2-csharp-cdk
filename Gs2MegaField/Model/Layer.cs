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
    public class Layer {
        private string areaModelName;
        private string layerModelName;
        private int? numberOfMinEntries;
        private int? numberOfMaxEntries;
        private int height;
        private string root;

        public Layer(
            string areaModelName,
            string layerModelName,
            int? numberOfMinEntries,
            int? numberOfMaxEntries,
            int height,
            LayerOptions options = null
        ){
            this.areaModelName = areaModelName;
            this.layerModelName = layerModelName;
            this.numberOfMinEntries = numberOfMinEntries;
            this.numberOfMaxEntries = numberOfMaxEntries;
            this.height = height;
            this.root = options?.root;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.areaModelName != null) {
                properties["areaModelName"] = this.areaModelName;
            }
            if (this.layerModelName != null) {
                properties["layerModelName"] = this.layerModelName;
            }
            if (this.root != null) {
                properties["root"] = this.root;
            }
            if (this.numberOfMinEntries != null) {
                properties["numberOfMinEntries"] = this.numberOfMinEntries;
            }
            if (this.numberOfMaxEntries != null) {
                properties["numberOfMaxEntries"] = this.numberOfMaxEntries;
            }
            if (this.height != null) {
                properties["height"] = this.height;
            }

            return properties;
        }

        public static Layer FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Layer(
                (string)properties["areaModelName"],
                (string)properties["layerModelName"],
                new Func<int?>(() =>
                {
                    return properties["numberOfMinEntries"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int?>(() =>
                {
                    return properties["numberOfMaxEntries"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["height"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new LayerOptions {
                    root = properties.TryGetValue("root", out var root) ? (string)root : null
                }
            );

            return model;
        }
    }
}
