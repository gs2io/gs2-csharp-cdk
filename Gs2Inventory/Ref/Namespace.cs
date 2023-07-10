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

        public AddCapacityByUserId AddCapacity(
            string inventoryName,
            int? addCapacityValue,
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
            int? newCapacityValue,
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
            long? acquireCount,
            long? expiresAt,
            bool? createNewItemSet,
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
            string itemSetName,
            string referenceOf,
            string userId = "#{userId}"
        ){
            return (new AddReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                itemSetName,
                referenceOf,
                userId
            ));
        }

        public DeleteReferenceOfByUserId DeleteReferenceOf(
            string inventoryName,
            string itemName,
            string itemSetName,
            string referenceOf,
            string userId = "#{userId}"
        ){
            return (new DeleteReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                itemSetName,
                referenceOf,
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

        public ConsumeItemSetByUserId ConsumeItemSet(
            string inventoryName,
            string itemName,
            long? consumeCount,
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

        public VerifyReferenceOfByUserId VerifyReferenceOf(
            string inventoryName,
            string itemName,
            string itemSetName,
            string referenceOf,
            string verifyType,
            string userId = "#{userId}"
        ){
            return (new VerifyReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                itemSetName,
                referenceOf,
                verifyType,
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
