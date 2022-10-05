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
using Gs2Cdk.Gs2Experience.Resource;

namespace Gs2Cdk.Gs2Experience.Model
{

    public class Threshold
    {
	    private readonly string _metadata;
	    private readonly long[] _values;

        public Threshold(
                long[] values,
                string metadata = null
        )
        {
            this._metadata = metadata;
            this._values = values;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._values != null) {
                properties["Values"] = this._values;
            }
            return properties;
        }
    }
}
