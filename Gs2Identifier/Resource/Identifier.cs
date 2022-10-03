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


namespace Gs2Cdk.Gs2Identifier.Resource
{
    public class Identifier : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _userName;

        public Identifier(
                Stack stack,
                string userName
        ): base("Identifier_Identifier_") {
            this._stack = stack;
            this._userName = userName;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Identifier::Identifier";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._userName != null) {
                properties["UserName"] = this._userName;
            }
            return properties;
        }

        public GetAttr GetAttrClientId() {
            return new GetAttr(
                "Item.ClientId"
            );
        }

        public GetAttr GetAttrClientSecret() {
            return new GetAttr(
                "ClientSecret"
            );
        }
    }
}
