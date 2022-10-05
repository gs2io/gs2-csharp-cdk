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
using Gs2Cdk.Gs2MegaField.Resource;

namespace Gs2Cdk.Gs2MegaField.Model
{

    public class Scope
    {
	    private readonly string _layerName;
	    private readonly float? _r;
	    private readonly int? _limit;

        public Scope(
                string layerName,
                float? r,
                int? limit
        )
        {
            this._layerName = layerName;
            this._r = r;
            this._limit = limit;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._layerName != null) {
                properties["LayerName"] = this._layerName;
            }
            if (this._r != null) {
                properties["R"] = this._r;
            }
            if (this._limit != null) {
                properties["Limit"] = this._limit;
            }
            return properties;
        }
    }
}
