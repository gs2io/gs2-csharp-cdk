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
    public class VerifyInventoryCurrentMaxCapacityByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string inventoryName;
        private InventoryVerifyType? verifyType;
        private int currentInventoryMaxCapacity;


        public VerifyInventoryCurrentMaxCapacityByUserId(
            string namespaceName,
            string inventoryName,
            InventoryVerifyType verifyType,
            int currentInventoryMaxCapacity,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.verifyType = verifyType;
            this.currentInventoryMaxCapacity = currentInventoryMaxCapacity;
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
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.currentInventoryMaxCapacity != null) {
                properties["currentInventoryMaxCapacity"] = this.currentInventoryMaxCapacity;
            }

            return properties;
        }

        public static VerifyInventoryCurrentMaxCapacityByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyInventoryCurrentMaxCapacityByUserId(
                (string)properties["namespaceName"],
                (string)properties["inventoryName"],
                new Func<InventoryVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        InventoryVerifyType e => e,
                        string s => InventoryVerifyTypeExt.New(s),
                        _ => InventoryVerifyType.Less
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["currentInventoryMaxCapacity"] switch {
                        long v => (int)v,
                        int v => (int)v,
                        float v => (int)v,
                        double v => (int)v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId";
        }
    }
}
