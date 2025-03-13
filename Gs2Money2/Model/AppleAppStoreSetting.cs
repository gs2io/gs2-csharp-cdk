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
    public class AppleAppStoreSetting {
        private string bundleId;
        private string sharedSecretKey;
        private string issuerId;
        private string keyId;
        private string privateKeyPem;

        public AppleAppStoreSetting(
            AppleAppStoreSettingOptions options = null
        ){
            this.bundleId = options?.bundleId;
            this.sharedSecretKey = options?.sharedSecretKey;
            this.issuerId = options?.issuerId;
            this.keyId = options?.keyId;
            this.privateKeyPem = options?.privateKeyPem;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.bundleId != null) {
                properties["bundleId"] = this.bundleId;
            }
            if (this.sharedSecretKey != null) {
                properties["sharedSecretKey"] = this.sharedSecretKey;
            }
            if (this.issuerId != null) {
                properties["issuerId"] = this.issuerId;
            }
            if (this.keyId != null) {
                properties["keyId"] = this.keyId;
            }
            if (this.privateKeyPem != null) {
                properties["privateKeyPem"] = this.privateKeyPem;
            }

            return properties;
        }

        public static AppleAppStoreSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AppleAppStoreSetting(
                new AppleAppStoreSettingOptions {
                    bundleId = properties.TryGetValue("bundleId", out var bundleId) ? (string)bundleId : null,
                    sharedSecretKey = properties.TryGetValue("sharedSecretKey", out var sharedSecretKey) ? (string)sharedSecretKey : null,
                    issuerId = properties.TryGetValue("issuerId", out var issuerId) ? (string)issuerId : null,
                    keyId = properties.TryGetValue("keyId", out var keyId) ? (string)keyId : null,
                    privateKeyPem = properties.TryGetValue("privateKeyPem", out var privateKeyPem) ? (string)privateKeyPem : null
                }
            );

            return model;
        }
    }
}
