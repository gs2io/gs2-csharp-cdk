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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Script.Ref;
using Gs2Cdk.Gs2Script.Model;
using Gs2Cdk.Gs2Script.Model.Options;

namespace Gs2Cdk.Gs2Script.Model
{
    public class Script : CdkResource {
        private Stack? stack;
        private string namespaceName;
        private string name;
        private string script;
        private string description;

        public Script(
            Stack stack,
            string namespaceName,
            string name,
            string script,
            ScriptOptions options = null
        ): base(
            "Script_Script_" + name
        ){

            this.stack = stack;
            this.namespaceName = namespaceName;
            this.name = name;
            this.script = script;
            this.description = options?.description;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::Script::Script";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.script != null) {
                properties["Script"] = this.script;
            }

            return properties;
        }

        public ScriptRef Ref(
        ){
            return (new ScriptRef(
                this.namespaceName,
                this.name
            ));
        }

        public GetAttr GetAttrScriptId(
        ){
            return (new GetAttr(
                this,
                "Item.ScriptId",
                null
            ));
        }
    }
}
