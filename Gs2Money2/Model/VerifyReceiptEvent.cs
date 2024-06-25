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
    public class VerifyReceiptEvent {
        private string contentName;
        private VerifyReceiptEventPlatform? platform;
        private AppleAppStoreVerifyReceiptEvent appleAppStoreVerifyReceiptEvent;
        private GooglePlayVerifyReceiptEvent googlePlayVerifyReceiptEvent;

        public VerifyReceiptEvent(
            string contentName,
            VerifyReceiptEventPlatform platform,
            VerifyReceiptEventOptions options = null
        ){
            this.contentName = contentName;
            this.platform = platform;
            this.appleAppStoreVerifyReceiptEvent = options?.appleAppStoreVerifyReceiptEvent;
            this.googlePlayVerifyReceiptEvent = options?.googlePlayVerifyReceiptEvent;
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
            if (this.appleAppStoreVerifyReceiptEvent != null) {
                properties["appleAppStoreVerifyReceiptEvent"] = this.appleAppStoreVerifyReceiptEvent?.Properties(
                );
            }
            if (this.googlePlayVerifyReceiptEvent != null) {
                properties["googlePlayVerifyReceiptEvent"] = this.googlePlayVerifyReceiptEvent?.Properties(
                );
            }

            return properties;
        }

        public static VerifyReceiptEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new VerifyReceiptEvent(
                (string)properties["contentName"],
                new Func<VerifyReceiptEventPlatform>(() =>
                {
                    return properties["platform"] switch {
                        VerifyReceiptEventPlatform e => e,
                        string s => VerifyReceiptEventPlatformExt.New(s),
                        _ => VerifyReceiptEventPlatform.AppleAppStore
                    };
                })(),
                new VerifyReceiptEventOptions {
                    appleAppStoreVerifyReceiptEvent = properties.TryGetValue("appleAppStoreVerifyReceiptEvent", out var appleAppStoreVerifyReceiptEvent) ? new Func<AppleAppStoreVerifyReceiptEvent>(() =>
                    {
                        return appleAppStoreVerifyReceiptEvent switch {
                            AppleAppStoreVerifyReceiptEvent v => v,
                            Dictionary<string, object> v => AppleAppStoreVerifyReceiptEvent.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    googlePlayVerifyReceiptEvent = properties.TryGetValue("googlePlayVerifyReceiptEvent", out var googlePlayVerifyReceiptEvent) ? new Func<GooglePlayVerifyReceiptEvent>(() =>
                    {
                        return googlePlayVerifyReceiptEvent switch {
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
