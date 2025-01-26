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
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class OpenIdConnectSetting {
        private string configurationPath;
        private string clientId;
        private string clientSecret;
        private string appleTeamId;
        private string appleKeyId;
        private string applePrivateKeyPem;
        private string doneEndpointUrl;
        private ScopeValue[] additionalScopeValues;
        private string[] additionalReturnValues;

        public OpenIdConnectSetting(
            string configurationPath,
            string clientId,
            OpenIdConnectSettingOptions options = null
        ){
            this.configurationPath = configurationPath;
            this.clientId = clientId;
            this.clientSecret = options?.clientSecret;
            this.appleTeamId = options?.appleTeamId;
            this.appleKeyId = options?.appleKeyId;
            this.applePrivateKeyPem = options?.applePrivateKeyPem;
            this.doneEndpointUrl = options?.doneEndpointUrl;
            this.additionalScopeValues = options?.additionalScopeValues;
            this.additionalReturnValues = options?.additionalReturnValues;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.configurationPath != null) {
                properties["configurationPath"] = this.configurationPath;
            }
            if (this.clientId != null) {
                properties["clientId"] = this.clientId;
            }
            if (this.clientSecret != null) {
                properties["clientSecret"] = this.clientSecret;
            }
            if (this.appleTeamId != null) {
                properties["appleTeamId"] = this.appleTeamId;
            }
            if (this.appleKeyId != null) {
                properties["appleKeyId"] = this.appleKeyId;
            }
            if (this.applePrivateKeyPem != null) {
                properties["applePrivateKeyPem"] = this.applePrivateKeyPem;
            }
            if (this.doneEndpointUrl != null) {
                properties["doneEndpointUrl"] = this.doneEndpointUrl;
            }
            if (this.additionalScopeValues != null) {
                properties["additionalScopeValues"] = this.additionalScopeValues.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.additionalReturnValues != null) {
                properties["additionalReturnValues"] = this.additionalReturnValues;
            }

            return properties;
        }

        public static OpenIdConnectSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new OpenIdConnectSetting(
                properties.TryGetValue("configurationPath", out var configurationPath) ? new Func<string>(() =>
                {
                    return (string) configurationPath;
                })() : default,
                properties.TryGetValue("clientId", out var clientId) ? new Func<string>(() =>
                {
                    return (string) clientId;
                })() : default,
                new OpenIdConnectSettingOptions {
                    clientSecret = properties.TryGetValue("clientSecret", out var clientSecret) ? (string)clientSecret : null,
                    appleTeamId = properties.TryGetValue("appleTeamId", out var appleTeamId) ? (string)appleTeamId : null,
                    appleKeyId = properties.TryGetValue("appleKeyId", out var appleKeyId) ? (string)appleKeyId : null,
                    applePrivateKeyPem = properties.TryGetValue("applePrivateKeyPem", out var applePrivateKeyPem) ? (string)applePrivateKeyPem : null,
                    doneEndpointUrl = properties.TryGetValue("doneEndpointUrl", out var doneEndpointUrl) ? (string)doneEndpointUrl : null,
                    additionalScopeValues = properties.TryGetValue("additionalScopeValues", out var additionalScopeValues) ? new Func<ScopeValue[]>(() =>
                    {
                        return additionalScopeValues switch {
                            ScopeValue[] v => v,
                            List<ScopeValue> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ScopeValue.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ScopeValue.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    additionalReturnValues = properties.TryGetValue("additionalReturnValues", out var additionalReturnValues) ? new Func<string[]>(() =>
                    {
                        return additionalReturnValues switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
