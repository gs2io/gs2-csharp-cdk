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

    public class GameResult
    {
	    private readonly int? _rank;
	    private readonly string _userId;

        public GameResult(
                int? rank,
                string userId
        )
        {
            this._rank = rank;
            this._userId = userId;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._rank != null) {
                properties["Rank"] = this._rank;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            return properties;
        }
    }
}
