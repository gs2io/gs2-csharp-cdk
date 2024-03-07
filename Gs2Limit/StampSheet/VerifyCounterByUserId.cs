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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.StampSheet.Enums;

namespace Gs2Cdk.Gs2Limit.StampSheet
{
    public class VerifyCounterByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string limitName;
        private string counterName;
        private VerifyCounterByUserIdVerifyType? verifyType;
        private int? count;
        private string? countString;
        private bool? multiplyValueSpecifyingQuantity;
        private string? multiplyValueSpecifyingQuantityString;


        public VerifyCounterByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            VerifyCounterByUserIdVerifyType verifyType,
            int? count = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.verifyType = verifyType;
            this.count = count;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.userId = userId;
        }


        public VerifyCounterByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            VerifyCounterByUserIdVerifyType verifyType,
            string count = null,
            string multiplyValueSpecifyingQuantity = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.verifyType = verifyType;
            this.countString = count;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
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
            if (this.limitName != null) {
                properties["limitName"] = this.limitName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
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

            return properties;
        }

        public static VerifyCounterByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCounterByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["limitName"],
                    (string)properties["counterName"],
                    new Func<VerifyCounterByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCounterByUserIdVerifyType e => e,
                            string s => VerifyCounterByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCounterByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        } : null;
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyCounterByUserId(
                    properties["namespaceName"].ToString(),
                    properties["limitName"].ToString(),
                    properties["counterName"].ToString(),
                    new Func<VerifyCounterByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCounterByUserIdVerifyType e => e,
                            string s => VerifyCounterByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCounterByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Limit:VerifyCounterByUserId";
        }

        public static string StaticAction() {
            return "Gs2Limit:VerifyCounterByUserId";
        }
    }
}
