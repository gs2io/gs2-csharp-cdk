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
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.Model.Options;

namespace Gs2Cdk.Gs2Guild.Model
{
    public class ReceiveMemberRequest {
        private string userId;
        private string targetGuildName;

        public ReceiveMemberRequest(
            string userId,
            string targetGuildName,
            ReceiveMemberRequestOptions options = null
        ){
            this.userId = userId;
            this.targetGuildName = targetGuildName;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.targetGuildName != null) {
                properties["targetGuildName"] = this.targetGuildName;
            }

            return properties;
        }

        public static ReceiveMemberRequest FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ReceiveMemberRequest(
                (string)properties["userId"],
                (string)properties["targetGuildName"],
                new ReceiveMemberRequestOptions {
                }
            );

            return model;
        }
    }
}
