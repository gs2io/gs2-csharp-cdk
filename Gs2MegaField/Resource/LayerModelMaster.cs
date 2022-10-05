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
using Gs2Cdk.Gs2MegaField.Model;
using Gs2Cdk.Gs2MegaField.Ref;

namespace Gs2Cdk.Gs2MegaField.Resource
{
    public class LayerModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _areaModelName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;

        public LayerModelMaster(
                Stack stack,
                string namespaceName,
                string areaModelName,
                string name,
                string description = null,
                string metadata = null
        ): base("MegaField_LayerModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._areaModelName = areaModelName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::MegaField::LayerModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._areaModelName != null) {
                properties["AreaModelName"] = this._areaModelName;
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
            return properties;
        }

        public LayerModelMasterRef Ref(
                string namespaceName,
                string areaModelName
        ) {
            return new LayerModelMasterRef(
                namespaceName,
                areaModelName,
                this._name
            );
        }

        public GetAttr GetAttrLayerModelMasterId() {
            return new GetAttr(
                "Item.LayerModelMasterId"
            );
        }
    }
}
