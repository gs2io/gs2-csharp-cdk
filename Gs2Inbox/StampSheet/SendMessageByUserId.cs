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
using Gs2Cdk.Gs2Inbox.Model;

namespace Gs2Cdk.Gs2Inbox.StampSheet
{
    public class SendMessageByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string metadata;
        private AcquireAction[] readAcquireActions;
        private long? expiresAt;
        private TimeSpan_ expiresTimeSpan;


        public SendMessageByUserId(
            string namespaceName,
            string metadata,
            AcquireAction[] readAcquireActions = null,
            long? expiresAt = null,
            TimeSpan_ expiresTimeSpan = null,
            string userId = "#{userId}"
        ): base(
            "Gs2Inbox:SendMessageByUserId",
            new Dictionary<string, object>() {
                ["namespaceName"] = namespaceName,
                ["metadata"] = metadata,
                ["readAcquireActions"] = readAcquireActions,
                ["expiresAt"] = expiresAt,
                ["expiresTimeSpan"] = expiresTimeSpan,
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
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.readAcquireActions != null) {
                properties["readAcquireActions"] = this.readAcquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.expiresAt != null) {
                properties["expiresAt"] = this.expiresAt;
            }
            if (this.expiresTimeSpan != null) {
                properties["expiresTimeSpan"] = this.expiresTimeSpan?.Properties(
                );
            }

            return properties;
        }

        public string Action() {
            return "Gs2Inbox:SendMessageByUserId";
        }
    }
}
