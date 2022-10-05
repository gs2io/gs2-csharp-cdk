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
using Gs2Cdk.Gs2Ranking.Resource;

namespace Gs2Cdk.Gs2Ranking.Model
{

    public class Ranking
    {
	    private readonly long? _rank;
	    private readonly long? _index;
	    private readonly string _userId;
	    private readonly long? _score;
	    private readonly string _metadata;
	    private readonly long? _createdAt;

        public Ranking(
                long? rank,
                long? index,
                string userId,
                long? score,
                long? createdAt,
                string metadata = null
        )
        {
            this._rank = rank;
            this._index = index;
            this._userId = userId;
            this._score = score;
            this._metadata = metadata;
            this._createdAt = createdAt;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._rank != null) {
                properties["Rank"] = this._rank;
            }
            if (this._index != null) {
                properties["Index"] = this._index;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._score != null) {
                properties["Score"] = this._score;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._createdAt != null) {
                properties["CreatedAt"] = this._createdAt;
            }
            return properties;
        }
    }
}
