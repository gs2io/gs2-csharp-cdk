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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Model.Enums;
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class MissionTaskModel {
        private string name;
        private string counterName;
        private long targetValue;
        private string metadata;
        private MissionTaskModelTargetResetType? targetResetType;
        private AcquireAction[] completeAcquireActions;
        private string challengePeriodEventId;
        private string premiseMissionTaskName;

        public MissionTaskModel(
            string name,
            string counterName,
            long targetValue,
            MissionTaskModelOptions options = null
        ){
            this.name = name;
            this.counterName = counterName;
            this.targetValue = targetValue;
            this.metadata = options?.metadata;
            this.targetResetType = options?.targetResetType;
            this.completeAcquireActions = options?.completeAcquireActions;
            this.challengePeriodEventId = options?.challengePeriodEventId;
            this.premiseMissionTaskName = options?.premiseMissionTaskName;
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
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.targetResetType != null) {
                properties["targetResetType"] = this.targetResetType?.Str(
                );
            }
            if (this.targetValue != null) {
                properties["targetValue"] = this.targetValue;
            }
            if (this.completeAcquireActions != null) {
                properties["completeAcquireActions"] = this.completeAcquireActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.challengePeriodEventId != null) {
                properties["challengePeriodEventId"] = this.challengePeriodEventId;
            }
            if (this.premiseMissionTaskName != null) {
                properties["premiseMissionTaskName"] = this.premiseMissionTaskName;
            }

            return properties;
        }

        public static MissionTaskModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MissionTaskModel(
                (string)properties["name"],
                (string)properties["counterName"],
                new Func<long>(() =>
                {
                    return properties["targetValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new MissionTaskModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    targetResetType = properties.TryGetValue("targetResetType", out var targetResetType) ? MissionTaskModelTargetResetTypeExt.New(targetResetType as string) : MissionTaskModelTargetResetType.NotReset,
                    completeAcquireActions = properties.TryGetValue("completeAcquireActions", out var completeAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return completeAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    challengePeriodEventId = properties.TryGetValue("challengePeriodEventId", out var challengePeriodEventId) ? (string)challengePeriodEventId : null,
                    premiseMissionTaskName = properties.TryGetValue("premiseMissionTaskName", out var premiseMissionTaskName) ? (string)premiseMissionTaskName : null
                }
            );

            return model;
        }
    }
}
