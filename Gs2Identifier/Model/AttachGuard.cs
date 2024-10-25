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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Identifier.Model;


namespace Gs2Cdk.Gs2Identifier.Model
{
    public class AttachGuard : CdkResource
    {

        private readonly Stack stack;
        private readonly string userName;
        private readonly string clientId;
        private readonly string guardNamespaceId;

        private static string GuardNamespaceResourceName(
            string guardNamespaceId
        ) {
            if (guardNamespaceId[0] == '!') {
                if (guardNamespaceId.StartsWith("!Join")) {
                    var joinParams = guardNamespaceId.Substring("!Join".Length).Trim();
                    joinParams = joinParams.Substring(joinParams.IndexOf(",", StringComparison.Ordinal)+1).Trim();
                    joinParams = joinParams.Substring(1, joinParams.Length - 3);
                    var grnElement = joinParams.Split(",");
                    return grnElement[grnElement.Length-1];
                }
                return guardNamespaceId.Split("_")[2];
            }
            return guardNamespaceId.Substring(guardNamespaceId.LastIndexOf(":", StringComparison.Ordinal) + 1);
        }
        
        public AttachGuard(
            Stack stack,
            string userName,
            string clientId,
            string guardNamespaceId
        ): base("Identifier_AttachGuard_" + userName + (stack.Exists("Identifier_AttachGuard_" + userName) ? "_" + GuardNamespaceResourceName(guardNamespaceId) : ""))
        {
            this.stack = stack;
            this.userName = userName;
            this.clientId = clientId;
            this.guardNamespaceId = guardNamespaceId;
            stack.AddResource(
                this
            );
        }

        public override string ResourceType()
        {
            return "GS2::Identifier::AttachGuard";
        }

        public override Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this.userName != null)
            {
                properties["UserName"] = this.userName;
            }

            if (this.clientId != null)
            {
                properties["ClientId"] = this.clientId;
            }

            if (this.guardNamespaceId != null)
            {
                properties["GuardNamespaceId"] = this.guardNamespaceId;
            }

            return properties;
        }
    }
}
