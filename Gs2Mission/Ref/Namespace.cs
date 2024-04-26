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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.StampSheet;

namespace Gs2Cdk.Gs2Mission.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public MissionGroupModelRef MissionGroupModel(
            string missionGroupName
        ){
            return (new MissionGroupModelRef(
                this.namespaceName,
                missionGroupName
            ));
        }

        public CounterModelRef CounterModel(
            string counterName
        ){
            return (new CounterModelRef(
                this.namespaceName,
                counterName
            ));
        }

        public RevertReceiveByUserId RevertReceive(
            string missionGroupName,
            string missionTaskName,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new RevertReceiveByUserId(
                this.namespaceName,
                missionGroupName,
                missionTaskName,
                timeOffsetToken,
                userId
            ));
        }

        public IncreaseCounterByUserId IncreaseCounter(
            string counterName,
            long value,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new IncreaseCounterByUserId(
                this.namespaceName,
                counterName,
                value,
                timeOffsetToken,
                userId
            ));
        }

        public SetCounterByUserId SetCounter(
            string counterName,
            ScopedValue[] values = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetCounterByUserId(
                this.namespaceName,
                counterName,
                values,
                timeOffsetToken,
                userId
            ));
        }

        public ReceiveByUserId Receive(
            string missionGroupName,
            string missionTaskName,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ReceiveByUserId(
                this.namespaceName,
                missionGroupName,
                missionTaskName,
                timeOffsetToken,
                userId
            ));
        }

        public DecreaseCounterByUserId DecreaseCounter(
            string counterName,
            long value,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new DecreaseCounterByUserId(
                this.namespaceName,
                counterName,
                value,
                timeOffsetToken,
                userId
            ));
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
                    "mission",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
