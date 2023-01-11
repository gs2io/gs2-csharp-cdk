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

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.StampSheet;

namespace Gs2Cdk.Gs2Quest.Ref
{
    public class QuestModelRef {
        private string namespaceName;
        private string questGroupName;
        private string questName;

        public QuestModelRef(
            string namespaceName,
            string questGroupName,
            string questName
        ){
            this.namespaceName = namespaceName;
            this.questGroupName = questGroupName;
            this.questName = questName;
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "quest",
                    this.namespaceName,
                    "group",
                    this.questGroupName,
                    "quest",
                    this.questName
                }
            )).Str(
            );
        }
    }
}
