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
    public class AttachSecurityPolicy : CdkResource
    {

        private readonly Stack stack;
        private readonly string userName;
        private readonly string securityPolicyId;

        private static string SecurityPolicyResourceName(
            string securityPolicyId
        ) {
            if (securityPolicyId[0] == '!') {
                if (securityPolicyId.StartsWith("!Join")) {
                    var joinParams = securityPolicyId.Substring("!Join".Length).Trim();
                    joinParams = joinParams.Substring(joinParams.IndexOf(",", StringComparison.Ordinal)+1).Trim();
                    joinParams = joinParams.Substring(1, joinParams.Length - 3);
                    var grnElement = joinParams.Split(",");
                    return grnElement[grnElement.Length-1];
                }
                return securityPolicyId.Split("_")[2];
            }
            return securityPolicyId.Substring(securityPolicyId.LastIndexOf(":", StringComparison.Ordinal) + 1);
        }
        
        public AttachSecurityPolicy(
            Stack stack,
            string userName,
            string securityPolicyId
        ): base("Identifier_AttachSecurityPolicy_" + userName + (stack.Exists("Identifier_AttachSecurityPolicy_" + userName) ? "_" + SecurityPolicyResourceName(securityPolicyId) : ""))
        {
            this.stack = stack;
            this.userName = userName;
            this.securityPolicyId = securityPolicyId;
            stack.AddResource(
                this
            );
        }

        public override string ResourceType()
        {
            return "GS2::Identifier::AttachSecurityPolicy";
        }

        public override Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this.userName != null)
            {
                properties["UserName"] = this.userName;
            }

            if (this.securityPolicyId != null)
            {
                properties["SecurityPolicyId"] = this.securityPolicyId;
            }

            return properties;
        }
    }
}
