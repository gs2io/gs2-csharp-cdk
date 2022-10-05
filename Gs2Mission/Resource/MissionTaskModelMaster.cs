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
using Gs2Cdk.Gs2Mission.Ref;

namespace Gs2Cdk.Gs2Mission.Resource
{
    public class MissionTaskModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _missionGroupName;
        private readonly string _name;
        private readonly string _metadata;
        private readonly string _description;
        private readonly string _counterName;
        private readonly long? _targetValue;
        private readonly AcquireAction[] _completeAcquireActions;
        private readonly string _challengePeriodEventId;
        private readonly string _premiseMissionTaskName;

        public MissionTaskModelMaster(
                Stack stack,
                string namespaceName,
                string missionGroupName,
                string name,
                string counterName,
                long? targetValue,
                string metadata = null,
                string description = null,
                AcquireAction[] completeAcquireActions = null,
                string challengePeriodEventId = null,
                string premiseMissionTaskName = null
        ): base("Mission_MissionTaskModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._missionGroupName = missionGroupName;
            this._name = name;
            this._metadata = metadata;
            this._description = description;
            this._counterName = counterName;
            this._targetValue = targetValue;
            this._completeAcquireActions = completeAcquireActions;
            this._challengePeriodEventId = challengePeriodEventId;
            this._premiseMissionTaskName = premiseMissionTaskName;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Mission::MissionTaskModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._missionGroupName != null) {
                properties["MissionGroupName"] = this._missionGroupName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._counterName != null) {
                properties["CounterName"] = this._counterName;
            }
            if (this._targetValue != null) {
                properties["TargetValue"] = this._targetValue;
            }
            if (this._completeAcquireActions != null) {
                properties["CompleteAcquireActions"] = this._completeAcquireActions.Select(v => v.Properties()).ToArray();
            }
            if (this._challengePeriodEventId != null) {
                properties["ChallengePeriodEventId"] = this._challengePeriodEventId;
            }
            if (this._premiseMissionTaskName != null) {
                properties["PremiseMissionTaskName"] = this._premiseMissionTaskName;
            }
            return properties;
        }

        public MissionTaskModelMasterRef Ref(
                string namespaceName,
                string missionGroupName
        ) {
            return new MissionTaskModelMasterRef(
                namespaceName,
                missionGroupName,
                this._name
            );
        }

        public GetAttr GetAttrMissionTaskId() {
            return new GetAttr(
                "Item.MissionTaskId"
            );
        }
    }
}
