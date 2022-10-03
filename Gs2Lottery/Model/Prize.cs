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

    public static class PrizeTypeExt
    {
        public static string ToString(this Prize.Type self)
        {
            switch (self) {
                case Prize.Type.Action:
                    return "action";
                case Prize.Type.PrizeTable:
                    return "prize_table";
            }
            return "unknown";
        }
    }

    public class Prize
    {

        public enum Type
        {
            Action,
            PrizeTable
        }
	    private readonly string _prizeId;
	    private readonly Type _type;
	    private readonly AcquireAction[] _acquireActions;
	    private readonly int? _drawnLimit;
	    private readonly string _limitFailOverPrizeId;
	    private readonly string _prizeTableName;
	    private readonly int? _weight;

        public Prize(
                string prizeId,
                Type type,
                int? weight,
                AcquireAction[] acquireActions = null,
                int? drawnLimit = null,
                string limitFailOverPrizeId = null,
                string prizeTableName = null
        )
        {
            this._prizeId = prizeId;
            this._type = type;
            this._acquireActions = acquireActions;
            this._drawnLimit = drawnLimit;
            this._limitFailOverPrizeId = limitFailOverPrizeId;
            this._prizeTableName = prizeTableName;
            this._weight = weight;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._prizeId != null) {
                properties["PrizeId"] = this._prizeId;
            }
            if (this._type != null) {
                properties["Type"] = this._type.ToString();
            }
            if (this._acquireActions != null) {
                properties["AcquireActions"] = this._acquireActions.Select(v => v.Properties()).ToArray();
            }
            if (this._drawnLimit != null) {
                properties["DrawnLimit"] = this._drawnLimit;
            }
            if (this._limitFailOverPrizeId != null) {
                properties["LimitFailOverPrizeId"] = this._limitFailOverPrizeId;
            }
            if (this._prizeTableName != null) {
                properties["PrizeTableName"] = this._prizeTableName;
            }
            if (this._weight != null) {
                properties["Weight"] = this._weight;
            }
            return properties;
        }
    }
}
