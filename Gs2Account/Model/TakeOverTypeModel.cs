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
using Gs2Cdk.Gs2Account.Model.Enums;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class TakeOverTypeModel {
        private int type;
        private string typeString;
        private TakeOverTypeModelTakeOverMethod? takeOverMethod;
        private string metadata;
        private OpenIdConnectSetting openIdConnectSetting;
        private IssuedCodeSetting issuedCodeSetting;

        public TakeOverTypeModel(
            int type,
            TakeOverTypeModelTakeOverMethod takeOverMethod,
            TakeOverTypeModelOptions options = null
        ){
            this.type = type;
            this.takeOverMethod = takeOverMethod;
            this.metadata = options?.metadata;
            this.openIdConnectSetting = options?.openIdConnectSetting;
            this.issuedCodeSetting = options?.issuedCodeSetting;
        }

        public static TakeOverTypeModel TakeOverMethodIsOpenIdConnect(
            int type,
            OpenIdConnectSetting openIdConnectSetting,
            TakeOverTypeModelTakeOverMethodIsOpenIdConnectOptions options = null
        ){
            return (new TakeOverTypeModel(
                type,
                TakeOverTypeModelTakeOverMethod.OpenIdConnect,
                new TakeOverTypeModelOptions {
                    openIdConnectSetting = openIdConnectSetting,
                    metadata = options?.metadata,
                }
            ));
        }

        public static TakeOverTypeModel TakeOverMethodIsIssuedCode(
            int type,
            IssuedCodeSetting issuedCodeSetting,
            TakeOverTypeModelTakeOverMethodIsIssuedCodeOptions options = null
        ){
            return (new TakeOverTypeModel(
                type,
                TakeOverTypeModelTakeOverMethod.IssuedCode,
                new TakeOverTypeModelOptions {
                    issuedCodeSetting = issuedCodeSetting,
                    metadata = options?.metadata,
                }
            ));
        }


        public TakeOverTypeModel(
            string type,
            TakeOverTypeModelTakeOverMethod takeOverMethod,
            TakeOverTypeModelOptions options = null
        ){
            this.typeString = type;
            this.takeOverMethod = takeOverMethod;
            this.metadata = options?.metadata;
            this.openIdConnectSetting = options?.openIdConnectSetting;
            this.issuedCodeSetting = options?.issuedCodeSetting;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.typeString != null) {
                properties["type"] = this.typeString;
            } else {
                if (this.type != null) {
                    properties["type"] = this.type;
                }
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.takeOverMethod != null) {
                properties["takeOverMethod"] = this.takeOverMethod.Value.Str(
                );
            }
            if (this.openIdConnectSetting != null) {
                properties["openIdConnectSetting"] = this.openIdConnectSetting?.Properties(
                );
            }
            if (this.issuedCodeSetting != null) {
                properties["issuedCodeSetting"] = this.issuedCodeSetting?.Properties(
                );
            }

            return properties;
        }

        public static TakeOverTypeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TakeOverTypeModel(
                properties.TryGetValue("type", out var type) ? new Func<int>(() =>
                {
                    return type switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("takeOverMethod", out var takeOverMethod) ? new Func<TakeOverTypeModelTakeOverMethod>(() =>
                {
                    return takeOverMethod switch {
                        TakeOverTypeModelTakeOverMethod e => e,
                        string s => TakeOverTypeModelTakeOverMethodExt.New(s),
                        _ => TakeOverTypeModelTakeOverMethod.OpenIdConnect
                    };
                })() : default,
                new TakeOverTypeModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    openIdConnectSetting = properties.TryGetValue("openIdConnectSetting", out var openIdConnectSetting) ? new Func<OpenIdConnectSetting>(() =>
                    {
                        return openIdConnectSetting switch {
                            OpenIdConnectSetting v => v,
                            Dictionary<string, object> v => OpenIdConnectSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    issuedCodeSetting = properties.TryGetValue("issuedCodeSetting", out var issuedCodeSetting) ? new Func<IssuedCodeSetting>(() =>
                    {
                        return issuedCodeSetting switch {
                            IssuedCodeSetting v => v,
                            Dictionary<string, object> v => IssuedCodeSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
