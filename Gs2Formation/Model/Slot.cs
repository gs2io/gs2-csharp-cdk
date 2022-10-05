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
using Gs2Cdk.Gs2Formation.Resource;

namespace Gs2Cdk.Gs2Formation.Model
{

    public class Slot
    {
	    private readonly string _name;
	    private readonly string _propertyId;
	    private readonly string _metadata;

        public Slot(
                string name,
                string propertyId,
                string metadata = null
        )
        {
            this._name = name;
            this._propertyId = propertyId;
            this._metadata = metadata;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._propertyId != null) {
                properties["PropertyId"] = this._propertyId;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            return properties;
        }
    }
}
