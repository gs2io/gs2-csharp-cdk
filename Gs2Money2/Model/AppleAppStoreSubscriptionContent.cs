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
    public class AppleAppStoreSubscriptionContent {
        private string subscriptionGroupIdentifier;

        public AppleAppStoreSubscriptionContent(
            AppleAppStoreSubscriptionContentOptions options = null
        ){
            this.subscriptionGroupIdentifier = options?.subscriptionGroupIdentifier;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.subscriptionGroupIdentifier != null) {
                properties["subscriptionGroupIdentifier"] = this.subscriptionGroupIdentifier;
            }

            return properties;
        }

        public static AppleAppStoreSubscriptionContent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AppleAppStoreSubscriptionContent(
                new AppleAppStoreSubscriptionContentOptions {
                    subscriptionGroupIdentifier = properties.TryGetValue("subscriptionGroupIdentifier", out var subscriptionGroupIdentifier) ? (string)subscriptionGroupIdentifier : null
                }
            );

            return model;
        }
    }
}
