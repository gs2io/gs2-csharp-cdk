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
    public class WalletSummary {
        private int? paid;
        private string paidString;
        private int? free;
        private string freeString;
        private int? total;
        private string totalString;

        public WalletSummary(
            int? paid,
            int? free,
            int? total,
            WalletSummaryOptions options = null
        ){
            this.paid = paid;
            this.free = free;
            this.total = total;
        }


        public WalletSummary(
            string paid,
            string free,
            string total,
            WalletSummaryOptions options = null
        ){
            this.paidString = paid;
            this.freeString = free;
            this.totalString = total;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.paidString != null) {
                properties["paid"] = this.paidString;
            } else {
                if (this.paid != null) {
                    properties["paid"] = this.paid;
                }
            }
            if (this.freeString != null) {
                properties["free"] = this.freeString;
            } else {
                if (this.free != null) {
                    properties["free"] = this.free;
                }
            }
            if (this.totalString != null) {
                properties["total"] = this.totalString;
            } else {
                if (this.total != null) {
                    properties["total"] = this.total;
                }
            }

            return properties;
        }

        public static WalletSummary FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new WalletSummary(
                properties.TryGetValue("paid", out var paid) ? new Func<int?>(() =>
                {
                    return paid switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("free", out var free) ? new Func<int?>(() =>
                {
                    return free switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("total", out var total) ? new Func<int?>(() =>
                {
                    return total switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new WalletSummaryOptions {
                }
            );

            return model;
        }
    }
}
