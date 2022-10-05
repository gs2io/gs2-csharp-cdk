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

    public class Status
    {
	    private readonly VersionModel _versionModel;
	    private readonly Version_ _currentVersion;

        public Status(
                VersionModel versionModel,
                Version_ currentVersion = null
        )
        {
            this._versionModel = versionModel;
            this._currentVersion = currentVersion;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._versionModel != null) {
                properties["VersionModel"] = this._versionModel.Properties();
            }
            if (this._currentVersion != null) {
                properties["CurrentVersion"] = this._currentVersion.Properties();
            }
            return properties;
        }
    }
}
