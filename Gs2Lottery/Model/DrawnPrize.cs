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

namespace Gs2Cdk.Gs2Lottery.Model
{

    public class DrawnPrize
    {
	    private readonly string _prizeId;
	    private readonly AcquireAction[] _acquireActions;

        public DrawnPrize(
                string prizeId,
                AcquireAction[] acquireActions = null
        )
        {
            this._prizeId = prizeId;
            this._acquireActions = acquireActions;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._prizeId != null) {
                properties["PrizeId"] = this._prizeId;
            }
            if (this._acquireActions != null) {
                properties["AcquireActions"] = this._acquireActions.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }
    }
}
