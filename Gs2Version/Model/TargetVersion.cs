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

    public class TargetVersion
    {
	    private readonly string _versionName;
	    private readonly Version_ _version;
	    private readonly string _body;
	    private readonly string _signature;

        public TargetVersion(
                string versionName,
                Version_ version,
                string body = null,
                string signature = null
        )
        {
            this._versionName = versionName;
            this._version = version;
            this._body = body;
            this._signature = signature;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._versionName != null) {
                properties["VersionName"] = this._versionName;
            }
            if (this._version != null) {
                properties["Version"] = this._version.Properties();
            }
            if (this._body != null) {
                properties["Body"] = this._body;
            }
            if (this._signature != null) {
                properties["Signature"] = this._signature;
            }
            return properties;
        }
    }
}
