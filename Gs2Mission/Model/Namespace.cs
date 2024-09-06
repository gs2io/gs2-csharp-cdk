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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Mission.Ref;
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public TransactionSetting transactionSetting;
        public ScriptSetting missionCompleteScript;
        public ScriptSetting counterIncrementScript;
        public ScriptSetting receiveRewardsScript;
        public NotificationSetting completeNotification;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Mission_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.missionCompleteScript = options?.missionCompleteScript;
            this.counterIncrementScript = options?.counterIncrementScript;
            this.receiveRewardsScript = options?.receiveRewardsScript;
            this.completeNotification = options?.completeNotification;
            this.logSetting = options?.logSetting;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::Mission::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.missionCompleteScript != null) {
                properties["MissionCompleteScript"] = this.missionCompleteScript?.Properties(
                );
            }
            if (this.counterIncrementScript != null) {
                properties["CounterIncrementScript"] = this.counterIncrementScript?.Properties(
                );
            }
            if (this.receiveRewardsScript != null) {
                properties["ReceiveRewardsScript"] = this.receiveRewardsScript?.Properties(
                );
            }
            if (this.completeNotification != null) {
                properties["CompleteNotification"] = this.completeNotification?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["LogSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public NamespaceRef Ref(
        ){
            return (new NamespaceRef(
                this.name
            ));
        }

        public GetAttr GetAttrNamespaceId(
        ){
            return (new GetAttr(
                this,
                "Item.NamespaceId",
                null
            ));
        }

        public Namespace MasterData(
            MissionGroupModel[] groups,
            CounterModel[] counters
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                groups,
                counters
            )).AddDependsOn(
                this
            );
            return this;
        }

        public Namespace MasterData(
            Dictionary<string, object> properties
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                new Func<MissionGroupModel[]>(() =>
                {
                    return properties["groups"] switch {
                        MissionGroupModel[] v => v,
                        List<MissionGroupModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(MissionGroupModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(MissionGroupModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<CounterModel[]>(() =>
                {
                    return properties["counters"] switch {
                        CounterModel[] v => v,
                        List<CounterModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(CounterModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(CounterModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })()
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
