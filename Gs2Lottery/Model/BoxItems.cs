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
using Gs2Cdk.Gs2Lottery.Resource;

namespace Gs2Cdk.Gs2Lottery.Model
{

    public class BoxItems
    {
	    private readonly string _boxId;
	    private readonly string _prizeTableName;
	    private readonly string _userId;
	    private readonly BoxItem[] _items;

        public BoxItems(
                string boxId,
                string prizeTableName,
                string userId,
                BoxItem[] items = null
        )
        {
            this._boxId = boxId;
            this._prizeTableName = prizeTableName;
            this._userId = userId;
            this._items = items;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._boxId != null) {
                properties["BoxId"] = this._boxId;
            }
            if (this._prizeTableName != null) {
                properties["PrizeTableName"] = this._prizeTableName;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._items != null) {
                properties["Items"] = this._items.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }
    }
}
