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
        private string numberOfMinEntriesString;
        private int? numberOfMaxEntries;
        private string numberOfMaxEntriesString;
        private int height;
        private string heightString;
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


        public Layer(
            string areaModelName,
            string layerModelName,
            string numberOfMinEntries,
            string numberOfMaxEntries,
            string height,
            LayerOptions options = null
        ){
            this.areaModelName = areaModelName;
            this.layerModelName = layerModelName;
            this.numberOfMinEntriesString = numberOfMinEntries;
            this.numberOfMaxEntriesString = numberOfMaxEntries;
            this.heightString = height;
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
            if (this.numberOfMinEntriesString != null) {
                properties["numberOfMinEntries"] = this.numberOfMinEntriesString;
            } else {
                if (this.numberOfMinEntries != null) {
                    properties["numberOfMinEntries"] = this.numberOfMinEntries;
                }
            }
            if (this.numberOfMaxEntriesString != null) {
                properties["numberOfMaxEntries"] = this.numberOfMaxEntriesString;
            } else {
                if (this.numberOfMaxEntries != null) {
                    properties["numberOfMaxEntries"] = this.numberOfMaxEntries;
                }
            }
            if (this.heightString != null) {
                properties["height"] = this.heightString;
            } else {
                if (this.height != null) {
                    properties["height"] = this.height;
                }
            }

            return properties;
        }

        public static Layer FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Layer(
                properties.TryGetValue("areaModelName", out var areaModelName) ? new Func<string>(() =>
                {
                    return (string) areaModelName;
                })() : default,
                properties.TryGetValue("layerModelName", out var layerModelName) ? new Func<string>(() =>
                {
                    return (string) layerModelName;
                })() : default,
                properties.TryGetValue("numberOfMinEntries", out var numberOfMinEntries) ? new Func<int?>(() =>
                {
                    return numberOfMinEntries switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("numberOfMaxEntries", out var numberOfMaxEntries) ? new Func<int?>(() =>
                {
                    return numberOfMaxEntries switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("height", out var height) ? new Func<int>(() =>
                {
                    return height switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new LayerOptions {
                    root = properties.TryGetValue("root", out var root) ? (string)root : null
                }
            );

            return model;
        }
    }
}
