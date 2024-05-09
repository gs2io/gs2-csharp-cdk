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
    public class AddReferenceOfByUserId : AcquireAction {
        private string namespaceName;
        private string inventoryName;
        private string userId;
        private string itemName;
        private string referenceOf;
        private string itemSetName;
        private string timeOffsetToken;


        public AddReferenceOfByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            string referenceOf,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.referenceOf = referenceOf;
            this.itemSetName = itemSetName;
            this.timeOffsetToken = timeOffsetToken;
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
            if (this.itemSetName != null) {
                properties["itemSetName"] = this.itemSetName;
            }
            if (this.referenceOf != null) {
                properties["referenceOf"] = this.referenceOf;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static AddReferenceOfByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AddReferenceOfByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    (string)properties["itemName"],
                    (string)properties["referenceOf"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("itemSetName", out var itemSetName) ? itemSetName as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new AddReferenceOfByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    properties["itemName"].ToString(),
                    properties["referenceOf"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("itemSetName", out var itemSetName) ? itemSetName.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Inventory:AddReferenceOfByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:AddReferenceOfByUserId";
        }
    }
}
