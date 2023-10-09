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

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.StampSheet;

namespace Gs2Cdk.Gs2Inventory.Ref
{
    public class InventoryModelRef {
        private string namespaceName;
        private string inventoryName;

        public InventoryModelRef(
            string namespaceName,
            string inventoryName
        ){
            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
        }

        public ItemModelRef ItemModel(
            string itemName
        ){
            return (new ItemModelRef(
                this.namespaceName,
                this.inventoryName,
                itemName
            ));
        }

        public AddCapacityByUserId AddCapacity(
            int addCapacityValue,
            string userId = "#{userId}"
        ){
            return (new AddCapacityByUserId(
                namespaceName,
                inventoryName,
                addCapacityValue,
                userId
            ));
        }

        public SetCapacityByUserId SetCapacity(
            int newCapacityValue,
            string userId = "#{userId}"
        ){
            return (new SetCapacityByUserId(
                namespaceName,
                inventoryName,
                newCapacityValue,
                userId
            ));
        }

        public AcquireItemSetByUserId AcquireItemSet(
            string itemName,
            long acquireCount,
            long? expiresAt,
            bool? createNewItemSet,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new AcquireItemSetByUserId(
                namespaceName,
                inventoryName,
                itemName,
                acquireCount,
                expiresAt,
                createNewItemSet,
                itemSetName,
                userId
            ));
        }

        public AddReferenceOfByUserId AddReferenceOf(
            string itemName,
            string itemSetName,
            string referenceOf,
            string userId = "#{userId}"
        ){
            return (new AddReferenceOfByUserId(
                namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public DeleteReferenceOfByUserId DeleteReferenceOf(
            string itemName,
            string itemSetName,
            string referenceOf,
            string userId = "#{userId}"
        ){
            return (new DeleteReferenceOfByUserId(
                namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public ConsumeItemSetByUserId ConsumeItemSet(
            string itemName,
            long consumeCount,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeItemSetByUserId(
                namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                itemSetName,
                userId
            ));
        }

        public VerifyItemSetByUserId VerifyItemSet(
            string itemName,
            string verifyType,
            long count,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyItemSetByUserId(
                namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                itemSetName,
                userId
            ));
        }

        public VerifyReferenceOfByUserId VerifyReferenceOf(
            string itemName,
            string itemSetName,
            string referenceOf,
            string verifyType,
            string userId = "#{userId}"
        ){
            return (new VerifyReferenceOfByUserId(
                namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                verifyType,
                itemSetName,
                userId
            ));
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "inventory",
                    this.namespaceName,
                    "model",
                    this.inventoryName
                }
            )).Str(
            );
        }
    }
}
