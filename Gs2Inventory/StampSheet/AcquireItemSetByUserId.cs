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
    public class AcquireItemSetByUserId : AcquireAction {
        private string namespaceName;
        private string inventoryName;
        private string itemName;
        private string userId;
        private long acquireCount;
        private string acquireCountString;
        private long? expiresAt;
        private string expiresAtString;
        private bool? createNewItemSet;
        private string createNewItemSetString;
        private string itemSetName;
        private string timeOffsetToken;


        public AcquireItemSetByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            long acquireCount,
            long? expiresAt = null,
            bool? createNewItemSet = null,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.acquireCount = acquireCount;
            this.expiresAt = expiresAt;
            this.createNewItemSet = createNewItemSet;
            this.itemSetName = itemSetName;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public AcquireItemSetByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            string acquireCount,
            string expiresAt = null,
            string createNewItemSet = null,
            string itemSetName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.acquireCountString = acquireCount;
            this.expiresAtString = expiresAt;
            this.createNewItemSetString = createNewItemSet;
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
            if (this.itemName != null) {
                properties["itemName"] = this.itemName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.acquireCountString != null) {
                properties["acquireCount"] = this.acquireCountString;
            } else {
                if (this.acquireCount != null) {
                    properties["acquireCount"] = this.acquireCount;
                }
            }
            if (this.expiresAtString != null) {
                properties["expiresAt"] = this.expiresAtString;
            } else {
                if (this.expiresAt != null) {
                    properties["expiresAt"] = this.expiresAt;
                }
            }
            if (this.createNewItemSetString != null) {
                properties["createNewItemSet"] = this.createNewItemSetString;
            } else {
                if (this.createNewItemSet != null) {
                    properties["createNewItemSet"] = this.createNewItemSet;
                }
            }
            if (this.itemSetName != null) {
                properties["itemSetName"] = this.itemSetName;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static AcquireItemSetByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AcquireItemSetByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    (string)properties["itemName"],
                    new Func<long>(() =>
                    {
                        return properties["acquireCount"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("expiresAt", out var expiresAt) ? expiresAt switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("createNewItemSet", out var createNewItemSet) ? createNewItemSet switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })(),
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
                return new AcquireItemSetByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    properties["itemName"].ToString(),
                    properties["acquireCount"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("expiresAt", out var expiresAt) ? expiresAt.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("createNewItemSet", out var createNewItemSet) ? createNewItemSet.ToString() : null;
                    })(),
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
            return "Gs2Inventory:AcquireItemSetByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:AcquireItemSetByUserId";
        }
    }
}
