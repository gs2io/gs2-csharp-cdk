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
using Gs2Cdk.Gs2Distributor.Model;
using Gs2Cdk.Gs2Distributor.Ref;

namespace Gs2Cdk.Gs2Distributor.Resource
{

    public class DistributorModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly string _inboxNamespaceId;
	    private readonly string[] _whiteListTargetIds;

        public DistributorModel(
                string name,
                string metadata = null,
                string inboxNamespaceId = null,
                string[] whiteListTargetIds = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._inboxNamespaceId = inboxNamespaceId;
            this._whiteListTargetIds = whiteListTargetIds;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._inboxNamespaceId != null) {
                properties["InboxNamespaceId"] = this._inboxNamespaceId;
            }
            if (this._whiteListTargetIds != null) {
                properties["WhiteListTargetIds"] = this._whiteListTargetIds;
            }
            return properties;
        }

        public DistributorModelRef Ref(
                string namespaceName
        )
        {
            return new DistributorModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
