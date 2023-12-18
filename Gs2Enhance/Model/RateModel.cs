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
    public class RateModel {
        private string name;
        private string targetInventoryModelId;
        private string acquireExperienceSuffix;
        private string materialInventoryModelId;
        private string experienceModelId;
        private string description;
        private string metadata;
        private string[] acquireExperienceHierarchy;
        private BonusRate[] bonusRates;

        public RateModel(
            string name,
            string targetInventoryModelId,
            string acquireExperienceSuffix,
            string materialInventoryModelId,
            string experienceModelId,
            RateModelOptions options = null
        ){
            this.name = name;
            this.targetInventoryModelId = targetInventoryModelId;
            this.acquireExperienceSuffix = acquireExperienceSuffix;
            this.materialInventoryModelId = materialInventoryModelId;
            this.experienceModelId = experienceModelId;
            this.description = options?.description;
            this.metadata = options?.metadata;
            this.acquireExperienceHierarchy = options?.acquireExperienceHierarchy;
            this.bonusRates = options?.bonusRates;
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
            if (this.acquireExperienceSuffix != null) {
                properties["acquireExperienceSuffix"] = this.acquireExperienceSuffix;
            }
            if (this.materialInventoryModelId != null) {
                properties["materialInventoryModelId"] = this.materialInventoryModelId;
            }
            if (this.acquireExperienceHierarchy != null) {
                properties["acquireExperienceHierarchy"] = this.acquireExperienceHierarchy;
            }
            if (this.experienceModelId != null) {
                properties["experienceModelId"] = this.experienceModelId;
            }
            if (this.bonusRates != null) {
                properties["bonusRates"] = this.bonusRates.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static RateModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RateModel(
                (string)properties["name"],
                (string)properties["targetInventoryModelId"],
                (string)properties["acquireExperienceSuffix"],
                (string)properties["materialInventoryModelId"],
                (string)properties["experienceModelId"],
                new RateModelOptions {
                    description = properties.TryGetValue("description", out var description) ? (string)description : null,
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    acquireExperienceHierarchy = properties.TryGetValue("acquireExperienceHierarchy", out var acquireExperienceHierarchy) ? new Func<string[]>(() =>
                    {
                        return acquireExperienceHierarchy switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    bonusRates = properties.TryGetValue("bonusRates", out var bonusRates) ? new Func<BonusRate[]>(() =>
                    {
                        return bonusRates switch {
                            BonusRate[] v => v,
                            List<BonusRate> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(BonusRate.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(BonusRate.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
