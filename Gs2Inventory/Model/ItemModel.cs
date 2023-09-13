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
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Model.Options;

namespace Gs2Cdk.Gs2Inventory.Model
{
    public class ItemModel {
        private string name;
        private long? stackingLimit;
        private bool? allowMultipleStacks;
        private int? sortValue;
        private string metadata;

        public ItemModel(
            string name,
            long? stackingLimit,
            bool? allowMultipleStacks,
            int? sortValue,
            ItemModelOptions options = null
        ){
            this.name = name;
            this.stackingLimit = stackingLimit;
            this.allowMultipleStacks = allowMultipleStacks;
            this.sortValue = sortValue;
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
            if (this.stackingLimit != null) {
                properties["stackingLimit"] = this.stackingLimit;
            }
            if (this.allowMultipleStacks != null) {
                properties["allowMultipleStacks"] = this.allowMultipleStacks;
            }
            if (this.sortValue != null) {
                properties["sortValue"] = this.sortValue;
            }

            return properties;
        }

        public ItemModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ItemModel(
                properties["name"] as string,
                properties["stackingLimit"] as long?,
                properties["allowMultipleStacks"] as bool?,
                properties["sortValue"] as int?,
                new ItemModelOptions {
                    metadata = properties["metadata"] as string
                }
            );

            return model;
        }
    }
}
