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
    public class UnleashMaterial {
        private string name;
        private UnleashMaterialMaterialType? materialType;
        private UnleashIndividualMaterialSetting individualSetting;
        private UnleashQuantityMaterialSetting quantitySetting;

        public UnleashMaterial(
            string name,
            UnleashMaterialMaterialType materialType,
            UnleashMaterialOptions options = null
        ){
            this.name = name;
            this.materialType = materialType;
            this.individualSetting = options?.individualSetting;
            this.quantitySetting = options?.quantitySetting;
        }

        public static UnleashMaterial MaterialTypeIsIndividual(
            string name,
            UnleashIndividualMaterialSetting individualSetting,
            UnleashMaterialMaterialTypeIsIndividualOptions options = null
        ){
            return (new UnleashMaterial(
                name,
                UnleashMaterialMaterialType.Individual,
                new UnleashMaterialOptions {
                    individualSetting = individualSetting,
                }
            ));
        }

        public static UnleashMaterial MaterialTypeIsQuantity(
            string name,
            UnleashQuantityMaterialSetting quantitySetting,
            UnleashMaterialMaterialTypeIsQuantityOptions options = null
        ){
            return (new UnleashMaterial(
                name,
                UnleashMaterialMaterialType.Quantity,
                new UnleashMaterialOptions {
                    quantitySetting = quantitySetting,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.materialType != null) {
                properties["materialType"] = this.materialType.Value.Str(
                );
            }
            if (this.individualSetting != null) {
                properties["individualSetting"] = this.individualSetting?.Properties(
                );
            }
            if (this.quantitySetting != null) {
                properties["quantitySetting"] = this.quantitySetting?.Properties(
                );
            }

            return properties;
        }

        public static UnleashMaterial FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashMaterial(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("materialType", out var materialType) ? new Func<UnleashMaterialMaterialType>(() =>
                {
                    return materialType switch {
                        UnleashMaterialMaterialType e => e,
                        string s => UnleashMaterialMaterialTypeExt.New(s),
                        _ => UnleashMaterialMaterialType.Individual
                    };
                })() : default,
                new UnleashMaterialOptions {
                    individualSetting = properties.TryGetValue("individualSetting", out var individualSetting) ? new Func<UnleashIndividualMaterialSetting>(() =>
                    {
                        return individualSetting switch {
                            UnleashIndividualMaterialSetting v => v,
                            Dictionary<string, object> v => UnleashIndividualMaterialSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    quantitySetting = properties.TryGetValue("quantitySetting", out var quantitySetting) ? new Func<UnleashQuantityMaterialSetting>(() =>
                    {
                        return quantitySetting switch {
                            UnleashQuantityMaterialSetting v => v,
                            Dictionary<string, object> v => UnleashQuantityMaterialSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
