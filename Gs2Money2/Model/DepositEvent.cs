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
    public class DepositEvent {
        private int slot;
        private WalletSummary status;
        private DepositTransaction[] depositTransactions;

        public DepositEvent(
            int slot,
            WalletSummary status,
            DepositEventOptions options = null
        ){
            this.slot = slot;
            this.status = status;
            this.depositTransactions = options?.depositTransactions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.slot != null) {
                properties["slot"] = this.slot;
            }
            if (this.depositTransactions != null) {
                properties["depositTransactions"] = this.depositTransactions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.status != null) {
                properties["status"] = this.status?.Properties(
                );
            }

            return properties;
        }

        public static DepositEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DepositEvent(
                new Func<int>(() =>
                {
                    return properties["slot"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<WalletSummary>(() =>
                {
                    return properties["status"] switch {
                        WalletSummary v => v,
                        WalletSummary[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => WalletSummary.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? WalletSummary.FromProperties(v.First()) : null,
                        _ => null
                    };
                })(),
                new DepositEventOptions {
                    depositTransactions = properties.TryGetValue("depositTransactions", out var depositTransactions) ? new Func<DepositTransaction[]>(() =>
                    {
                        return depositTransactions switch {
                            DepositTransaction[] v => v,
                            List<DepositTransaction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
