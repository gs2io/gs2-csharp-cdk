/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Key.Model;
using Gs2Cdk.Gs2Key.StampSheet;


namespace Gs2Cdk.Gs2Key.Ref
{
    public class GitHubApiKeyRef {
        private readonly string _namespaceName;
        private readonly string _apiKeyName;

        public GitHubApiKeyRef(
                string namespaceName,
                string apiKeyName
        ) {
            this._namespaceName = namespaceName;
            this._apiKeyName = apiKeyName;
        }

        public string Grn() {
            return new Join(
                ":",
                new string[] {
                    "grn",
                    "gs2",
                    GetAttr.Region().ToString(),
                    GetAttr.OwnerId().ToString(),
                    "key",
                    this._namespaceName,
                    "github",
                    this._apiKeyName
                }
            ).ToString();
        }
    }
}
