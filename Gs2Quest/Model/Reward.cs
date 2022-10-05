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

    public class Reward
    {
	    private readonly string _action;
	    private readonly string _request;
	    private readonly string _itemId;
	    private readonly int? _value;

        public Reward(
                string action,
                string request,
                string itemId,
                int? value
        )
        {
            this._action = action;
            this._request = request;
            this._itemId = itemId;
            this._value = value;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._action != null) {
                properties["Action"] = this._action;
            }
            if (this._request != null) {
                properties["Request"] = this._request;
            }
            if (this._itemId != null) {
                properties["ItemId"] = this._itemId;
            }
            if (this._value != null) {
                properties["Value"] = this._value;
            }
            return properties;
        }
    }
}
