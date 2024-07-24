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
    public class WithdrawEvent {
        private int slot;
        private string slotString;
        private WalletSummary status;
        private DepositTransaction[] withdrawDetails;

        public WithdrawEvent(
            int slot,
            WalletSummary status,
            WithdrawEventOptions options = null
        ){
            this.slot = slot;
            this.status = status;
            this.withdrawDetails = options?.withdrawDetails;
        }


        public WithdrawEvent(
            string slot,
            WalletSummary status,
            WithdrawEventOptions options = null
        ){
            this.slotString = slot;
            this.status = status;
            this.withdrawDetails = options?.withdrawDetails;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.slotString != null) {
                properties["slot"] = this.slotString;
            } else {
                if (this.slot != null) {
                    properties["slot"] = this.slot;
                }
            }
            if (this.withdrawDetails != null) {
                properties["withdrawDetails"] = this.withdrawDetails.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.status != null) {
                properties["status"] = this.status?.Properties(
                );
            }

            return properties;
        }

        public static WithdrawEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new WithdrawEvent(
                properties.TryGetValue("slot", out var slot) ? new Func<int>(() =>
                {
                    return slot switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("status", out var status) ? new Func<WalletSummary>(() =>
                {
                    return status switch {
                        WalletSummary v => v,
                        WalletSummary[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => WalletSummary.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? WalletSummary.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                new WithdrawEventOptions {
                    withdrawDetails = properties.TryGetValue("withdrawDetails", out var withdrawDetails) ? new Func<DepositTransaction[]>(() =>
                    {
                        return withdrawDetails switch {
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
