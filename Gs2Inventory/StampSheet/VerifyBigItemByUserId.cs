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
    public class VerifyBigItemByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string inventoryName;
        private string itemName;
        private BigItemVerifyType? verifyType;
        private string count;


        public VerifyBigItemByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            BigItemVerifyType verifyType,
            string count,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.verifyType = verifyType;
            this.count = count;
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
            if (this.count != null) {
                properties["count"] = this.count;
            }

            return properties;
        }

        public static VerifyBigItemByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyBigItemByUserId(
                (string)properties["namespaceName"],
                (string)properties["inventoryName"],
                (string)properties["itemName"],
                new Func<BigItemVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        BigItemVerifyType e => e,
                        string s => BigItemVerifyTypeExt.New(s),
                        _ => BigItemVerifyType.Less
                    };
                })(),
                (string)properties["count"],
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Inventory:VerifyBigItemByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifyBigItemByUserId";
        }
    }
}
