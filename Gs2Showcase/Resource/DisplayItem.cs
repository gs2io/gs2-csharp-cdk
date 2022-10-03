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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Ref;

namespace Gs2Cdk.Gs2Showcase.Resource
{

    public static class DisplayItemTypeExt
    {
        public static string ToString(this DisplayItem.Type self)
        {
            switch (self) {
                case DisplayItem.Type.SalesItem:
                    return "salesItem";
                case DisplayItem.Type.SalesItemGroup:
                    return "salesItemGroup";
            }
            return "unknown";
        }
    }

    public class DisplayItem {

        public enum Type
        {
            SalesItem,
            SalesItemGroup
        }
	    private readonly string _displayItemId;
	    private readonly Type _type;
	    private readonly SalesItem _salesItem;
	    private readonly SalesItemGroup _salesItemGroup;
	    private readonly string _salesPeriodEventId;

        public DisplayItem(
                string displayItemId,
                Type type,
                SalesItem salesItem = null,
                SalesItemGroup salesItemGroup = null,
                string salesPeriodEventId = null
        )
        {
            this._displayItemId = displayItemId;
            this._type = type;
            this._salesItem = salesItem;
            this._salesItemGroup = salesItemGroup;
            this._salesPeriodEventId = salesPeriodEventId;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._displayItemId != null) {
                properties["DisplayItemId"] = this._displayItemId;
            }
            if (this._type != null) {
                properties["Type"] = this._type.ToString();
            }
            if (this._salesItem != null) {
                properties["SalesItem"] = this._salesItem.Properties();
            }
            if (this._salesItemGroup != null) {
                properties["SalesItemGroup"] = this._salesItemGroup.Properties();
            }
            if (this._salesPeriodEventId != null) {
                properties["SalesPeriodEventId"] = this._salesPeriodEventId;
            }
            return properties;
        }

        public DisplayItemRef Ref(
                string namespaceName
        )
        {
            return new DisplayItemRef(
                namespaceName
            );
        }
    }
}
