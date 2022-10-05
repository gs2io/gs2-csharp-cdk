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

    public class CapacityOfRole
    {
	    private readonly string _roleName;
	    private readonly string[] _roleAliases;
	    private readonly int? _capacity;
	    private readonly Player[] _participants;

        public CapacityOfRole(
                string roleName,
                int? capacity,
                string[] roleAliases = null,
                Player[] participants = null
        )
        {
            this._roleName = roleName;
            this._roleAliases = roleAliases;
            this._capacity = capacity;
            this._participants = participants;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._roleName != null) {
                properties["RoleName"] = this._roleName;
            }
            if (this._roleAliases != null) {
                properties["RoleAliases"] = this._roleAliases;
            }
            if (this._capacity != null) {
                properties["Capacity"] = this._capacity;
            }
            if (this._participants != null) {
                properties["Participants"] = this._participants.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }
    }
}
