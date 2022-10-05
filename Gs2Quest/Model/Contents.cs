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
using Gs2Cdk.Gs2Quest.Resource;

namespace Gs2Cdk.Gs2Quest.Model
{

    public class Contents
    {
	    private readonly string _metadata;
	    private readonly AcquireAction[] _completeAcquireActions;
	    private readonly int? _weight;

        public Contents(
                int? weight,
                string metadata = null,
                AcquireAction[] completeAcquireActions = null
        )
        {
            this._metadata = metadata;
            this._completeAcquireActions = completeAcquireActions;
            this._weight = weight;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._completeAcquireActions != null) {
                properties["CompleteAcquireActions"] = this._completeAcquireActions.Select(v => v.Properties()).ToArray();
            }
            if (this._weight != null) {
                properties["Weight"] = this._weight;
            }
            return properties;
        }
    }
}
