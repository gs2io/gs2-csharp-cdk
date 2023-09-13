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
using Gs2Cdk.Gs2LoginReward.Model;
using Gs2Cdk.Gs2LoginReward.Model.Enums;
using Gs2Cdk.Gs2LoginReward.Model.Options;

namespace Gs2Cdk.Gs2LoginReward.Model
{
    public class BonusModel {
        private string name;
        private BonusModelMode? mode;
        private BonusModelMissedReceiveRelief? missedReceiveRelief;
        private string metadata;
        private string periodEventId;
        private int? resetHour;
        private BonusModelRepeat? repeat;
        private Reward[] rewards;
        private ConsumeAction[] missedReceiveReliefConsumeActions;

        public BonusModel(
            string name,
            BonusModelMode mode,
            BonusModelMissedReceiveRelief missedReceiveRelief,
            BonusModelOptions options = null
        ){
            this.name = name;
            this.mode = mode;
            this.missedReceiveRelief = missedReceiveRelief;
            this.metadata = options?.metadata;
            this.periodEventId = options?.periodEventId;
            this.resetHour = options?.resetHour;
            this.repeat = options?.repeat;
            this.rewards = options?.rewards;
            this.missedReceiveReliefConsumeActions = options?.missedReceiveReliefConsumeActions;
        }

        public static BonusModel ModeIsSchedule(
            string name,
            BonusModelMissedReceiveRelief missedReceiveRelief,
            BonusModelModeIsScheduleOptions options = null
        ){
            return (new BonusModel(
                name,
                BonusModelMode.Schedule,
                missedReceiveRelief,
                new BonusModelOptions {
                    metadata = options?.metadata,
                    periodEventId = options?.periodEventId,
                    rewards = options?.rewards,
                    missedReceiveReliefConsumeActions = options?.missedReceiveReliefConsumeActions,
                }
            ));
        }

        public static BonusModel ModeIsStreaming(
            string name,
            BonusModelMissedReceiveRelief missedReceiveRelief,
            BonusModelRepeat repeat,
            BonusModelModeIsStreamingOptions options = null
        ){
            return (new BonusModel(
                name,
                BonusModelMode.Streaming,
                missedReceiveRelief,
                new BonusModelOptions {
                    repeat = repeat,
                    metadata = options?.metadata,
                    periodEventId = options?.periodEventId,
                    rewards = options?.rewards,
                    missedReceiveReliefConsumeActions = options?.missedReceiveReliefConsumeActions,
                }
            ));
        }

        public static BonusModel MissedReceiveReliefIsEnabled(
            string name,
            BonusModelMode mode,
            BonusModelMissedReceiveReliefIsEnabledOptions options = null
        ){
            return (new BonusModel(
                name,
                mode,
                BonusModelMissedReceiveRelief.Enabled,
                new BonusModelOptions {
                    metadata = options?.metadata,
                    periodEventId = options?.periodEventId,
                    rewards = options?.rewards,
                    missedReceiveReliefConsumeActions = options?.missedReceiveReliefConsumeActions,
                }
            ));
        }

        public static BonusModel MissedReceiveReliefIsDisabled(
            string name,
            BonusModelMode mode,
            BonusModelMissedReceiveReliefIsDisabledOptions options = null
        ){
            return (new BonusModel(
                name,
                mode,
                BonusModelMissedReceiveRelief.Disabled,
                new BonusModelOptions {
                    metadata = options?.metadata,
                    periodEventId = options?.periodEventId,
                    rewards = options?.rewards,
                    missedReceiveReliefConsumeActions = options?.missedReceiveReliefConsumeActions,
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
            if (this.mode != null) {
                properties["mode"] = this.mode?.Str(
                );
            }
            if (this.periodEventId != null) {
                properties["periodEventId"] = this.periodEventId;
            }
            if (this.resetHour != null) {
                properties["resetHour"] = this.resetHour;
            }
            if (this.repeat != null) {
                properties["repeat"] = this.repeat?.Str(
                );
            }
            if (this.rewards != null) {
                properties["rewards"] = this.rewards.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.missedReceiveRelief != null) {
                properties["missedReceiveRelief"] = this.missedReceiveRelief?.Str(
                );
            }
            if (this.missedReceiveReliefConsumeActions != null) {
                properties["missedReceiveReliefConsumeActions"] = this.missedReceiveReliefConsumeActions.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static BonusModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BonusModel(
                (string)properties["name"],
                new Func<BonusModelMode>(() =>
                {
                    return properties["mode"] switch {
                        BonusModelMode e => e,
                        string s => BonusModelModeExt.New(s),
                        _ => BonusModelMode.Schedule
                    };
                })(),
                new Func<BonusModelMissedReceiveRelief>(() =>
                {
                    return properties["missedReceiveRelief"] switch {
                        BonusModelMissedReceiveRelief e => e,
                        string s => BonusModelMissedReceiveReliefExt.New(s),
                        _ => BonusModelMissedReceiveRelief.Enabled
                    };
                })(),
                new BonusModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    periodEventId = properties.TryGetValue("periodEventId", out var periodEventId) ? (string)periodEventId : null,
                    resetHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetHour", out var resetHour) ? resetHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    repeat = properties.TryGetValue("repeat", out var repeat) ? BonusModelRepeatExt.New(repeat as string) : BonusModelRepeat.Enabled,
                    rewards = properties.TryGetValue("rewards", out var rewards) ? new Func<Reward[]>(() =>
                    {
                        return rewards switch {
                            Reward[] v => v,
                            List<Reward> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(Reward.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(Reward.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    missedReceiveReliefConsumeActions = properties.TryGetValue("missedReceiveReliefConsumeActions", out var missedReceiveReliefConsumeActions) ? new Func<ConsumeAction[]>(() =>
                    {
                        return missedReceiveReliefConsumeActions switch {
                            ConsumeAction[] v => v,
                            List<ConsumeAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
