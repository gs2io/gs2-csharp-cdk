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
using Gs2Cdk.Gs2Script.Model;
using Gs2Cdk.Gs2Script.Ref;

namespace Gs2Cdk.Gs2Script.Resource
{
    public class Script : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _script;

        public Script(
                Stack stack,
                string namespaceName,
                string name,
                string script,
                string description = null
        ): base("Script_Script_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._script = script;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Script::Script";
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
            if (this._script != null) {
                properties["Script"] = this._script;
            }
            return properties;
        }

        public ScriptRef Ref(
                string namespaceName
        ) {
            return new ScriptRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrScriptId() {
            return new GetAttr(
                "Item.ScriptId"
            );
        }
    }
}
