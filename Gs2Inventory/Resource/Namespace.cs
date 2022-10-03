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
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Ref;


namespace Gs2Cdk.Gs2Inventory.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly ScriptSetting _acquireScript;
        private readonly ScriptSetting _overflowScript;
        private readonly ScriptSetting _consumeScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string description = null,
                ScriptSetting acquireScript = null,
                ScriptSetting overflowScript = null,
                ScriptSetting consumeScript = null,
                LogSetting logSetting = null
        ): base("Inventory_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._acquireScript = acquireScript;
            this._overflowScript = overflowScript;
            this._consumeScript = consumeScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Inventory::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._acquireScript != null) {
                properties["AcquireScript"] = this._acquireScript.Properties();
            }
            if (this._overflowScript != null) {
                properties["OverflowScript"] = this._overflowScript.Properties();
            }
            if (this._consumeScript != null) {
                properties["ConsumeScript"] = this._consumeScript.Properties();
            }
            if (this._logSetting != null) {
                properties["LogSetting"] = this._logSetting.Properties();
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }

        public Namespace MasterData(
                InventoryModel[] inventoryModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                inventoryModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
