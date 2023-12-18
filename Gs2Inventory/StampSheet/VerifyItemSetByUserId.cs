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
using Gs2Cdk.Gs2Inventory.Model.Enums;

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class VerifyItemSetByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string inventoryName;
        private string itemName;
        private ItemSetVerifyType? verifyType;
        private long count;
        private string itemSetName;


        public VerifyItemSetByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            ItemSetVerifyType verifyType,
            long count,
            string itemSetName = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.verifyType = verifyType;
            this.count = count;
            this.itemSetName = itemSetName;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.inventoryName != null) {
                properties["inventoryName"] = this.inventoryName;
            }
            if (this.itemName != null) {
                properties["itemName"] = this.itemName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.itemSetName != null) {
                properties["itemSetName"] = this.itemSetName;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }

            return properties;
        }

        public static VerifyItemSetByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyItemSetByUserId(
                (string)properties["namespaceName"],
                (string)properties["inventoryName"],
                (string)properties["itemName"],
                new Func<ItemSetVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        ItemSetVerifyType e => e,
                        string s => ItemSetVerifyTypeExt.New(s),
                        _ => ItemSetVerifyType.Less
                    };
                })(),
                new Func<long>(() =>
                {
                    return properties["count"] switch {
                        long v => (long)v,
                        int v => (long)v,
                        float v => (long)v,
                        double v => (long)v,
                        string v => long.Parse(v),
                        _ => 0
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
        }

        public override string Action() {
            return "Gs2Inventory:VerifyItemSetByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifyItemSetByUserId";
        }
    }
}
