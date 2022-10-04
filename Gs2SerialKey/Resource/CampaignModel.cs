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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.Ref;

namespace Gs2Cdk.Gs2SerialKey.Resource
{

    public class CampaignModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly bool? _enableCampaignCode;

        public CampaignModel(
                string name,
                bool? enableCampaignCode,
                string metadata = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._enableCampaignCode = enableCampaignCode;
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
            if (this._enableCampaignCode != null) {
                properties["EnableCampaignCode"] = this._enableCampaignCode;
            }
            return properties;
        }

        public CampaignModelRef Ref(
                string namespaceName
        )
        {
            return new CampaignModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
