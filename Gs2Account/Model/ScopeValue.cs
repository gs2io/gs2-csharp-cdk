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
    public class ScopeValue {
        private string key;
        private string value;

        public ScopeValue(
            string key,
            ScopeValueOptions options = null
        ){
            this.key = key;
            this.value = options?.value;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.key != null) {
                properties["key"] = this.key;
            }
            if (this.value != null) {
                properties["value"] = this.value;
            }

            return properties;
        }

        public static ScopeValue FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ScopeValue(
                properties.TryGetValue("key", out var key) ? new Func<string>(() =>
                {
                    return (string) key;
                })() : default,
                new ScopeValueOptions {
                    value = properties.TryGetValue("value", out var value) ? (string)value : null
                }
            );

            return model;
        }
    }
}
