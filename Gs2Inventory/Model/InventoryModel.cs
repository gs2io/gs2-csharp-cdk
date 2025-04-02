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
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Model.Options;

namespace Gs2Cdk.Gs2Inventory.Model
{
    public class InventoryModel {
        private string name;
        private int initialCapacity;
        private string initialCapacityString;
        private int maxCapacity;
        private string maxCapacityString;
        private ItemModel[] itemModels;
        private string metadata;
        private bool? protectReferencedItem;
        private string protectReferencedItemString;

        public InventoryModel(
            string name,
            int initialCapacity,
            int maxCapacity,
            ItemModel[] itemModels,
            InventoryModelOptions options = null
        ){
            this.name = name;
            this.initialCapacity = initialCapacity;
            this.maxCapacity = maxCapacity;
            this.itemModels = itemModels;
            this.metadata = options?.metadata;
            this.protectReferencedItem = options?.protectReferencedItem;
        }


        public InventoryModel(
            string name,
            string initialCapacity,
            string maxCapacity,
            ItemModel[] itemModels,
            InventoryModelOptions options = null
        ){
            this.name = name;
            this.initialCapacityString = initialCapacity;
            this.maxCapacityString = maxCapacity;
            this.itemModels = itemModels;
            this.metadata = options?.metadata;
            this.protectReferencedItem = options?.protectReferencedItem;
            this.protectReferencedItemString = options?.protectReferencedItemString;
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
            if (this.initialCapacityString != null) {
                properties["initialCapacity"] = this.initialCapacityString;
            } else {
                if (this.initialCapacity != null) {
                    properties["initialCapacity"] = this.initialCapacity;
                }
            }
            if (this.maxCapacityString != null) {
                properties["maxCapacity"] = this.maxCapacityString;
            } else {
                if (this.maxCapacity != null) {
                    properties["maxCapacity"] = this.maxCapacity;
                }
            }
            if (this.protectReferencedItemString != null) {
                properties["protectReferencedItem"] = this.protectReferencedItemString;
            } else {
                if (this.protectReferencedItem != null) {
                    properties["protectReferencedItem"] = this.protectReferencedItem;
                }
            }
            if (this.itemModels != null) {
                properties["itemModels"] = this.itemModels.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static InventoryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new InventoryModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("initialCapacity", out var initialCapacity) ? new Func<int>(() =>
                {
                    return initialCapacity switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("maxCapacity", out var maxCapacity) ? new Func<int>(() =>
                {
                    return maxCapacity switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("itemModels", out var itemModels) ? new Func<ItemModel[]>(() =>
                {
                    return itemModels switch {
                        Dictionary<string, object>[] v => v.Select(ItemModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ ItemModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(ItemModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as ItemModel).ToArray(),
                        { } v => new []{ v as ItemModel },
                        _ => null
                    };
                })() : null,
                new InventoryModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    protectReferencedItem = new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("protectReferencedItem", out var protectReferencedItem) ? protectReferencedItem switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
