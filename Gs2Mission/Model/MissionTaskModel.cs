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
 *
 * deny overwrite
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
        private MissionTaskModelVerifyCompleteType? verifyCompleteType;
        private string counterName;
        private long targetValue;
        private string targetValueString;
        private string metadata;
        private TargetCounterModel targetCounter;
        private VerifyAction[] verifyCompleteConsumeActions;
        private AcquireAction[] completeAcquireActions;
        private string challengePeriodEventId;
        private string premiseMissionTaskName;
        private MissionTaskModelTargetResetType? targetResetType;

        public MissionTaskModel(
            string name,
            MissionTaskModelVerifyCompleteType verifyCompleteType,
            MissionTaskModelOptions options = null
        ){
            this.name = name;
            this.verifyCompleteType = verifyCompleteType;
            this.metadata = options?.metadata;
            this.targetCounter = options?.targetCounter;
            this.verifyCompleteConsumeActions = options?.verifyCompleteConsumeActions;
            this.completeAcquireActions = options?.completeAcquireActions;
            this.challengePeriodEventId = options?.challengePeriodEventId;
            this.premiseMissionTaskName = options?.premiseMissionTaskName;
            this.targetResetType = options?.targetResetType;
        }

        public static MissionTaskModel VerifyCompleteTypeIsCounter(
            string name,
            TargetCounterModel targetCounter,
            MissionTaskModelVerifyCompleteTypeIsCounterOptions options = null
        ){
            return (new MissionTaskModel(
                name,
                MissionTaskModelVerifyCompleteType.Counter,
                new MissionTaskModelOptions {
                    targetCounter = targetCounter,
                    metadata = options?.metadata,
                    verifyCompleteConsumeActions = options?.verifyCompleteConsumeActions,
                    completeAcquireActions = options?.completeAcquireActions,
                    challengePeriodEventId = options?.challengePeriodEventId,
                    premiseMissionTaskName = options?.premiseMissionTaskName,
                    targetResetType = options?.targetResetType,
                }
            ));
        }

        public static MissionTaskModel VerifyCompleteTypeIsVerifyActions(
            string name,
            MissionTaskModelVerifyCompleteTypeIsVerifyActionsOptions options = null
        ){
            return (new MissionTaskModel(
                name,
                MissionTaskModelVerifyCompleteType.VerifyActions,
                new MissionTaskModelOptions {
                    metadata = options?.metadata,
                    verifyCompleteConsumeActions = options?.verifyCompleteConsumeActions,
                    completeAcquireActions = options?.completeAcquireActions,
                    challengePeriodEventId = options?.challengePeriodEventId,
                    premiseMissionTaskName = options?.premiseMissionTaskName,
                    targetResetType = options?.targetResetType,
                }
            ));
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
            if (this.verifyCompleteType != null) {
                properties["verifyCompleteType"] = this.verifyCompleteType.Value.Str(
                );
            }
            if (this.targetCounter != null) {
                properties["targetCounter"] = this.targetCounter?.Properties(
                );
            }
            if (this.verifyCompleteConsumeActions != null) {
                properties["verifyCompleteConsumeActions"] = this.verifyCompleteConsumeActions.Select(v => v?.Properties(
                        )).ToList();
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
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.targetResetType != null) {
                properties["targetResetType"] = this.targetResetType.Value.Str(
                );
            }
            if (this.targetValueString != null) {
                properties["targetValue"] = this.targetValueString;
            } else {
                if (this.targetValue != null) {
                    properties["targetValue"] = this.targetValue;
                }
            }

            return properties;
        }

        public static MissionTaskModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MissionTaskModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("verifyCompleteType", out var verifyCompleteType) ? new Func<MissionTaskModelVerifyCompleteType>(() =>
                {
                    return verifyCompleteType switch {
                        MissionTaskModelVerifyCompleteType e => e,
                        string s => MissionTaskModelVerifyCompleteTypeExt.New(s),
                        _ => MissionTaskModelVerifyCompleteType.Counter
                    };
                })() : default,
                new MissionTaskModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    targetCounter = properties.TryGetValue("targetCounter", out var targetCounter) ? new Func<TargetCounterModel>(() =>
                    {
                        return targetCounter switch {
                            TargetCounterModel v => v,
                            Dictionary<string, object> v => TargetCounterModel.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    verifyCompleteConsumeActions = properties.TryGetValue("verifyCompleteConsumeActions", out var verifyCompleteConsumeActions) ? new Func<VerifyAction[]>(() =>
                    {
                        return verifyCompleteConsumeActions switch {
                            VerifyAction[] v => v,
                            List<VerifyAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(VerifyAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(VerifyAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
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
                    premiseMissionTaskName = properties.TryGetValue("premiseMissionTaskName", out var premiseMissionTaskName) ? (string)premiseMissionTaskName : null,
                    targetResetType = properties.TryGetValue("targetResetType", out var targetResetType) ? MissionTaskModelTargetResetTypeExt.New(targetResetType as string) : null
                }
            );

            return model;
        }
    }
}
