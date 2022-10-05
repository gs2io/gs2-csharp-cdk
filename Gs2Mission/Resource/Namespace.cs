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
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly TransactionSetting _transactionSetting;
        private readonly ScriptSetting _missionCompleteScript;
        private readonly ScriptSetting _counterIncrementScript;
        private readonly ScriptSetting _receiveRewardsScript;
        private readonly NotificationSetting _completeNotification;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                TransactionSetting transactionSetting,
                string description = null,
                ScriptSetting missionCompleteScript = null,
                ScriptSetting counterIncrementScript = null,
                ScriptSetting receiveRewardsScript = null,
                NotificationSetting completeNotification = null,
                LogSetting logSetting = null
        ): base("Mission_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._transactionSetting = transactionSetting;
            this._missionCompleteScript = missionCompleteScript;
            this._counterIncrementScript = counterIncrementScript;
            this._receiveRewardsScript = receiveRewardsScript;
            this._completeNotification = completeNotification;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Mission::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._transactionSetting != null) {
                properties["TransactionSetting"] = this._transactionSetting.Properties();
            }
            if (this._missionCompleteScript != null) {
                properties["MissionCompleteScript"] = this._missionCompleteScript.Properties();
            }
            if (this._counterIncrementScript != null) {
                properties["CounterIncrementScript"] = this._counterIncrementScript.Properties();
            }
            if (this._receiveRewardsScript != null) {
                properties["ReceiveRewardsScript"] = this._receiveRewardsScript.Properties();
            }
            if (this._completeNotification != null) {
                properties["CompleteNotification"] = this._completeNotification.Properties();
            }
            if (this._logSetting != null) {
                properties["LogSetting"] = this._logSetting.Properties();
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }

        public Namespace MasterData(
                MissionGroupModel[] missionGroupModels,
                CounterModel[] counterModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                missionGroupModels,
                counterModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
