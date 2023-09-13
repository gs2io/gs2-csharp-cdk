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
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class Showcase {
        private string name;
        private DisplayItem[] displayItems;
        private string metadata;
        private string salesPeriodEventId;

        public Showcase(
            string name,
            DisplayItem[] displayItems,
            ShowcaseOptions options = null
        ){
            this.name = name;
            this.displayItems = displayItems;
            this.metadata = options?.metadata;
            this.salesPeriodEventId = options?.salesPeriodEventId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.salesPeriodEventId != null) {
                properties["salesPeriodEventId"] = this.salesPeriodEventId;
            }
            if (this.displayItems != null) {
                properties["displayItems"] = this.displayItems.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static Showcase FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Showcase(
                (string)properties["name"],
                new Func<DisplayItem[]>(() =>
                {
                    return properties["displayItems"] switch {
                        Dictionary<string, object>[] v => v.Select(DisplayItem.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(DisplayItem.FromProperties).ToArray(),
                        _ => null
                    };
                })(),
                new ShowcaseOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    salesPeriodEventId = properties.TryGetValue("salesPeriodEventId", out var salesPeriodEventId) ? (string)salesPeriodEventId : null
                }
            );

            return model;
        }
    }
}
