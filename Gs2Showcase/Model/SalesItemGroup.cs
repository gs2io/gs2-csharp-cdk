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
    public class SalesItemGroup {
        private string name;
        private SalesItem[] salesItems;
        private string metadata;

        public SalesItemGroup(
            string name,
            SalesItem[] salesItems,
            SalesItemGroupOptions options = null
        ){
            this.name = name;
            this.salesItems = salesItems;
            this.metadata = options?.metadata;
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
            if (this.salesItems != null) {
                properties["salesItems"] = this.salesItems.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static SalesItemGroup FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SalesItemGroup(
                (string)properties["name"],
                new Func<SalesItem[]>(() =>
                {
                    return properties["salesItems"] switch {
                        Dictionary<string, object>[] v => v.Select(SalesItem.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ SalesItem.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(SalesItem.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as SalesItem).ToArray(),
                        { } v => new []{ v as SalesItem },
                        _ => null
                    };
                })(),
                new SalesItemGroupOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
