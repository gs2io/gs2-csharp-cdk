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
        private float price;
        private int count;
        private string currency;
        private long? depositedAt;

        public DepositTransaction(
            float price,
            int count,
            DepositTransactionOptions options = null
        ){
            this.price = price;
            this.count = count;
            this.currency = options?.currency;
            this.depositedAt = options?.depositedAt;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.price != null) {
                properties["price"] = this.price;
            }
            if (this.currency != null) {
                properties["currency"] = this.currency;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }
            if (this.depositedAt != null) {
                properties["depositedAt"] = this.depositedAt;
            }

            return properties;
        }

        public static DepositTransaction FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DepositTransaction(
                new Func<float>(() =>
                {
                    return properties["price"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["count"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
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
