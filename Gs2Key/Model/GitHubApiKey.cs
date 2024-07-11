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
using Gs2Cdk.Gs2Key.Model;
using Gs2Cdk.Gs2Key.Model.Options;

namespace Gs2Cdk.Gs2Key.Model
{
    public class GitHubApiKey {
        private string name;
        private string apiKey;
        private string encryptionKeyName;
        private string description;
        private long? revision;
        private string revisionString;

        public GitHubApiKey(
            string name,
            string apiKey,
            string encryptionKeyName,
            GitHubApiKeyOptions options = null
        ){
            this.name = name;
            this.apiKey = apiKey;
            this.encryptionKeyName = encryptionKeyName;
            this.description = options?.description;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.description != null) {
                properties["description"] = this.description;
            }
            if (this.apiKey != null) {
                properties["apiKey"] = this.apiKey;
            }
            if (this.encryptionKeyName != null) {
                properties["encryptionKeyName"] = this.encryptionKeyName;
            }

            return properties;
        }

        public static GitHubApiKey FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GitHubApiKey(
                (string)properties["name"],
                (string)properties["apiKey"],
                (string)properties["encryptionKeyName"],
                new GitHubApiKeyOptions {
                    description = properties.TryGetValue("description", out var description) ? (string)description : null,
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
