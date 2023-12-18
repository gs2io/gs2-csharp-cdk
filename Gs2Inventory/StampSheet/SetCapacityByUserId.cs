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

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class SetCapacityByUserId : AcquireAction {
        private string namespaceName;
        private string inventoryName;
        private string userId;
        private int newCapacityValue;


        public SetCapacityByUserId(
            string namespaceName,
            string inventoryName,
            int newCapacityValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.newCapacityValue = newCapacityValue;
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
            if (this.newCapacityValue != null) {
                properties["newCapacityValue"] = this.newCapacityValue;
            }

            return properties;
        }

        public static SetCapacityByUserId FromProperties(Dictionary<string, object> properties) {
            return new SetCapacityByUserId(
                (string)properties["namespaceName"],
                (string)properties["inventoryName"],
                new Func<int>(() =>
                {
                    return properties["newCapacityValue"] switch {
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
            return "Gs2Inventory:SetCapacityByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:SetCapacityByUserId";
        }
    }
}
