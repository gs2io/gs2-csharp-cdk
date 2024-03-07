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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.StampSheet.Enums;

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class VerifyReferenceOfByUserId : ConsumeAction {
        private string namespaceName;
        private string inventoryName;
        private string userId;
        private string itemName;
        private string referenceOf;
        private VerifyReferenceOfByUserIdVerifyType? verifyType;
        private string itemSetName;


        public VerifyReferenceOfByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            string referenceOf,
            VerifyReferenceOfByUserIdVerifyType verifyType,
            string itemSetName = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.referenceOf = referenceOf;
            this.verifyType = verifyType;
            this.itemSetName = itemSetName;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.inventoryName != null) {
                properties["inventoryName"] = this.inventoryName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.itemName != null) {
                properties["itemName"] = this.itemName;
            }
            if (this.referenceOf != null) {
                properties["referenceOf"] = this.referenceOf;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }

            return properties;
        }

        public static VerifyReferenceOfByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyReferenceOfByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    (string)properties["itemName"],
                    (string)properties["referenceOf"],
                    new Func<VerifyReferenceOfByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyReferenceOfByUserIdVerifyType e => e,
                            string s => VerifyReferenceOfByUserIdVerifyTypeExt.New(s),
                            _ => VerifyReferenceOfByUserIdVerifyType.NotEntry
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("itemSetName", out var itemSetName) ? itemSetName as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyReferenceOfByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    properties["itemName"].ToString(),
                    properties["referenceOf"].ToString(),
                    new Func<VerifyReferenceOfByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyReferenceOfByUserIdVerifyType e => e,
                            string s => VerifyReferenceOfByUserIdVerifyTypeExt.New(s),
                            _ => VerifyReferenceOfByUserIdVerifyType.NotEntry
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("itemSetName", out var itemSetName) ? itemSetName.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Inventory:VerifyReferenceOfByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifyReferenceOfByUserId";
        }
    }
}
