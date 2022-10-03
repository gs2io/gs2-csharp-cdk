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
    public class ItemModelRef {
        private readonly string _namespaceName;
        private readonly string _inventoryName;
        private readonly string _itemName;

        public ItemModelRef(
                string namespaceName,
                string inventoryName,
                string itemName
        ) {
            this._namespaceName = namespaceName;
            this._inventoryName = inventoryName;
            this._itemName = itemName;
        }

        public AcquireItemSetByUserId AcquireItemSet(
                long? acquireCount,
                long? expiresAt,
                bool? createNewItemSet,
                string itemSetName = null,
                string userId = "#{userId}"
        ) {
            return new AcquireItemSetByUserId(
                this._namespaceName,
                this._inventoryName,
                this._itemName,
                userId,
                acquireCount,
                expiresAt,
                createNewItemSet,
                itemSetName
            );
        }

        public AddReferenceOfByUserId AddReferenceOf(
                string itemSetName,
                string referenceOf,
                string userId = "#{userId}"
        ) {
            return new AddReferenceOfByUserId(
                this._namespaceName,
                this._inventoryName,
                userId,
                this._itemName,
                itemSetName,
                referenceOf
            );
        }

        public ConsumeItemSetByUserId ConsumeItemSet(
                long? consumeCount,
                string itemSetName = null,
                string userId = "#{userId}"
        ) {
            return new ConsumeItemSetByUserId(
                this._namespaceName,
                this._inventoryName,
                userId,
                this._itemName,
                consumeCount,
                itemSetName
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
                    this._inventoryName,
                    "item",
                    this._itemName
                }
            ).ToString();
        }
    }
}
