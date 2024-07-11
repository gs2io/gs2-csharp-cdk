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
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Model.Options;

namespace Gs2Cdk.Gs2Inventory.Model
{
    public class ItemModel {
        private string name;
        private long stackingLimit;
        private string stackingLimitString;
        private bool allowMultipleStacks;
        private string allowMultipleStacksString;
        private int sortValue;
        private string sortValueString;
        private string metadata;

        public ItemModel(
            string name,
            long stackingLimit,
            bool allowMultipleStacks,
            int sortValue,
            ItemModelOptions options = null
        ){
            this.name = name;
            this.stackingLimit = stackingLimit;
            this.allowMultipleStacks = allowMultipleStacks;
            this.sortValue = sortValue;
            this.metadata = options?.metadata;
        }


        public ItemModel(
            string name,
            string stackingLimit,
            string allowMultipleStacks,
            string sortValue,
            ItemModelOptions options = null
        ){
            this.name = name;
            this.stackingLimitString = stackingLimit;
            this.allowMultipleStacksString = allowMultipleStacks;
            this.sortValueString = sortValue;
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
            if (this.stackingLimitString != null) {
                properties["stackingLimit"] = this.stackingLimitString;
            } else {
                if (this.stackingLimit != null) {
                    properties["stackingLimit"] = this.stackingLimit;
                }
            }
            if (this.allowMultipleStacksString != null) {
                properties["allowMultipleStacks"] = this.allowMultipleStacksString;
            } else {
                if (this.allowMultipleStacks != null) {
                    properties["allowMultipleStacks"] = this.allowMultipleStacks;
                }
            }
            if (this.sortValueString != null) {
                properties["sortValue"] = this.sortValueString;
            } else {
                if (this.sortValue != null) {
                    properties["sortValue"] = this.sortValue;
                }
            }

            return properties;
        }

        public static ItemModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ItemModel(
                (string)properties["name"],
                new Func<long>(() =>
                {
                    return properties["stackingLimit"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<bool>(() =>
                {
                    return properties["allowMultipleStacks"] switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["sortValue"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new ItemModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
