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
    public class AppleAppStoreContent {
        private string productId;

        public AppleAppStoreContent(
            AppleAppStoreContentOptions options = null
        ){
            this.productId = options?.productId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.productId != null) {
                properties["productId"] = this.productId;
            }

            return properties;
        }

        public static AppleAppStoreContent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AppleAppStoreContent(
                new AppleAppStoreContentOptions {
                    productId = properties.TryGetValue("productId", out var productId) ? (string)productId : null
                }
            );

            return model;
        }
    }
}
