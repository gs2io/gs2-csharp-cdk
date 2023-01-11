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
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.Model.Options;

namespace Gs2Cdk.Gs2Quest.Model
{
    public class QuestModel {
        private string name;
        private Contents[] contents;
        private string metadata;
        private string challengePeriodEventId;
        private AcquireAction[] firstCompleteAcquireActions;
        private ConsumeAction[] consumeActions;
        private AcquireAction[] failedAcquireActions;
        private string[] premiseQuestNames;

        public QuestModel(
            string name,
            Contents[] contents,
            QuestModelOptions options = null
        ){
            this.name = name;
            this.contents = contents;
            this.metadata = options?.metadata;
            this.challengePeriodEventId = options?.challengePeriodEventId;
            this.firstCompleteAcquireActions = options?.firstCompleteAcquireActions;
            this.consumeActions = options?.consumeActions;
            this.failedAcquireActions = options?.failedAcquireActions;
            this.premiseQuestNames = options?.premiseQuestNames;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.contents != null) {
                properties["contents"] = this.contents.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.challengePeriodEventId != null) {
                properties["challengePeriodEventId"] = this.challengePeriodEventId;
            }
            if (this.firstCompleteAcquireActions != null) {
                properties["firstCompleteAcquireActions"] = this.firstCompleteAcquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.consumeActions != null) {
                properties["consumeActions"] = this.consumeActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.failedAcquireActions != null) {
                properties["failedAcquireActions"] = this.failedAcquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.premiseQuestNames != null) {
                properties["premiseQuestNames"] = this.premiseQuestNames;
            }

            return properties;
        }
    }
}
