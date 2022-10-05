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
using Gs2Cdk.Gs2Limit.Model;

namespace Gs2Cdk.Gs2Limit.StampSheet
{
    public class CountUpByUserId : ConsumeAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string limitName,
                string counterName,
                string userId,
                int? countUpValue,
                int? maxValue
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (limitName != null) {
                properties["limitName"] = limitName;
            }
            if (counterName != null) {
                properties["counterName"] = counterName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (countUpValue != null) {
                properties["countUpValue"] = countUpValue;
            }
            if (maxValue != null) {
                properties["maxValue"] = maxValue;
            }
            return properties;
        }

        public CountUpByUserId(
                string namespaceName,
                string limitName,
                string counterName,
                string userId,
                int? countUpValue,
                int? maxValue = null
        ): base(
           "Gs2Limit:CountUpByUserId",
           Properties(
                namespaceName,
                limitName,
                counterName,
                userId,
                countUpValue,
                maxValue
           )
        ) {
        }
    }
}
