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
using Gs2Cdk.Gs2Money2.Model.Enums;
using Gs2Cdk.Gs2Money2.Model.Options;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class Receipt {
        private ReceiptStore? store;
        private string transactionID;
        private string payload;

        public Receipt(
            ReceiptStore store,
            string transactionID,
            string payload,
            ReceiptOptions options = null
        ){
            this.store = store;
            this.transactionID = transactionID;
            this.payload = payload;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.store != null) {
                properties["store"] = this.store.Value.Str(
                );
            }
            if (this.transactionID != null) {
                properties["transactionID"] = this.transactionID;
            }
            if (this.payload != null) {
                properties["payload"] = this.payload;
            }

            return properties;
        }

        public static Receipt FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Receipt(
                new Func<ReceiptStore>(() =>
                {
                    return properties["Store"] switch {
                        ReceiptStore e => e,
                        string s => ReceiptStoreExt.New(s),
                        _ => ReceiptStore.AppleAppStore
                    };
                })(),
                (string)properties["TransactionID"],
                (string)properties["Payload"],
                new ReceiptOptions {
                }
            );

            return model;
        }
    }
}
