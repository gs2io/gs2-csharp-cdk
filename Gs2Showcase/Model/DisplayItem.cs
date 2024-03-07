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
using System;
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
                properties["type"] = this.type.Value.Str(
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

        public static DisplayItem FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DisplayItem(
                (string)properties["displayItemId"],
                new Func<DisplayItemType>(() =>
                {
                    return properties["type"] switch {
                        DisplayItemType e => e,
                        string s => DisplayItemTypeExt.New(s),
                        _ => DisplayItemType.SalesItem
                    };
                })(),
                new DisplayItemOptions {
                    salesItem = properties.TryGetValue("salesItem", out var salesItem) ? new Func<SalesItem>(() =>
                    {
                        return salesItem switch {
                            SalesItem v => v,
                            Dictionary<string, object> v => SalesItem.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    salesItemGroup = properties.TryGetValue("salesItemGroup", out var salesItemGroup) ? new Func<SalesItemGroup>(() =>
                    {
                        return salesItemGroup switch {
                            SalesItemGroup v => v,
                            Dictionary<string, object> v => SalesItemGroup.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    salesPeriodEventId = properties.TryGetValue("salesPeriodEventId", out var salesPeriodEventId) ? (string)salesPeriodEventId : null
                }
            );

            return model;
        }
    }
}
