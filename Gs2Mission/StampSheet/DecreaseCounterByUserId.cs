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
using Gs2Cdk.Gs2Mission.Model;

namespace Gs2Cdk.Gs2Mission.StampSheet
{
    public class DecreaseCounterByUserId : ConsumeAction {
        private string namespaceName;
        private string counterName;
        private string userId;
        private long value;


        public DecreaseCounterByUserId(
            string namespaceName,
            string counterName,
            long value,
            string userId = "#{userId}"
        ): base(
            "Gs2Mission:DecreaseCounterByUserId",
            new Dictionary<string, object>() {
                ["namespaceName"] = namespaceName,
                ["counterName"] = counterName,
                ["value"] = value,
                ["userId"] = userId,
            }
        ){
        }

        public Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.value != null) {
                properties["value"] = this.value;
            }

            return properties;
        }

        public string Action() {
            return "Gs2Mission:DecreaseCounterByUserId";
        }
    }
}
