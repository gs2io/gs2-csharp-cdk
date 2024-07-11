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
    public class VerifyInventoryCurrentMaxCapacityByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string inventoryName;
        private VerifyInventoryCurrentMaxCapacityByUserIdVerifyType? verifyType;
        private int currentInventoryMaxCapacity;
        private string currentInventoryMaxCapacityString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyInventoryCurrentMaxCapacityByUserId(
            string namespaceName,
            string inventoryName,
            VerifyInventoryCurrentMaxCapacityByUserIdVerifyType verifyType,
            int currentInventoryMaxCapacity,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.verifyType = verifyType;
            this.currentInventoryMaxCapacity = currentInventoryMaxCapacity;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyInventoryCurrentMaxCapacityByUserId(
            string namespaceName,
            string inventoryName,
            VerifyInventoryCurrentMaxCapacityByUserIdVerifyType verifyType,
            string currentInventoryMaxCapacity,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.verifyType = verifyType;
            this.currentInventoryMaxCapacityString = currentInventoryMaxCapacity;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
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
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.currentInventoryMaxCapacityString != null) {
                properties["currentInventoryMaxCapacity"] = this.currentInventoryMaxCapacityString;
            } else {
                if (this.currentInventoryMaxCapacity != null) {
                    properties["currentInventoryMaxCapacity"] = this.currentInventoryMaxCapacity;
                }
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyInventoryCurrentMaxCapacityByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyInventoryCurrentMaxCapacityByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    new Func<VerifyInventoryCurrentMaxCapacityByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyInventoryCurrentMaxCapacityByUserIdVerifyType e => e,
                            string s => VerifyInventoryCurrentMaxCapacityByUserIdVerifyTypeExt.New(s),
                            _ => VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Less
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
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
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
                return new VerifyInventoryCurrentMaxCapacityByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    new Func<VerifyInventoryCurrentMaxCapacityByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyInventoryCurrentMaxCapacityByUserIdVerifyType e => e,
                            string s => VerifyInventoryCurrentMaxCapacityByUserIdVerifyTypeExt.New(s),
                            _ => VerifyInventoryCurrentMaxCapacityByUserIdVerifyType.Less
                        };
                    })(),
                    properties["currentInventoryMaxCapacity"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
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
            return "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId";
        }
    }
}
