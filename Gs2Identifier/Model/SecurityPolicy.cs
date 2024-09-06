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
using Gs2Cdk.Gs2Identifier.Ref;
using Gs2Cdk.Gs2Identifier.Model;
using Gs2Cdk.Gs2Identifier.Model.Options;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class SecurityPolicy : CdkResource {
        private Stack? stack;
        public string name;
        public Policy? policy;
        public string description;

        public SecurityPolicy(
            Stack stack,
            string name,
            Policy policy,
            SecurityPolicyOptions options = null
        ): base(
            "Identifier_SecurityPolicy_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.policy = policy;
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
            return "GS2::Identifier::SecurityPolicy";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.policy != null) {
                properties["Policy"] = this.policy?.Properties(
                );
            }

            return properties;
        }

        public SecurityPolicyRef Ref(
        ){
            return (new SecurityPolicyRef(
                this.name
            ));
        }
        public static string ApplicationAccessGrn(
        ){
            return "grn:gs2::system:identifier:securityPolicy:ApplicationAccess";
        }

        public GetAttr GetAttrSecurityPolicyId(
        ){
            return (new GetAttr(
                this,
                "Item.SecurityPolicyId",
                null
            ));
        }
    }
}
