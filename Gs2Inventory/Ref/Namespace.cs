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
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public InventoryModelRef InventoryModel(
            string inventoryName
        ){
            return (new InventoryModelRef(
                this.namespaceName,
                inventoryName
            ));
        }

        public SimpleInventoryModelRef SimpleInventoryModel(
            string inventoryName
        ){
            return (new SimpleInventoryModelRef(
                this.namespaceName,
                inventoryName
            ));
        }

        public BigInventoryModelRef BigInventoryModel(
            string inventoryName
        ){
            return (new BigInventoryModelRef(
                this.namespaceName,
                inventoryName
            ));
        }

        public AddCapacityByUserId AddCapacity(
            string inventoryName,
            int addCapacityValue,
            string userId = "#{userId}"
        ){
            return (new AddCapacityByUserId(
                this.namespaceName,
                inventoryName,
                addCapacityValue,
                userId
            ));
        }

        public SetCapacityByUserId SetCapacity(
            string inventoryName,
            int newCapacityValue,
            string userId = "#{userId}"
        ){
            return (new SetCapacityByUserId(
                this.namespaceName,
                inventoryName,
                newCapacityValue,
                userId
            ));
        }

        public AcquireItemSetByUserId AcquireItemSet(
            string inventoryName,
            string itemName,
            long acquireCount,
            long? expiresAt = null,
            bool? createNewItemSet = null,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new AcquireItemSetByUserId(
                this.namespaceName,
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
            string inventoryName,
            string itemName,
            string referenceOf,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new AddReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public DeleteReferenceOfByUserId DeleteReferenceOf(
            string inventoryName,
            string itemName,
            string referenceOf,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new DeleteReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public AcquireSimpleItemsByUserId AcquireSimpleItems(
            string inventoryName,
            AcquireCount[] acquireCounts,
            string userId = "#{userId}"
        ){
            return (new AcquireSimpleItemsByUserId(
                this.namespaceName,
                inventoryName,
                acquireCounts,
                userId
            ));
        }

        public AcquireBigItemByUserId AcquireBigItem(
            string inventoryName,
            string itemName,
            string acquireCount,
            string userId = "#{userId}"
        ){
            return (new AcquireBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                acquireCount,
                userId
            ));
        }

        public VerifyInventoryCurrentMaxCapacityByUserId VerifyInventoryCurrentMaxCapacity(
            string inventoryName,
            string verifyType,
            int currentInventoryMaxCapacity,
            string userId = "#{userId}"
        ){
            return (new VerifyInventoryCurrentMaxCapacityByUserId(
                this.namespaceName,
                inventoryName,
                verifyType,
                currentInventoryMaxCapacity,
                userId
            ));
        }

        public ConsumeItemSetByUserId ConsumeItemSet(
            string inventoryName,
            string itemName,
            long consumeCount,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeItemSetByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                itemSetName,
                userId
            ));
        }

        public VerifyItemSetByUserId VerifyItemSet(
            string inventoryName,
            string itemName,
            string verifyType,
            long count,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyItemSetByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                itemSetName,
                userId
            ));
        }

        public VerifyReferenceOfByUserId VerifyReferenceOf(
            string inventoryName,
            string itemName,
            string referenceOf,
            string verifyType,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                verifyType,
                itemSetName,
                userId
            ));
        }

        public ConsumeSimpleItemsByUserId ConsumeSimpleItems(
            string inventoryName,
            ConsumeCount[] consumeCounts,
            string userId = "#{userId}"
        ){
            return (new ConsumeSimpleItemsByUserId(
                this.namespaceName,
                inventoryName,
                consumeCounts,
                userId
            ));
        }

        public VerifySimpleItemByUserId VerifySimpleItem(
            string inventoryName,
            string itemName,
            string verifyType,
            long count,
            string userId = "#{userId}"
        ){
            return (new VerifySimpleItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                userId
            ));
        }

        public ConsumeBigItemByUserId ConsumeBigItem(
            string inventoryName,
            string itemName,
            string consumeCount,
            string userId = "#{userId}"
        ){
            return (new ConsumeBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                userId
            ));
        }

        public VerifyBigItemByUserId VerifyBigItem(
            string inventoryName,
            string itemName,
            string verifyType,
            string count,
            string userId = "#{userId}"
        ){
            return (new VerifyBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
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
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
