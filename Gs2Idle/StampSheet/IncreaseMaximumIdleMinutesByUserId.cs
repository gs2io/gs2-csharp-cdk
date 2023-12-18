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
using Gs2Cdk.Gs2Idle.Model;

namespace Gs2Cdk.Gs2Idle.StampSheet
{
    public class IncreaseMaximumIdleMinutesByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string categoryName;
        private int? increaseMinutes;


        public IncreaseMaximumIdleMinutesByUserId(
            string namespaceName,
            string categoryName,
            int? increaseMinutes = null,
            string userId = "#{userId}"
        ): base(
            "Gs2Idle:IncreaseMaximumIdleMinutesByUserId",
            new Dictionary<string, object>() {
                ["namespaceName"] = namespaceName,
                ["categoryName"] = categoryName,
                ["increaseMinutes"] = increaseMinutes,
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
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.categoryName != null) {
                properties["categoryName"] = this.categoryName;
            }
            if (this.increaseMinutes != null) {
                properties["increaseMinutes"] = this.increaseMinutes;
            }

            return properties;
        }

        public string Action() {
            return "Gs2Idle:IncreaseMaximumIdleMinutesByUserId";
        }
    }
}
