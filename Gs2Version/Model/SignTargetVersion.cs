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
using Gs2Cdk.Gs2Version.Resource;

namespace Gs2Cdk.Gs2Version.Model
{

    public class SignTargetVersion
    {
	    private readonly string _region;
	    private readonly string _ownerId;
	    private readonly string _namespaceName;
	    private readonly string _versionName;
	    private readonly Version_ _version;

        public SignTargetVersion(
                string region,
                string ownerId,
                string namespaceName,
                string versionName,
                Version_ version
        )
        {
            this._region = region;
            this._ownerId = ownerId;
            this._namespaceName = namespaceName;
            this._versionName = versionName;
            this._version = version;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._region != null) {
                properties["Region"] = this._region;
            }
            if (this._ownerId != null) {
                properties["OwnerId"] = this._ownerId;
            }
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._versionName != null) {
                properties["VersionName"] = this._versionName;
            }
            if (this._version != null) {
                properties["Version"] = this._version.Properties();
            }
            return properties;
        }
    }
}
