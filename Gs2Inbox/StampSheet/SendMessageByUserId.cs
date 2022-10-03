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
using Gs2Cdk.Gs2Inbox.Model;

namespace Gs2Cdk.Gs2Inbox.StampSheet
{
    public class SendMessageByUserId : AcquireAction
    {
        private static Dictionary<string, object> Properties(
                string namespaceName,
                string userId,
                string metadata,
                AcquireAction[] readAcquireActions,
                long? expiresAt,
                TimeSpan_ expiresTimeSpan
        ) {
            var properties = new Dictionary<string, object>();
            if (namespaceName != null) {
                properties["namespaceName"] = namespaceName;
            }
            if (userId != null) {
                properties["userId"] = userId;
            }
            if (metadata != null) {
                properties["metadata"] = metadata;
            }
            if (readAcquireActions != null) {
                properties["readAcquireActions"] = readAcquireActions;
            }
            if (expiresAt != null) {
                properties["expiresAt"] = expiresAt;
            }
            if (expiresTimeSpan != null) {
                properties["expiresTimeSpan"] = expiresTimeSpan;
            }
            return properties;
        }

        public SendMessageByUserId(
                string namespaceName,
                string userId,
                string metadata,
                AcquireAction[] readAcquireActions = null,
                long? expiresAt = null,
                TimeSpan_ expiresTimeSpan = null
        ): base(
           "Gs2Inbox:SendMessageByUserId",
           Properties(
                namespaceName,
                userId,
                metadata,
                readAcquireActions,
                expiresAt,
                expiresTimeSpan
           )
        ) {
        }
    }
}
