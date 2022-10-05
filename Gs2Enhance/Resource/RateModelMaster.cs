/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Enhance.Model;
using Gs2Cdk.Gs2Enhance.Ref;

namespace Gs2Cdk.Gs2Enhance.Resource
{
    public class RateModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly string _targetInventoryModelId;
        private readonly string _acquireExperienceSuffix;
        private readonly string _materialInventoryModelId;
        private readonly string[] _acquireExperienceHierarchy;
        private readonly string _experienceModelId;
        private readonly BonusRate[] _bonusRates;

        public RateModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                string targetInventoryModelId,
                string acquireExperienceSuffix,
                string materialInventoryModelId,
                string experienceModelId,
                string description = null,
                string metadata = null,
                string[] acquireExperienceHierarchy = null,
                BonusRate[] bonusRates = null
        ): base("Enhance_RateModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._targetInventoryModelId = targetInventoryModelId;
            this._acquireExperienceSuffix = acquireExperienceSuffix;
            this._materialInventoryModelId = materialInventoryModelId;
            this._acquireExperienceHierarchy = acquireExperienceHierarchy;
            this._experienceModelId = experienceModelId;
            this._bonusRates = bonusRates;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Enhance::RateModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._targetInventoryModelId != null) {
                properties["TargetInventoryModelId"] = this._targetInventoryModelId;
            }
            if (this._acquireExperienceSuffix != null) {
                properties["AcquireExperienceSuffix"] = this._acquireExperienceSuffix;
            }
            if (this._materialInventoryModelId != null) {
                properties["MaterialInventoryModelId"] = this._materialInventoryModelId;
            }
            if (this._acquireExperienceHierarchy != null) {
                properties["AcquireExperienceHierarchy"] = this._acquireExperienceHierarchy;
            }
            if (this._experienceModelId != null) {
                properties["ExperienceModelId"] = this._experienceModelId;
            }
            if (this._bonusRates != null) {
                properties["BonusRates"] = this._bonusRates.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }

        public RateModelMasterRef Ref(
                string namespaceName
        ) {
            return new RateModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrRateModelId() {
            return new GetAttr(
                "Item.RateModelId"
            );
        }
    }
}
