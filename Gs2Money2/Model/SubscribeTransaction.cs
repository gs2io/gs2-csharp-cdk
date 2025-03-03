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
    public class SubscribeTransaction {
        private string contentName;
        private string transactionId;
        private SubscribeTransactionStore? store;
        private SubscribeTransactionStatusDetail? statusDetail;
        private long expiresAt;
        private string expiresAtString;
        private string userId;
        private long? lastAllocatedAt;
        private string lastAllocatedAtString;
        private long? lastTakeOverAt;
        private string lastTakeOverAtString;
        private long? revision;
        private string revisionString;

        public SubscribeTransaction(
            string contentName,
            string transactionId,
            SubscribeTransactionStore store,
            SubscribeTransactionStatusDetail statusDetail,
            long expiresAt,
            SubscribeTransactionOptions options = null
        ){
            this.contentName = contentName;
            this.transactionId = transactionId;
            this.store = store;
            this.statusDetail = statusDetail;
            this.expiresAt = expiresAt;
            this.userId = options?.userId;
            this.lastAllocatedAt = options?.lastAllocatedAt;
            this.lastTakeOverAt = options?.lastTakeOverAt;
            this.revision = options?.revision;
        }


        public SubscribeTransaction(
            string contentName,
            string transactionId,
            SubscribeTransactionStore store,
            SubscribeTransactionStatusDetail statusDetail,
            string expiresAt,
            SubscribeTransactionOptions options = null
        ){
            this.contentName = contentName;
            this.transactionId = transactionId;
            this.store = store;
            this.statusDetail = statusDetail;
            this.expiresAtString = expiresAt;
            this.userId = options?.userId;
            this.lastAllocatedAt = options?.lastAllocatedAt;
            this.lastAllocatedAtString = options?.lastAllocatedAtString;
            this.lastTakeOverAt = options?.lastTakeOverAt;
            this.lastTakeOverAtString = options?.lastTakeOverAtString;
            this.revision = options?.revision;
            this.revisionString = options?.revisionString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.contentName != null) {
                properties["contentName"] = this.contentName;
            }
            if (this.transactionId != null) {
                properties["transactionId"] = this.transactionId;
            }
            if (this.store != null) {
                properties["store"] = this.store.Value.Str(
                );
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.statusDetail != null) {
                properties["statusDetail"] = this.statusDetail.Value.Str(
                );
            }
            if (this.expiresAtString != null) {
                properties["expiresAt"] = this.expiresAtString;
            } else {
                if (this.expiresAt != null) {
                    properties["expiresAt"] = this.expiresAt;
                }
            }
            if (this.lastAllocatedAtString != null) {
                properties["lastAllocatedAt"] = this.lastAllocatedAtString;
            } else {
                if (this.lastAllocatedAt != null) {
                    properties["lastAllocatedAt"] = this.lastAllocatedAt;
                }
            }
            if (this.lastTakeOverAtString != null) {
                properties["lastTakeOverAt"] = this.lastTakeOverAtString;
            } else {
                if (this.lastTakeOverAt != null) {
                    properties["lastTakeOverAt"] = this.lastTakeOverAt;
                }
            }

            return properties;
        }

        public static SubscribeTransaction FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SubscribeTransaction(
                properties.TryGetValue("contentName", out var contentName) ? new Func<string>(() =>
                {
                    return (string) contentName;
                })() : default,
                properties.TryGetValue("transactionId", out var transactionId) ? new Func<string>(() =>
                {
                    return (string) transactionId;
                })() : default,
                properties.TryGetValue("store", out var store) ? new Func<SubscribeTransactionStore>(() =>
                {
                    return store switch {
                        SubscribeTransactionStore e => e,
                        string s => SubscribeTransactionStoreExt.New(s),
                        _ => SubscribeTransactionStore.AppleAppStore
                    };
                })() : default,
                properties.TryGetValue("statusDetail", out var statusDetail) ? new Func<SubscribeTransactionStatusDetail>(() =>
                {
                    return statusDetail switch {
                        SubscribeTransactionStatusDetail e => e,
                        string s => SubscribeTransactionStatusDetailExt.New(s),
                        _ => SubscribeTransactionStatusDetail.ActiveActive
                    };
                })() : default,
                properties.TryGetValue("expiresAt", out var expiresAt) ? new Func<long>(() =>
                {
                    return expiresAt switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new SubscribeTransactionOptions {
                    userId = properties.TryGetValue("userId", out var userId) ? (string)userId : null,
                    lastAllocatedAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("lastAllocatedAt", out var lastAllocatedAt) ? lastAllocatedAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    lastTakeOverAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("lastTakeOverAt", out var lastTakeOverAt) ? lastTakeOverAt switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
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
