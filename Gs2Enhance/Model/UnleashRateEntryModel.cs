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
using Gs2Cdk.Gs2Enhance.Model.Enums;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class UnleashRateEntryModel {
        private long gradeValue;
        private string gradeValueString;
        private UnleashRateEntryModelType? type;
        private int? needCount;
        private string needCountString;
        private UnleashRecipe[] recipes;

        public UnleashRateEntryModel(
            long gradeValue,
            UnleashRateEntryModelType type,
            UnleashRateEntryModelOptions options = null
        ){
            this.gradeValue = gradeValue;
            this.type = type;
            this.needCount = options?.needCount;
            this.recipes = options?.recipes;
        }

        public static UnleashRateEntryModel TypeIsSimple(
            long gradeValue,
            int? needCount,
            UnleashRateEntryModelTypeIsSimpleOptions options = null
        ){
            return (new UnleashRateEntryModel(
                gradeValue,
                UnleashRateEntryModelType.Simple,
                new UnleashRateEntryModelOptions {
                    needCount = needCount,
                }
            ));
        }

        public static UnleashRateEntryModel TypeIsRecipe(
            long gradeValue,
            UnleashRecipe[] recipes,
            UnleashRateEntryModelTypeIsRecipeOptions options = null
        ){
            return (new UnleashRateEntryModel(
                gradeValue,
                UnleashRateEntryModelType.Recipe,
                new UnleashRateEntryModelOptions {
                    recipes = recipes,
                }
            ));
        }


        public UnleashRateEntryModel(
            string gradeValue,
            UnleashRateEntryModelType type,
            UnleashRateEntryModelOptions options = null
        ){
            this.gradeValueString = gradeValue;
            this.type = type;
            this.needCount = options?.needCount;
            this.needCountString = options?.needCountString;
            this.recipes = options?.recipes;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.gradeValueString != null) {
                properties["gradeValue"] = this.gradeValueString;
            } else {
                if (this.gradeValue != null) {
                    properties["gradeValue"] = this.gradeValue;
                }
            }
            if (this.type != null) {
                properties["type"] = this.type.Value.Str(
                );
            }
            if (this.needCountString != null) {
                properties["needCount"] = this.needCountString;
            } else {
                if (this.needCount != null) {
                    properties["needCount"] = this.needCount;
                }
            }
            if (this.recipes != null) {
                properties["recipes"] = this.recipes.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static UnleashRateEntryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashRateEntryModel(
                properties.TryGetValue("gradeValue", out var gradeValue) ? new Func<long>(() =>
                {
                    return gradeValue switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("type", out var type) ? new Func<UnleashRateEntryModelType>(() =>
                {
                    return type switch {
                        UnleashRateEntryModelType e => e,
                        string s => UnleashRateEntryModelTypeExt.New(s),
                        _ => UnleashRateEntryModelType.Simple
                    };
                })() : default,
                new UnleashRateEntryModelOptions {
                    needCount = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("needCount", out var needCount) ? needCount switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    recipes = properties.TryGetValue("recipes", out var recipes) ? new Func<UnleashRecipe[]>(() =>
                    {
                        return recipes switch {
                            UnleashRecipe[] v => v,
                            List<UnleashRecipe> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(UnleashRecipe.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(UnleashRecipe.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
