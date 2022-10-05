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
using Gs2Cdk.Gs2Matchmaking.Resource;

namespace Gs2Cdk.Gs2Matchmaking.Model
{

    public class Player
    {
	    private readonly string _userId;
	    private readonly Attribute_[] _attributes;
	    private readonly string _roleName;
	    private readonly string[] _denyUserIds;

        public Player(
                string userId,
                string roleName,
                Attribute_[] attributes = null,
                string[] denyUserIds = null
        )
        {
            this._userId = userId;
            this._attributes = attributes;
            this._roleName = roleName;
            this._denyUserIds = denyUserIds;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._attributes != null) {
                properties["Attributes"] = this._attributes.Select(v => v.Properties()).ToArray();
            }
            if (this._roleName != null) {
                properties["RoleName"] = this._roleName;
            }
            if (this._denyUserIds != null) {
                properties["DenyUserIds"] = this._denyUserIds;
            }
            return properties;
        }
    }
}
