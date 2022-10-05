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
using Gs2Cdk.Gs2Inventory.StampSheet;


namespace Gs2Cdk.Gs2Inventory.Ref
{
    public class InventoryModelRef {
        private readonly string _namespaceName;
        private readonly string _inventoryName;

        public InventoryModelRef(
                string namespaceName,
                string inventoryName
        ) {
            this._namespaceName = namespaceName;
            this._inventoryName = inventoryName;
        }

        public ItemModelRef ItemModel(
                string itemName
        ) {
            return new ItemModelRef(
                this._namespaceName,
                this._inventoryName,
                itemName
            );
        }

        public AddCapacityByUserId AddCapacity(
                int? addCapacityValue,
                string userId = "#{userId}"
        ) {
            return new AddCapacityByUserId(
                namespaceName: this._namespaceName,
                inventoryName: this._inventoryName,
                userId: userId,
                addCapacityValue: addCapacityValue
            );
        }

        public SetCapacityByUserId SetCapacity(
                int? newCapacityValue,
                string userId = "#{userId}"
        ) {
            return new SetCapacityByUserId(
                namespaceName: this._namespaceName,
                inventoryName: this._inventoryName,
                userId: userId,
                newCapacityValue: newCapacityValue
            );
        }

        public string Grn() {
            return new Join(
                ":",
                new string[] {
                    "grn",
                    "gs2",
                    GetAttr.Region().ToString(),
                    GetAttr.OwnerId().ToString(),
                    "inventory",
                    this._namespaceName,
                    "model",
                    this._inventoryName
                }
            ).ToString();
        }
    }
}
