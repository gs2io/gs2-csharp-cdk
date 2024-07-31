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
    public class TakeOverTypeModel {
        private int type;
        private string typeString;
        private OpenIdConnectSetting openIdConnectSetting;
        private string metadata;

        public TakeOverTypeModel(
            int type,
            OpenIdConnectSetting openIdConnectSetting,
            TakeOverTypeModelOptions options = null
        ){
            this.type = type;
            this.openIdConnectSetting = openIdConnectSetting;
            this.metadata = options?.metadata;
        }


        public TakeOverTypeModel(
            string type,
            OpenIdConnectSetting openIdConnectSetting,
            TakeOverTypeModelOptions options = null
        ){
            this.typeString = type;
            this.openIdConnectSetting = openIdConnectSetting;
            this.metadata = options?.metadata;
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
            if (this.openIdConnectSetting != null) {
                properties["openIdConnectSetting"] = this.openIdConnectSetting?.Properties(
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
                properties.TryGetValue("openIdConnectSetting", out var openIdConnectSetting) ? new Func<OpenIdConnectSetting>(() =>
                {
                    return openIdConnectSetting switch {
                        OpenIdConnectSetting v => v,
                        OpenIdConnectSetting[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => OpenIdConnectSetting.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? OpenIdConnectSetting.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                new TakeOverTypeModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
