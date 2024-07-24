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
using Gs2Cdk.Gs2Money.Model;
using Gs2Cdk.Gs2Money.Model.Options;

namespace Gs2Cdk.Gs2Money.Model
{
    public class WalletDetail {
        private float price;
        private string priceString;
        private int count;
        private string countString;

        public WalletDetail(
            float price,
            int count,
            WalletDetailOptions options = null
        ){
            this.price = price;
            this.count = count;
        }


        public WalletDetail(
            string price,
            string count,
            WalletDetailOptions options = null
        ){
            this.priceString = price;
            this.countString = count;
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
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }

            return properties;
        }

        public static WalletDetail FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new WalletDetail(
                properties.TryGetValue("price", out var price) ? new Func<float>(() =>
                {
                    return price switch {
                        float v => v,
                        string v => float.Parse(v),
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
                new WalletDetailOptions {
                }
            );

            return model;
        }
    }
}
