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
using Gs2Cdk.Gs2Identifier.Model.Enums;
using Gs2Cdk.Gs2Identifier.Model.Options;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class Password : CdkResource {
        private Stack? stack;
        private string userName;
        private string password;

        public Password(
            Stack stack,
            string userName,
            string password,
            PasswordOptions options = null
        ): base(
            "Identifier_Password_"
        ){

            this.stack = stack;
            this.userName = userName;
            this.password = password;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "";
        }

        public override string ResourceType(
        ){
            return "GS2::Identifier::Password";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userName != null) {
                properties["UserName"] = this.userName;
            }
            if (this.password != null) {
                properties["Password"] = this.password;
            }

            return properties;
        }

        public PasswordRef Ref(
        ){
            return (new PasswordRef(
                this.userName
            ));
        }

        public GetAttr GetAttrPasswordId(
        ){
            return (new GetAttr(
                this,
                "Item.PasswordId",
                null
            ));
        }
    }
}
