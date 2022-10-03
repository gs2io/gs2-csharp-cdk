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
    public class VerifyReferenceOfByUserId : ConsumeAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string inventoryName,
                string userId,
                string itemName,
                string itemSetName,
                string referenceOf,
                string verifyType
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (inventoryName != null) {
                properties["inventoryName"] = inventoryName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (itemName != null) {
                properties["itemName"] = itemName;
            }
            if (itemSetName != null) {
                properties["itemSetName"] = itemSetName;
            }
            if (referenceOf != null) {
                properties["referenceOf"] = referenceOf;
            }
            if (verifyType != null) {
                properties["verifyType"] = verifyType;
            }
            return properties;
        }

        public VerifyReferenceOfByUserId(
                string namespaceName,
                string inventoryName,
                string userId,
                string itemName,
                string itemSetName,
                string referenceOf,
                string verifyType
        ): base(
           "Gs2Inventory:VerifyReferenceOfByUserId",
           Properties(
                namespaceName,
                inventoryName,
                userId,
                itemName,
                itemSetName,
                referenceOf,
                verifyType
           )
        ) {
        }
    }
}
