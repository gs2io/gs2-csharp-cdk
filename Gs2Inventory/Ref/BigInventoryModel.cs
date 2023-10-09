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
    public class BigInventoryModelRef {
        private string namespaceName;
        private string inventoryName;

        public BigInventoryModelRef(
            string namespaceName,
            string inventoryName
        ){
            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
        }

        public BigItemModelRef BigItemModel(
            string itemName
        ){
            return (new BigItemModelRef(
                this.namespaceName,
                this.inventoryName,
                itemName
            ));
        }

        public AcquireBigItemByUserId AcquireBigItem(
            string itemName,
            string acquireCount,
            string userId = "#{userId}"
        ){
            return (new AcquireBigItemByUserId(
                namespaceName,
                inventoryName,
                itemName,
                acquireCount,
                userId
            ));
        }

        public ConsumeBigItemByUserId ConsumeBigItem(
            string itemName,
            string consumeCount,
            string userId = "#{userId}"
        ){
            return (new ConsumeBigItemByUserId(
                namespaceName,
                inventoryName,
                itemName,
                consumeCount,
                userId
            ));
        }

        public VerifyBigItemByUserId VerifyBigItem(
            string itemName,
            string verifyType,
            string count,
            string userId = "#{userId}"
        ){
            return (new VerifyBigItemByUserId(
                namespaceName,
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
                    this.namespaceName,
                    "big",
                    "model",
                    this.inventoryName
                }
            )).Str(
            );
        }
    }
}
