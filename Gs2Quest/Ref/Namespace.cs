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
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.StampSheet;


namespace Gs2Cdk.Gs2Quest.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentQuestMasterRef CurrentQuestMaster(
        ) {
            return new CurrentQuestMasterRef(
                this._namespaceName
            );
        }

        public QuestGroupModelRef QuestGroupModel(
                string questGroupName
        ) {
            return new QuestGroupModelRef(
                this._namespaceName,
                questGroupName
            );
        }

        public QuestGroupModelMasterRef QuestGroupModelMaster(
                string questGroupName
        ) {
            return new QuestGroupModelMasterRef(
                this._namespaceName,
                questGroupName
            );
        }

        public CreateProgressByUserId CreateProgress(
                string questModelId,
                bool? force,
                Config[] config = null,
                string userId = "#{userId}"
        ) {
            return new CreateProgressByUserId(
                namespaceName: this._namespaceName,
                userId: userId,
                questModelId: questModelId,
                force: force,
                config: config
            );
        }

        public DeleteProgressByUserId DeleteProgress(
                string userId = "#{userId}"
        ) {
            return new DeleteProgressByUserId(
                namespaceName: this._namespaceName,
                userId: userId
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
                    "quest",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
