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
    public class Identifier : CdkResource {
        private Stack? stack;
        private string userName;

        public Identifier(
            Stack stack,
            string userName,
            IdentifierOptions options = null
        ): base(
            "Identifier_Identifier_" + userName
        ){

            this.stack = stack;
            this.userName = userName;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "userName";
        }

        public override string ResourceType(
        ){
            return "GS2::Identifier::Identifier";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userName != null) {
                properties["UserName"] = this.userName;
            }

            return properties;
        }

        public IdentifierRef Ref(
            string clientId
        ){
            return (new IdentifierRef(
                this.userName,
                clientId
            ));
        }

        public GetAttr GetAttrClientId(
        ){
            return (new GetAttr(
                this,
                "Item.ClientId",
                null
            ));
        }


        public GetAttr GetAttrClientSecret(
        ){
            return (new GetAttr(
                this,
                "ClientSecret",
                null
            ));
        }
    }
}
