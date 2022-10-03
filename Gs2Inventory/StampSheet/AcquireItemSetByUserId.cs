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
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inventory.Model;

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class AcquireItemSetByUserId : AcquireAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string inventoryName,
                string itemName,
                string userId,
                long? acquireCount,
                long? expiresAt,
                bool? createNewItemSet,
                string itemSetName
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (inventoryName != null) {
                properties["inventoryName"] = inventoryName;
            }
            if (itemName != null) {
                properties["itemName"] = itemName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (acquireCount != null) {
                properties["acquireCount"] = acquireCount;
            }
            if (expiresAt != null) {
                properties["expiresAt"] = expiresAt;
            }
            if (createNewItemSet != null) {
                properties["createNewItemSet"] = createNewItemSet;
            }
            if (itemSetName != null) {
                properties["itemSetName"] = itemSetName;
            }
            return properties;
        }

        public AcquireItemSetByUserId(
                string namespaceName,
                string inventoryName,
                string itemName,
                string userId,
                long? acquireCount,
                long? expiresAt,
                bool? createNewItemSet,
                string itemSetName = null
        ): base(
           "Gs2Inventory:AcquireItemSetByUserId",
           Properties(
                namespaceName,
                inventoryName,
                itemName,
                userId,
                acquireCount,
                expiresAt,
                createNewItemSet,
                itemSetName
           )
        ) {
        }
    }
}
