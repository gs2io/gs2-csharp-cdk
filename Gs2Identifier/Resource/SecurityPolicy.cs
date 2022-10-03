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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Identifier.Model;
using Gs2Cdk.Gs2Identifier.Ref;


namespace Gs2Cdk.Gs2Identifier.Resource
{
    public class SecurityPolicy : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly Policy _policy;

        public SecurityPolicy(
                Stack stack,
                string name,
                Policy policy
        ): base("Identifier_SecurityPolicy_" + name) {
            this._stack = stack;
            this._name = name;
            this._policy = policy;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Identifier::SecurityPolicy";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._policy != null) {
                properties["Policy"] = this._policy.Properties();
            }
            return properties;
        }

        public SecurityPolicyRef Ref(
        ) {
            return new SecurityPolicyRef(
                this._name
            );
        }

        public GetAttr GetAttrSecurityPolicyId() {
            return new GetAttr(
                "Item.SecurityPolicyId"
            );
        }
    }
}
