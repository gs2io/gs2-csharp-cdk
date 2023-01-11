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
        private long? createdAt;
        private long? updatedAt;
        private string description;

        public GitHubApiKey(
            string name,
            string apiKey,
            string encryptionKeyName,
            long? createdAt,
            long? updatedAt,
            GitHubApiKeyOptions options = null
        ){
            this.name = name;
            this.apiKey = apiKey;
            this.encryptionKeyName = encryptionKeyName;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.description = options?.description;
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
            if (this.createdAt != null) {
                properties["createdAt"] = this.createdAt;
            }
            if (this.updatedAt != null) {
                properties["updatedAt"] = this.updatedAt;
            }

            return properties;
        }
    }
}
