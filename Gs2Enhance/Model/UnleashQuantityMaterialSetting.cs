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
    public class UnleashQuantityMaterialSetting {
        private UnleashQuantityMaterialSettingMatchType? matchType;
        private int count;
        private string countString;
        private string materialInventoryModelId;
        private string itemModelId;

        public UnleashQuantityMaterialSetting(
            UnleashQuantityMaterialSettingMatchType matchType,
            int count,
            UnleashQuantityMaterialSettingOptions options = null
        ){
            this.matchType = matchType;
            this.count = count;
            this.materialInventoryModelId = options?.materialInventoryModelId;
            this.itemModelId = options?.itemModelId;
        }

        public static UnleashQuantityMaterialSetting MatchTypeIsSameGroup(
            int count,
            string materialInventoryModelId,
            UnleashQuantityMaterialSettingMatchTypeIsSameGroupOptions options = null
        ){
            return (new UnleashQuantityMaterialSetting(
                UnleashQuantityMaterialSettingMatchType.SameGroup,
                count,
                new UnleashQuantityMaterialSettingOptions {
                    materialInventoryModelId = materialInventoryModelId,
                }
            ));
        }

        public static UnleashQuantityMaterialSetting MatchTypeIsSpecified(
            int count,
            string itemModelId,
            UnleashQuantityMaterialSettingMatchTypeIsSpecifiedOptions options = null
        ){
            return (new UnleashQuantityMaterialSetting(
                UnleashQuantityMaterialSettingMatchType.Specified,
                count,
                new UnleashQuantityMaterialSettingOptions {
                    itemModelId = itemModelId,
                }
            ));
        }


        public UnleashQuantityMaterialSetting(
            UnleashQuantityMaterialSettingMatchType matchType,
            string count,
            UnleashQuantityMaterialSettingOptions options = null
        ){
            this.matchType = matchType;
            this.countString = count;
            this.materialInventoryModelId = options?.materialInventoryModelId;
            this.itemModelId = options?.itemModelId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.matchType != null) {
                properties["matchType"] = this.matchType.Value.Str(
                );
            }
            if (this.materialInventoryModelId != null) {
                properties["materialInventoryModelId"] = this.materialInventoryModelId;
            }
            if (this.itemModelId != null) {
                properties["itemModelId"] = this.itemModelId;
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }

            return properties;
        }

        public static UnleashQuantityMaterialSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashQuantityMaterialSetting(
                properties.TryGetValue("matchType", out var matchType) ? new Func<UnleashQuantityMaterialSettingMatchType>(() =>
                {
                    return matchType switch {
                        UnleashQuantityMaterialSettingMatchType e => e,
                        string s => UnleashQuantityMaterialSettingMatchTypeExt.New(s),
                        _ => UnleashQuantityMaterialSettingMatchType.SameGroup
                    };
                })() : default,
                properties.TryGetValue("count", out var count) ? new Func<int>(() =>
                {
                    return count switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new UnleashQuantityMaterialSettingOptions {
                    materialInventoryModelId = properties.TryGetValue("materialInventoryModelId", out var materialInventoryModelId) ? (string)materialInventoryModelId : null,
                    itemModelId = properties.TryGetValue("itemModelId", out var itemModelId) ? (string)itemModelId : null
                }
            );

            return model;
        }
    }
}
