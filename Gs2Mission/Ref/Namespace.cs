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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.StampSheet;


namespace Gs2Cdk.Gs2Mission.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentMissionMasterRef CurrentMissionMaster(
        ) {
            return new CurrentMissionMasterRef(
                this._namespaceName
            );
        }

        public MissionGroupModelRef MissionGroupModel(
                string missionGroupName
        ) {
            return new MissionGroupModelRef(
                this._namespaceName,
                missionGroupName
            );
        }

        public CounterModelRef CounterModel(
                string counterName
        ) {
            return new CounterModelRef(
                this._namespaceName,
                counterName
            );
        }

        public MissionGroupModelMasterRef MissionGroupModelMaster(
                string missionGroupName
        ) {
            return new MissionGroupModelMasterRef(
                this._namespaceName,
                missionGroupName
            );
        }

        public CounterModelMasterRef CounterModelMaster(
                string counterName
        ) {
            return new CounterModelMasterRef(
                this._namespaceName,
                counterName
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
                    "mission",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
