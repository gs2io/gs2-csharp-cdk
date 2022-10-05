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

    public class QuestGroupModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly QuestModel[] _quests;
	    private readonly string _challengePeriodEventId;

        public QuestGroupModel(
                string name,
                string metadata = null,
                QuestModel[] quests = null,
                string challengePeriodEventId = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._quests = quests;
            this._challengePeriodEventId = challengePeriodEventId;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._quests != null) {
                properties["Quests"] = this._quests.Select(v => v.Properties()).ToArray();
            }
            if (this._challengePeriodEventId != null) {
                properties["ChallengePeriodEventId"] = this._challengePeriodEventId;
            }
            return properties;
        }

        public QuestGroupModelRef Ref(
                string namespaceName
        )
        {
            return new QuestGroupModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
