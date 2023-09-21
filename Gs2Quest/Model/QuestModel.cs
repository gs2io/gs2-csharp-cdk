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

        public static QuestModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new QuestModel(
                (string)properties["name"],
                new Func<Contents[]>(() =>
                {
                    return properties["contents"] switch {
                        Dictionary<string, object>[] v => v.Select(Contents.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ Contents.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(Contents.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as Contents).ToArray(),
                        { } v => new []{ v as Contents },
                        _ => null
                    };
                })(),
                new QuestModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    challengePeriodEventId = properties.TryGetValue("challengePeriodEventId", out var challengePeriodEventId) ? (string)challengePeriodEventId : null,
                    firstCompleteAcquireActions = properties.TryGetValue("firstCompleteAcquireActions", out var firstCompleteAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return firstCompleteAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    consumeActions = properties.TryGetValue("consumeActions", out var consumeActions) ? new Func<ConsumeAction[]>(() =>
                    {
                        return consumeActions switch {
                            ConsumeAction[] v => v,
                            List<ConsumeAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    failedAcquireActions = properties.TryGetValue("failedAcquireActions", out var failedAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return failedAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    premiseQuestNames = properties.TryGetValue("premiseQuestNames", out var premiseQuestNames) ? new Func<string[]>(() =>
                    {
                        return premiseQuestNames switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
