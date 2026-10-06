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
    public class UnleashRecipe {
        private string name;
        private UnleashMaterial[] materials;
        private string metadata;
        private string[] targetGroupKeys;

        public UnleashRecipe(
            string name,
            UnleashMaterial[] materials,
            UnleashRecipeOptions options = null
        ){
            this.name = name;
            this.materials = materials;
            this.metadata = options?.metadata;
            this.targetGroupKeys = options?.targetGroupKeys;
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
            if (this.targetGroupKeys != null) {
                properties["targetGroupKeys"] = this.targetGroupKeys;
            }
            if (this.materials != null) {
                properties["materials"] = this.materials.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static UnleashRecipe FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashRecipe(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("materials", out var materials) ? new Func<UnleashMaterial[]>(() =>
                {
                    return materials switch {
                        Dictionary<string, object>[] v => v.Select(UnleashMaterial.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ UnleashMaterial.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(UnleashMaterial.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as UnleashMaterial).ToArray(),
                        { } v => new []{ v as UnleashMaterial },
                        _ => null
                    };
                })() : null,
                new UnleashRecipeOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    targetGroupKeys = properties.TryGetValue("targetGroupKeys", out var targetGroupKeys) ? new Func<string[]>(() =>
                    {
                        return targetGroupKeys switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
