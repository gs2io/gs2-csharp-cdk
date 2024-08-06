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
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class InGameLogTag {
        private string key;
        private string value;

        public InGameLogTag(
            string key,
            string value,
            InGameLogTagOptions options = null
        ){
            this.key = key;
            this.value = value;
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

        public static InGameLogTag FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new InGameLogTag(
                properties.TryGetValue("key", out var key) ? new Func<string>(() =>
                {
                    return (string) key;
                })() : default,
                properties.TryGetValue("value", out var value) ? new Func<string>(() =>
                {
                    return (string) value;
                })() : default,
                new InGameLogTagOptions {
                }
            );

            return model;
        }
    }
}
