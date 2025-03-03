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
    public class RefundEvent {
        private string contentName;
        private RefundEventPlatform? platform;
        private AppleAppStoreVerifyReceiptEvent appleAppStoreRefundEvent;
        private GooglePlayVerifyReceiptEvent googlePlayRefundEvent;

        public RefundEvent(
            string contentName,
            RefundEventPlatform platform,
            RefundEventOptions options = null
        ){
            this.contentName = contentName;
            this.platform = platform;
            this.appleAppStoreRefundEvent = options?.appleAppStoreRefundEvent;
            this.googlePlayRefundEvent = options?.googlePlayRefundEvent;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.contentName != null) {
                properties["contentName"] = this.contentName;
            }
            if (this.platform != null) {
                properties["platform"] = this.platform.Value.Str(
                );
            }
            if (this.appleAppStoreRefundEvent != null) {
                properties["appleAppStoreRefundEvent"] = this.appleAppStoreRefundEvent?.Properties(
                );
            }
            if (this.googlePlayRefundEvent != null) {
                properties["googlePlayRefundEvent"] = this.googlePlayRefundEvent?.Properties(
                );
            }

            return properties;
        }

        public static RefundEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RefundEvent(
                properties.TryGetValue("contentName", out var contentName) ? new Func<string>(() =>
                {
                    return (string) contentName;
                })() : default,
                properties.TryGetValue("platform", out var platform) ? new Func<RefundEventPlatform>(() =>
                {
                    return platform switch {
                        RefundEventPlatform e => e,
                        string s => RefundEventPlatformExt.New(s),
                        _ => RefundEventPlatform.AppleAppStore
                    };
                })() : default,
                new RefundEventOptions {
                    appleAppStoreRefundEvent = properties.TryGetValue("appleAppStoreRefundEvent", out var appleAppStoreRefundEvent) ? new Func<AppleAppStoreVerifyReceiptEvent>(() =>
                    {
                        return appleAppStoreRefundEvent switch {
                            AppleAppStoreVerifyReceiptEvent v => v,
                            Dictionary<string, object> v => AppleAppStoreVerifyReceiptEvent.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    googlePlayRefundEvent = properties.TryGetValue("googlePlayRefundEvent", out var googlePlayRefundEvent) ? new Func<GooglePlayVerifyReceiptEvent>(() =>
                    {
                        return googlePlayRefundEvent switch {
                            GooglePlayVerifyReceiptEvent v => v,
                            Dictionary<string, object> v => GooglePlayVerifyReceiptEvent.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
