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
using Gs2Cdk.Gs2Quest.Ref;

namespace Gs2Cdk.Gs2Quest.Resource
{
    public class QuestModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _questGroupName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly Contents[] _contents;
        private readonly string _challengePeriodEventId;
        private readonly AcquireAction[] _firstCompleteAcquireActions;
        private readonly ConsumeAction[] _consumeActions;
        private readonly AcquireAction[] _failedAcquireActions;
        private readonly string[] _premiseQuestNames;

        public QuestModelMaster(
                Stack stack,
                string namespaceName,
                string questGroupName,
                string name,
                Contents[] contents,
                string description = null,
                string metadata = null,
                string challengePeriodEventId = null,
                AcquireAction[] firstCompleteAcquireActions = null,
                ConsumeAction[] consumeActions = null,
                AcquireAction[] failedAcquireActions = null,
                string[] premiseQuestNames = null
        ): base("Quest_QuestModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._questGroupName = questGroupName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._contents = contents;
            this._challengePeriodEventId = challengePeriodEventId;
            this._firstCompleteAcquireActions = firstCompleteAcquireActions;
            this._consumeActions = consumeActions;
            this._failedAcquireActions = failedAcquireActions;
            this._premiseQuestNames = premiseQuestNames;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Quest::QuestModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._questGroupName != null) {
                properties["QuestGroupName"] = this._questGroupName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._contents != null) {
                properties["Contents"] = this._contents.Select(v => v.Properties()).ToArray();
            }
            if (this._challengePeriodEventId != null) {
                properties["ChallengePeriodEventId"] = this._challengePeriodEventId;
            }
            if (this._firstCompleteAcquireActions != null) {
                properties["FirstCompleteAcquireActions"] = this._firstCompleteAcquireActions.Select(v => v.Properties()).ToArray();
            }
            if (this._consumeActions != null) {
                properties["ConsumeActions"] = this._consumeActions.Select(v => v.Properties()).ToArray();
            }
            if (this._failedAcquireActions != null) {
                properties["FailedAcquireActions"] = this._failedAcquireActions.Select(v => v.Properties()).ToArray();
            }
            if (this._premiseQuestNames != null) {
                properties["PremiseQuestNames"] = this._premiseQuestNames;
            }
            return properties;
        }

        public QuestModelMasterRef Ref(
                string namespaceName,
                string questGroupName
        ) {
            return new QuestModelMasterRef(
                namespaceName,
                questGroupName,
                this._name
            );
        }

        public GetAttr GetAttrQuestModelId() {
            return new GetAttr(
                "Item.QuestModelId"
            );
        }
    }
}
