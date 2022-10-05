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

    public class Ballot
    {
	    private readonly string _userId;
	    private readonly string _ratingName;
	    private readonly string _gatheringName;
	    private readonly int? _numberOfPlayer;

        public Ballot(
                string userId,
                string ratingName,
                string gatheringName,
                int? numberOfPlayer
        )
        {
            this._userId = userId;
            this._ratingName = ratingName;
            this._gatheringName = gatheringName;
            this._numberOfPlayer = numberOfPlayer;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._ratingName != null) {
                properties["RatingName"] = this._ratingName;
            }
            if (this._gatheringName != null) {
                properties["GatheringName"] = this._gatheringName;
            }
            if (this._numberOfPlayer != null) {
                properties["NumberOfPlayer"] = this._numberOfPlayer;
            }
            return properties;
        }
    }
}
