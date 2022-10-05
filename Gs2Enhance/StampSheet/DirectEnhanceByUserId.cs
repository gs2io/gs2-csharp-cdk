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
using Gs2Cdk.Gs2Enhance.Model;

namespace Gs2Cdk.Gs2Enhance.StampSheet
{
    public class DirectEnhanceByUserId : AcquireAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string rateName,
                string userId,
                string targetItemSetId,
                Material[] materials,
                Config[] config
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (rateName != null) {
                properties["rateName"] = rateName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (targetItemSetId != null) {
                properties["targetItemSetId"] = targetItemSetId;
            }
            if (materials != null) {
                properties["materials"] = materials;
            }
            if (config != null) {
                properties["config"] = config;
            }
            return properties;
        }

        public DirectEnhanceByUserId(
                string namespaceName,
                string rateName,
                string userId,
                string targetItemSetId,
                Material[] materials = null,
                Config[] config = null
        ): base(
           "Gs2Enhance:DirectEnhanceByUserId",
           Properties(
                namespaceName,
                rateName,
                userId,
                targetItemSetId,
                materials,
                config
           )
        ) {
        }
    }
}
