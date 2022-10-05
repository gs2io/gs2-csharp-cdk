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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Inbox.Model;
using Gs2Cdk.Gs2Inbox.StampSheet;


namespace Gs2Cdk.Gs2Inbox.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentMessageMasterRef CurrentMessageMaster(
        ) {
            return new CurrentMessageMasterRef(
                this._namespaceName
            );
        }

        public GlobalMessageRef GlobalMessage(
                string globalMessageName
        ) {
            return new GlobalMessageRef(
                this._namespaceName,
                globalMessageName
            );
        }

        public GlobalMessageMasterRef GlobalMessageMaster(
                string globalMessageName
        ) {
            return new GlobalMessageMasterRef(
                this._namespaceName,
                globalMessageName
            );
        }

        public SendMessageByUserId SendMessage(
                string metadata,
                AcquireAction[] readAcquireActions = null,
                long? expiresAt = null,
                TimeSpan_ expiresTimeSpan = null,
                string userId = "#{userId}"
        ) {
            return new SendMessageByUserId(
                namespaceName: this._namespaceName,
                userId: userId,
                metadata: metadata,
                readAcquireActions: readAcquireActions,
                expiresAt: expiresAt,
                expiresTimeSpan: expiresTimeSpan
            );
        }

        public string Grn() {
            return new Join(
                ":",
                new string[] {
                    "grn",
                    "gs2",
                    GetAttr.Region().ToString(),
                    GetAttr.OwnerId().ToString(),
                    "inbox",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
