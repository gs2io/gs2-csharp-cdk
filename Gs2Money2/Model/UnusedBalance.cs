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
    public class UnusedBalance {
        private string currency;
        private float balance;
        private string balanceString;
        private long? revision;
        private string revisionString;

        public UnusedBalance(
            string currency,
            float balance,
            UnusedBalanceOptions options = null
        ){
            this.currency = currency;
            this.balance = balance;
            this.revision = options?.revision;
        }


        public UnusedBalance(
            string currency,
            string balance,
            UnusedBalanceOptions options = null
        ){
            this.currency = currency;
            this.balanceString = balance;
            this.revision = options?.revision;
            this.revisionString = options?.revisionString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.currency != null) {
                properties["currency"] = this.currency;
            }
            if (this.balanceString != null) {
                properties["balance"] = this.balanceString;
            } else {
                if (this.balance != null) {
                    properties["balance"] = this.balance;
                }
            }

            return properties;
        }

        public static UnusedBalance FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnusedBalance(
                (string)properties["currency"],
                new Func<float>(() =>
                {
                    return properties["balance"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new UnusedBalanceOptions {
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
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
