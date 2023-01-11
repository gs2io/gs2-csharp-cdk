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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Identifier.Ref;
using Gs2Cdk.Gs2Identifier.Model;
using Gs2Cdk.Gs2Identifier.Model.Options;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class User : CdkResource {
        private Stack? stack;
        private string name;
        private string description;

        public User(
            Stack stack,
            string name,
            UserOptions options = null
        ): base(
            "Identifier_User_" + name
        ){

            this.stack = stack;
            this.name = name;
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
            return "GS2::Identifier::User";
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

            return properties;
        }

        public UserRef Ref(
        ){
            return (new UserRef(
                this.name
            ));
        }


        public User Attach(
            SecurityPolicy securityPolicy
        ){
            (new AttachSecurityPolicy(
                this.stack,
                this.name,
                securityPolicy.GetAttrSecurityPolicyId(
                ).Str(
                )
            )).AddDependsOn(
                this
            ).AddDependsOn(
                securityPolicy
            );

            return this;
        }

        public User AttachGrn(
            string securityPolicyGrn
        ){
            (new AttachSecurityPolicy(
                this.stack,
                this.name,
                securityPolicyGrn
            )).AddDependsOn(
                this
            );

            return this;
        }

        public Identifier Identifier(
        ){
            var identifier = (new Identifier(
                this.stack,
                this.name
            ));
            identifier.AddDependsOn(
                this
            );

            return identifier;
        }

        public GetAttr GetAttrUserId(
        ){
            return (new GetAttr(
                null,
                null,
                "Item.UserId"
            ));
        }
    }
}
