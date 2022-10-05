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
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Exchange.Model;

namespace Gs2Cdk.Gs2Exchange.StampSheet
{
    public class CreateAwaitByUserId : AcquireAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string userId,
                string rateName,
                int? count
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (rateName != null) {
                properties["rateName"] = rateName;
            }
            if (count != null) {
                properties["count"] = count;
            }
            return properties;
        }

        public CreateAwaitByUserId(
                string namespaceName,
                string userId,
                string rateName,
                int? count
        ): base(
           "Gs2Exchange:CreateAwaitByUserId",
           Properties(
                namespaceName,
                userId,
                rateName,
                count
           )
        ) {
        }
    }
}
