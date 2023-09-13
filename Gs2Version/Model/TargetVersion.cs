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
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Model.Options;

namespace Gs2Cdk.Gs2Version.Model
{
    public class TargetVersion {
        private string versionName;
        private Version_ version;
        private string body;
        private string signature;

        public TargetVersion(
            string versionName,
            Version_ version,
            TargetVersionOptions options = null
        ){
            this.versionName = versionName;
            this.version = version;
            this.body = options?.body;
            this.signature = options?.signature;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.versionName != null) {
                properties["versionName"] = this.versionName;
            }
            if (this.version != null) {
                properties["version"] = this.version?.Properties(
                );
            }
            if (this.body != null) {
                properties["body"] = this.body;
            }
            if (this.signature != null) {
                properties["signature"] = this.signature;
            }

            return properties;
        }

        public static TargetVersion FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TargetVersion(
                (string)properties["versionName"],
                new Func<Version_>(() =>
                {
                    return properties["version"] switch {
                        Version_ v => v,
                        Dictionary<string, object> v => Version_.FromProperties(v),
                        _ => null
                    };
                })(),
                new TargetVersionOptions {
                    body = properties.TryGetValue("body", out var body) ? (string)body : null,
                    signature = properties.TryGetValue("signature", out var signature) ? (string)signature : null
                }
            );

            return model;
        }
    }
}
