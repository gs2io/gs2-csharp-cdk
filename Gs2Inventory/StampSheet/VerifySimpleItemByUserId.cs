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
    public class VerifySimpleItemByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string inventoryName;
        private string itemName;
        private VerifySimpleItemByUserIdVerifyType? verifyType;
        private long count;
        private string? countString;
        private bool? multiplyValueSpecifyingQuantity;
        private string? multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifySimpleItemByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            VerifySimpleItemByUserIdVerifyType verifyType,
            long count,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.verifyType = verifyType;
            this.count = count;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifySimpleItemByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            VerifySimpleItemByUserIdVerifyType verifyType,
            string count,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.verifyType = verifyType;
            this.countString = count;
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
            if (this.itemName != null) {
                properties["itemName"] = this.itemName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
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

        public static VerifySimpleItemByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifySimpleItemByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    (string)properties["itemName"],
                    new Func<VerifySimpleItemByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifySimpleItemByUserIdVerifyType e => e,
                            string s => VerifySimpleItemByUserIdVerifyTypeExt.New(s),
                            _ => VerifySimpleItemByUserIdVerifyType.Less
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
                return new VerifySimpleItemByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    properties["itemName"].ToString(),
                    new Func<VerifySimpleItemByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifySimpleItemByUserIdVerifyType e => e,
                            string s => VerifySimpleItemByUserIdVerifyTypeExt.New(s),
                            _ => VerifySimpleItemByUserIdVerifyType.Less
                        };
                    })(),
                    properties["count"].ToString(),
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
            return "Gs2Inventory:VerifySimpleItemByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:VerifySimpleItemByUserId";
        }
    }
}
