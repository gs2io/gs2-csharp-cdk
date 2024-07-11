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
using Gs2Cdk.Gs2Buff.Model;
using Gs2Cdk.Gs2Buff.Model.Enums;
using Gs2Cdk.Gs2Buff.Model.Options;

namespace Gs2Cdk.Gs2Buff.Model
{
    public class BuffEntryModel {
        private string name;
        private BuffEntryModelExpression? expression;
        private BuffEntryModelTargetType? targetType;
        private int priority;
        private string priorityString;
        private string metadata;
        private BuffTargetModel targetModel;
        private BuffTargetAction targetAction;
        private string applyPeriodScheduleEventId;

        public BuffEntryModel(
            string name,
            BuffEntryModelExpression expression,
            BuffEntryModelTargetType targetType,
            int priority,
            BuffEntryModelOptions options = null
        ){
            this.name = name;
            this.expression = expression;
            this.targetType = targetType;
            this.priority = priority;
            this.metadata = options?.metadata;
            this.targetModel = options?.targetModel;
            this.targetAction = options?.targetAction;
            this.applyPeriodScheduleEventId = options?.applyPeriodScheduleEventId;
        }

        public static BuffEntryModel TargetTypeIsModel(
            string name,
            BuffEntryModelExpression expression,
            int priority,
            BuffTargetModel targetModel,
            BuffEntryModelTargetTypeIsModelOptions options = null
        ){
            return (new BuffEntryModel(
                name,
                expression,
                BuffEntryModelTargetType.Model,
                priority,
                new BuffEntryModelOptions {
                    targetModel = targetModel,
                    metadata = options?.metadata,
                    applyPeriodScheduleEventId = options?.applyPeriodScheduleEventId,
                }
            ));
        }

        public static BuffEntryModel TargetTypeIsAction(
            string name,
            BuffEntryModelExpression expression,
            int priority,
            BuffTargetAction targetAction,
            BuffEntryModelTargetTypeIsActionOptions options = null
        ){
            return (new BuffEntryModel(
                name,
                expression,
                BuffEntryModelTargetType.Action,
                priority,
                new BuffEntryModelOptions {
                    targetAction = targetAction,
                    metadata = options?.metadata,
                    applyPeriodScheduleEventId = options?.applyPeriodScheduleEventId,
                }
            ));
        }


        public BuffEntryModel(
            string name,
            BuffEntryModelExpression expression,
            BuffEntryModelTargetType targetType,
            string priority,
            BuffEntryModelOptions options = null
        ){
            this.name = name;
            this.expression = expression;
            this.targetType = targetType;
            this.priorityString = priority;
            this.metadata = options?.metadata;
            this.targetModel = options?.targetModel;
            this.targetAction = options?.targetAction;
            this.applyPeriodScheduleEventId = options?.applyPeriodScheduleEventId;
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
            if (this.expression != null) {
                properties["expression"] = this.expression.Value.Str(
                );
            }
            if (this.targetType != null) {
                properties["targetType"] = this.targetType.Value.Str(
                );
            }
            if (this.targetModel != null) {
                properties["targetModel"] = this.targetModel?.Properties(
                );
            }
            if (this.targetAction != null) {
                properties["targetAction"] = this.targetAction?.Properties(
                );
            }
            if (this.priorityString != null) {
                properties["priority"] = this.priorityString;
            } else {
                if (this.priority != null) {
                    properties["priority"] = this.priority;
                }
            }
            if (this.applyPeriodScheduleEventId != null) {
                properties["applyPeriodScheduleEventId"] = this.applyPeriodScheduleEventId;
            }

            return properties;
        }

        public static BuffEntryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BuffEntryModel(
                (string)properties["name"],
                new Func<BuffEntryModelExpression>(() =>
                {
                    return properties["expression"] switch {
                        BuffEntryModelExpression e => e,
                        string s => BuffEntryModelExpressionExt.New(s),
                        _ => BuffEntryModelExpression.RateAdd
                    };
                })(),
                new Func<BuffEntryModelTargetType>(() =>
                {
                    return properties["targetType"] switch {
                        BuffEntryModelTargetType e => e,
                        string s => BuffEntryModelTargetTypeExt.New(s),
                        _ => BuffEntryModelTargetType.Model
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["priority"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new BuffEntryModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    targetModel = properties.TryGetValue("targetModel", out var targetModel) ? new Func<BuffTargetModel>(() =>
                    {
                        return targetModel switch {
                            BuffTargetModel v => v,
                            Dictionary<string, object> v => BuffTargetModel.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    targetAction = properties.TryGetValue("targetAction", out var targetAction) ? new Func<BuffTargetAction>(() =>
                    {
                        return targetAction switch {
                            BuffTargetAction v => v,
                            Dictionary<string, object> v => BuffTargetAction.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    applyPeriodScheduleEventId = properties.TryGetValue("applyPeriodScheduleEventId", out var applyPeriodScheduleEventId) ? (string)applyPeriodScheduleEventId : null
                }
            );

            return model;
        }
    }
}
