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
using Gs2Cdk.Gs2Auth.Resource;

namespace Gs2Cdk.Gs2Auth.Model
{

    public class AccessToken
    {
	    private readonly string _ownerId;
	    private readonly string _token;
	    private readonly string _userId;
	    private readonly long? _expire;
	    private readonly int? _timeOffset;

        public AccessToken(
                string ownerId,
                string token,
                string userId,
                long? expire,
                int? timeOffset
        )
        {
            this._ownerId = ownerId;
            this._token = token;
            this._userId = userId;
            this._expire = expire;
            this._timeOffset = timeOffset;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._ownerId != null) {
                properties["OwnerId"] = this._ownerId;
            }
            if (this._token != null) {
                properties["Token"] = this._token;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._expire != null) {
                properties["Expire"] = this._expire;
            }
            if (this._timeOffset != null) {
                properties["TimeOffset"] = this._timeOffset;
            }
            return properties;
        }
    }
}
