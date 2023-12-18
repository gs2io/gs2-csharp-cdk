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
using Gs2Cdk.Gs2Inventory.Model.Enums;

namespace Gs2Cdk.Gs2Inventory.Ref
{
    public class ItemModelRef {
        private string namespaceName;
        private string inventoryName;
        private string itemName;

        public ItemModelRef(
            string namespaceName,
            string inventoryName,
            string itemName
        ){
            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
        }

        public AcquireItemSetByUserId AcquireItemSet(
            long acquireCount,
            long? expiresAt = null,
            bool? createNewItemSet = null,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new AcquireItemSetByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
                acquireCount,
                expiresAt,
                createNewItemSet,
                itemSetName,
                userId
            ));
        }

        public AddReferenceOfByUserId AddReferenceOf(
            string referenceOf,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new AddReferenceOfByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public DeleteReferenceOfByUserId DeleteReferenceOf(
            string referenceOf,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new DeleteReferenceOfByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
                referenceOf,
                itemSetName,
                userId
            ));
        }

        public ConsumeItemSetByUserId ConsumeItemSet(
            long consumeCount,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeItemSetByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
                consumeCount,
                itemSetName,
                userId
            ));
        }

        public VerifyItemSetByUserId VerifyItemSet(
            ItemSetVerifyType verifyType,
            long count,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyItemSetByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
                verifyType,
                count,
                itemSetName,
                userId
            ));
        }

        public VerifyReferenceOfByUserId VerifyReferenceOf(
            string referenceOf,
            ReferenceOfVerifyType verifyType,
            string itemSetName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyReferenceOfByUserId(
                this.namespaceName,
                this.inventoryName,
                this.itemName,
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
                    this.inventoryName,
                    "item",
                    this.itemName
                }
            )).Str(
            );
        }
    }
}
