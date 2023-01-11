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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Model.Options;

namespace Gs2Cdk.Gs2Inventory.Model
{
    public class InventoryModel {
        private string name;
        private int? initialCapacity;
        private int? maxCapacity;
        private ItemModel[] itemModels;
        private string metadata;
        private bool? protectReferencedItem;

        public InventoryModel(
            string name,
            int? initialCapacity,
            int? maxCapacity,
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

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.initialCapacity != null) {
                properties["initialCapacity"] = this.initialCapacity;
            }
            if (this.maxCapacity != null) {
                properties["maxCapacity"] = this.maxCapacity;
            }
            if (this.protectReferencedItem != null) {
                properties["protectReferencedItem"] = this.protectReferencedItem;
            }
            if (this.itemModels != null) {
                properties["itemModels"] = this.itemModels.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }
    }
}
