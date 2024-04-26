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
    public class SimpleInventoryModelRef {
        private string namespaceName;
        private string inventoryName;

        public SimpleInventoryModelRef(
            string namespaceName,
            string inventoryName
        ){
            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
        }

        public SimpleItemModelRef SimpleItemModel(
            string itemName
        ){
            return (new SimpleItemModelRef(
                this.namespaceName,
                this.inventoryName,
                itemName
            ));
        }

        public AcquireSimpleItemsByUserId AcquireSimpleItems(
            AcquireCount[] acquireCounts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AcquireSimpleItemsByUserId(
                this.namespaceName,
                this.inventoryName,
                acquireCounts,
                timeOffsetToken,
                userId
            ));
        }

        public SetSimpleItemsByUserId SetSimpleItems(
            HeldCount[] counts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetSimpleItemsByUserId(
                this.namespaceName,
                this.inventoryName,
                counts,
                timeOffsetToken,
                userId
            ));
        }

        public ConsumeSimpleItemsByUserId ConsumeSimpleItems(
            ConsumeCount[] consumeCounts,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeSimpleItemsByUserId(
                this.namespaceName,
                this.inventoryName,
                consumeCounts,
                timeOffsetToken,
                userId
            ));
        }

        public VerifySimpleItemByUserId VerifySimpleItem(
            string itemName,
            VerifySimpleItemByUserIdVerifyType verifyType,
            long count,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifySimpleItemByUserId(
                this.namespaceName,
                this.inventoryName,
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
                    this.namespaceName,
                    "simple",
                    "model",
                    this.inventoryName
                }
            )).Str(
            );
        }
    }
}
