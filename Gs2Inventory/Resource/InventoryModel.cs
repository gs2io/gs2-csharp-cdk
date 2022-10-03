/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Ref;

namespace Gs2Cdk.Gs2Inventory.Resource
{

    public class InventoryModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly int? _initialCapacity;
	    private readonly int? _maxCapacity;
	    private readonly bool? _protectReferencedItem;
	    private readonly ItemModel[] _itemModels;

        public InventoryModel(
                string name,
                int? initialCapacity,
                int? maxCapacity,
                string metadata = null,
                bool? protectReferencedItem = null,
                ItemModel[] itemModels = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._initialCapacity = initialCapacity;
            this._maxCapacity = maxCapacity;
            this._protectReferencedItem = protectReferencedItem;
            this._itemModels = itemModels;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._initialCapacity != null) {
                properties["InitialCapacity"] = this._initialCapacity;
            }
            if (this._maxCapacity != null) {
                properties["MaxCapacity"] = this._maxCapacity;
            }
            if (this._protectReferencedItem != null) {
                properties["ProtectReferencedItem"] = this._protectReferencedItem;
            }
            if (this._itemModels != null) {
                properties["ItemModels"] = this._itemModels.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }

        public InventoryModelRef Ref(
                string namespaceName
        )
        {
            return new InventoryModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
