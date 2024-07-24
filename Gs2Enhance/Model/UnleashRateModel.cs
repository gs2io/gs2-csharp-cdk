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
using Gs2Cdk.Gs2Enhance.Model;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class UnleashRateModel {
        private string name;
        private string targetInventoryModelId;
        private string gradeModelId;
        private UnleashRateEntryModel[] gradeEntries;
        private string description;
        private string metadata;

        public UnleashRateModel(
            string name,
            string targetInventoryModelId,
            string gradeModelId,
            UnleashRateEntryModel[] gradeEntries,
            UnleashRateModelOptions options = null
        ){
            this.name = name;
            this.targetInventoryModelId = targetInventoryModelId;
            this.gradeModelId = gradeModelId;
            this.gradeEntries = gradeEntries;
            this.description = options?.description;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.description != null) {
                properties["description"] = this.description;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.targetInventoryModelId != null) {
                properties["targetInventoryModelId"] = this.targetInventoryModelId;
            }
            if (this.gradeModelId != null) {
                properties["gradeModelId"] = this.gradeModelId;
            }
            if (this.gradeEntries != null) {
                properties["gradeEntries"] = this.gradeEntries.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static UnleashRateModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashRateModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("targetInventoryModelId", out var targetInventoryModelId) ? new Func<string>(() =>
                {
                    return (string) targetInventoryModelId;
                })() : default,
                properties.TryGetValue("gradeModelId", out var gradeModelId) ? new Func<string>(() =>
                {
                    return (string) gradeModelId;
                })() : default,
                properties.TryGetValue("gradeEntries", out var gradeEntries) ? new Func<UnleashRateEntryModel[]>(() =>
                {
                    return gradeEntries switch {
                        Dictionary<string, object>[] v => v.Select(UnleashRateEntryModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ UnleashRateEntryModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(UnleashRateEntryModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as UnleashRateEntryModel).ToArray(),
                        { } v => new []{ v as UnleashRateEntryModel },
                        _ => null
                    };
                })() : null,
                new UnleashRateModelOptions {
                    description = properties.TryGetValue("description", out var description) ? (string)description : null,
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
