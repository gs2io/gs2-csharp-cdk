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
using Gs2Cdk.Gs2Money2.Model;
using Gs2Cdk.Gs2Money2.Model.Options;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class DepositTransaction {
        private double price;
        private string priceString;
        private int count;
        private string countString;
        private string currency;
        private long? depositedAt;
        private string depositedAtString;

        public DepositTransaction(
            double price,
            int count,
            DepositTransactionOptions options = null
        ){
            this.price = price;
            this.count = count;
            this.currency = options?.currency;
            this.depositedAt = options?.depositedAt;
        }


        public DepositTransaction(
            string price,
            string count,
            DepositTransactionOptions options = null
        ){
            this.priceString = price;
            this.countString = count;
            this.currency = options?.currency;
            this.depositedAt = options?.depositedAt;
            this.depositedAtString = options?.depositedAtString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.priceString != null) {
                properties["price"] = this.priceString;
            } else {
                if (this.price != null) {
                    properties["price"] = this.price;
                }
            }
            if (this.currency != null) {
                properties["currency"] = this.currency;
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }
            if (this.depositedAtString != null) {
                properties["depositedAt"] = this.depositedAtString;
            } else {
                if (this.depositedAt != null) {
                    properties["depositedAt"] = this.depositedAt;
                }
            }

            return properties;
        }

        public static DepositTransaction FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DepositTransaction(
                properties.TryGetValue("price", out var price) ? new Func<double>(() =>
                {
                    return price switch {
                        double v => v,
                        string v => double.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("count", out var count) ? new Func<int>(() =>
                {
                    return count switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new DepositTransactionOptions {
                    currency = properties.TryGetValue("currency", out var currency) ? (string)currency : null,
                    depositedAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("depositedAt", out var depositedAt) ? depositedAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
