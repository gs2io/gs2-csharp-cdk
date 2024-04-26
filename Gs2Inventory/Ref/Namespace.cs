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
using Gs2Cdk.Gs2Inventory.StampSheet.Enums;

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
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AddCapacityByUserId(
                this.namespaceName,
                inventoryName,
                addCapacityValue,
                timeOffsetToken,
                userId
            ));
        }

        public SetCapacityByUserId SetCapacity(
            string inventoryName,
            int newCapacityValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetCapacityByUserId(
                this.namespaceName,
                inventoryName,
                newCapacityValue,
                timeOffsetToken,
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
            string timeOffsetToken = null,
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
                timeOffsetToken,
                userId
            ));
        }

        public AcquireItemSetWithGradeByUserId AcquireItemSetWithGrade(
            string inventoryName,
            string itemName,
            string gradeModelId,
            long gradeValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AcquireItemSetWithGradeByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                gradeModelId,
                gradeValue,
                timeOffsetToken,
                userId
            ));
        }

        public AddReferenceOfByUserId AddReferenceOf(
            string inventoryName,
            string itemName,
            string referenceOf,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AddReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                timeOffsetToken,
                userId
            ));
        }

        public DeleteReferenceOfByUserId DeleteReferenceOf(
            string inventoryName,
            string itemName,
            string referenceOf,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new DeleteReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                itemSetName,
                timeOffsetToken,
                userId
            ));
        }

        public AcquireSimpleItemsByUserId AcquireSimpleItems(
            string inventoryName,
            AcquireCount[] acquireCounts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AcquireSimpleItemsByUserId(
                this.namespaceName,
                inventoryName,
                acquireCounts,
                timeOffsetToken,
                userId
            ));
        }

        public SetSimpleItemsByUserId SetSimpleItems(
            string inventoryName,
            HeldCount[] counts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetSimpleItemsByUserId(
                this.namespaceName,
                inventoryName,
                counts,
                timeOffsetToken,
                userId
            ));
        }

        public AcquireBigItemByUserId AcquireBigItem(
            string inventoryName,
            string itemName,
            string acquireCount,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AcquireBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                acquireCount,
                timeOffsetToken,
                userId
            ));
        }

        public SetBigItemByUserId SetBigItem(
            string inventoryName,
            string itemName,
            string count,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                count,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyInventoryCurrentMaxCapacityByUserId VerifyInventoryCurrentMaxCapacity(
            string inventoryName,
            VerifyInventoryCurrentMaxCapacityByUserIdVerifyType verifyType,
            int currentInventoryMaxCapacity,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyInventoryCurrentMaxCapacityByUserId(
                this.namespaceName,
                inventoryName,
                verifyType,
                currentInventoryMaxCapacity,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
                userId
            ));
        }

        public ConsumeItemSetByUserId ConsumeItemSet(
            string inventoryName,
            string itemName,
            long consumeCount,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeItemSetByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                itemSetName,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyItemSetByUserId VerifyItemSet(
            string inventoryName,
            string itemName,
            VerifyItemSetByUserIdVerifyType verifyType,
            long count,
            string itemSetName = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyItemSetByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                itemSetName,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyReferenceOfByUserId VerifyReferenceOf(
            string inventoryName,
            string itemName,
            string referenceOf,
            VerifyReferenceOfByUserIdVerifyType verifyType,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyReferenceOfByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                referenceOf,
                verifyType,
                itemSetName,
                timeOffsetToken,
                userId
            ));
        }

        public ConsumeSimpleItemsByUserId ConsumeSimpleItems(
            string inventoryName,
            ConsumeCount[] consumeCounts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeSimpleItemsByUserId(
                this.namespaceName,
                inventoryName,
                consumeCounts,
                timeOffsetToken,
                userId
            ));
        }

        public VerifySimpleItemByUserId VerifySimpleItem(
            string inventoryName,
            string itemName,
            VerifySimpleItemByUserIdVerifyType verifyType,
            long count,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifySimpleItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
                userId
            ));
        }

        public ConsumeBigItemByUserId ConsumeBigItem(
            string inventoryName,
            string itemName,
            string consumeCount,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyBigItemByUserId VerifyBigItem(
            string inventoryName,
            string itemName,
            VerifyBigItemByUserIdVerifyType verifyType,
            string count,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyBigItemByUserId(
                this.namespaceName,
                inventoryName,
                itemName,
                verifyType,
                count,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
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
