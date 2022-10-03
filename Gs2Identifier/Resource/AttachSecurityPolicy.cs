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
    public class AttachSecurityPolicy : CdkResource
    {

        private readonly Stack stack;
        private readonly string userName;
        private readonly string securityPolicyId;

        public AttachSecurityPolicy(
            Stack stack,
            string userName,
            string securityPolicyId
        ): base("Identifier_AttachSecurityPolicy_" + userName)
        {
            this.stack = stack;
            this.userName = userName;
            this.securityPolicyId = securityPolicyId;
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