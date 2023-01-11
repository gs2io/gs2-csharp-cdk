/*
 * Copyright 2016- Game Server Services, Inc. or its affiliates. All Rights
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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Model.Enums;
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class DisplayItem {
        private string displayItemId;
        private DisplayItemType? type;
        private SalesItem salesItem;
        private SalesItemGroup salesItemGroup;
        private string salesPeriodEventId;

        public DisplayItem(
            string displayItemId,
            DisplayItemType type,
            DisplayItemOptions options = null
        ){
            this.displayItemId = displayItemId;
            this.type = type;
            this.salesItem = options?.salesItem;
            this.salesItemGroup = options?.salesItemGroup;
            this.salesPeriodEventId = options?.salesPeriodEventId;
        }

        public static DisplayItem TypeIsSalesItem(
            string displayItemId,
            SalesItem salesItem,
            DisplayItemTypeIsSalesItemOptions options = null
        ){
            return (new DisplayItem(
                displayItemId,
                DisplayItemType.SalesItem,
                new DisplayItemOptions {
                    salesItem = salesItem,
                    salesPeriodEventId = options?.salesPeriodEventId,
                }
            ));
        }

        public static DisplayItem TypeIsSalesItemGroup(
            string displayItemId,
            SalesItemGroup salesItemGroup,
            DisplayItemTypeIsSalesItemGroupOptions options = null
        ){
            return (new DisplayItem(
                displayItemId,
                DisplayItemType.SalesItemGroup,
                new DisplayItemOptions {
                    salesItemGroup = salesItemGroup,
                    salesPeriodEventId = options?.salesPeriodEventId,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.displayItemId != null) {
                properties["displayItemId"] = this.displayItemId;
            }
            if (this.type != null) {
                properties["type"] = this.type?.Str(
                );
            }
            if (this.salesItem != null) {
                properties["salesItem"] = this.salesItem?.Properties(
                );
            }
            if (this.salesItemGroup != null) {
                properties["salesItemGroup"] = this.salesItemGroup?.Properties(
                );
            }
            if (this.salesPeriodEventId != null) {
                properties["salesPeriodEventId"] = this.salesPeriodEventId;
            }

            return properties;
        }
    }
}
