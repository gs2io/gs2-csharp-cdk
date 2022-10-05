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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Ref;

namespace Gs2Cdk.Gs2Showcase.Resource
{
    public class SalesItemMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly ConsumeAction[] _consumeActions;
        private readonly AcquireAction[] _acquireActions;

        public SalesItemMaster(
                Stack stack,
                string namespaceName,
                string name,
                ConsumeAction[] consumeActions,
                AcquireAction[] acquireActions,
                string description = null,
                string metadata = null
        ): base("Showcase_SalesItemMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._consumeActions = consumeActions;
            this._acquireActions = acquireActions;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Showcase::SalesItemMaster";
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
            if (this._consumeActions != null) {
                properties["ConsumeActions"] = this._consumeActions.Select(v => v.Properties()).ToArray();
            }
            if (this._acquireActions != null) {
                properties["AcquireActions"] = this._acquireActions.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }

        public SalesItemMasterRef Ref(
                string namespaceName
        ) {
            return new SalesItemMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrSalesItemId() {
            return new GetAttr(
                "Item.SalesItemId"
            );
        }
    }
}
