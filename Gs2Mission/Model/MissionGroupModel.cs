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
    public class MissionGroupModel {
        private string name;
        private MissionGroupModelResetType? resetType;
        private string metadata;
        private MissionTaskModel[] tasks;
        private int? resetDayOfMonth;
        private string resetDayOfMonthString;
        private MissionGroupModelResetDayOfWeek? resetDayOfWeek;
        private int? resetHour;
        private string resetHourString;
        private string completeNotificationNamespaceId;
        private long? anchorTimestamp;
        private string anchorTimestampString;
        private int? days;
        private string daysString;

        public MissionGroupModel(
            string name,
            MissionGroupModelResetType resetType,
            MissionGroupModelOptions options = null
        ){
            this.name = name;
            this.resetType = resetType;
            this.metadata = options?.metadata;
            this.tasks = options?.tasks;
            this.resetDayOfMonth = options?.resetDayOfMonth;
            this.resetDayOfWeek = options?.resetDayOfWeek;
            this.resetHour = options?.resetHour;
            this.completeNotificationNamespaceId = options?.completeNotificationNamespaceId;
            this.anchorTimestamp = options?.anchorTimestamp;
            this.days = options?.days;
        }

        public static MissionGroupModel ResetTypeIsNotReset(
            string name,
            MissionGroupModelResetTypeIsNotResetOptions options = null
        ){
            return (new MissionGroupModel(
                name,
                MissionGroupModelResetType.NotReset,
                new MissionGroupModelOptions {
                    metadata = options?.metadata,
                    tasks = options?.tasks,
                    completeNotificationNamespaceId = options?.completeNotificationNamespaceId,
                }
            ));
        }

        public static MissionGroupModel ResetTypeIsDaily(
            string name,
            int? resetHour,
            MissionGroupModelResetTypeIsDailyOptions options = null
        ){
            return (new MissionGroupModel(
                name,
                MissionGroupModelResetType.Daily,
                new MissionGroupModelOptions {
                    resetHour = resetHour,
                    metadata = options?.metadata,
                    tasks = options?.tasks,
                    completeNotificationNamespaceId = options?.completeNotificationNamespaceId,
                }
            ));
        }

        public static MissionGroupModel ResetTypeIsWeekly(
            string name,
            MissionGroupModelResetDayOfWeek resetDayOfWeek,
            int? resetHour,
            MissionGroupModelResetTypeIsWeeklyOptions options = null
        ){
            return (new MissionGroupModel(
                name,
                MissionGroupModelResetType.Weekly,
                new MissionGroupModelOptions {
                    resetDayOfWeek = resetDayOfWeek,
                    resetHour = resetHour,
                    metadata = options?.metadata,
                    tasks = options?.tasks,
                    completeNotificationNamespaceId = options?.completeNotificationNamespaceId,
                }
            ));
        }

        public static MissionGroupModel ResetTypeIsMonthly(
            string name,
            int? resetDayOfMonth,
            int? resetHour,
            MissionGroupModelResetTypeIsMonthlyOptions options = null
        ){
            return (new MissionGroupModel(
                name,
                MissionGroupModelResetType.Monthly,
                new MissionGroupModelOptions {
                    resetDayOfMonth = resetDayOfMonth,
                    resetHour = resetHour,
                    metadata = options?.metadata,
                    tasks = options?.tasks,
                    completeNotificationNamespaceId = options?.completeNotificationNamespaceId,
                }
            ));
        }

        public static MissionGroupModel ResetTypeIsDays(
            string name,
            long? anchorTimestamp,
            int? days,
            MissionGroupModelResetTypeIsDaysOptions options = null
        ){
            return (new MissionGroupModel(
                name,
                MissionGroupModelResetType.Days,
                new MissionGroupModelOptions {
                    anchorTimestamp = anchorTimestamp,
                    days = days,
                    metadata = options?.metadata,
                    tasks = options?.tasks,
                    completeNotificationNamespaceId = options?.completeNotificationNamespaceId,
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
            if (this.tasks != null) {
                properties["tasks"] = this.tasks.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.resetDayOfMonthString != null) {
                properties["resetDayOfMonth"] = this.resetDayOfMonthString;
            } else {
                if (this.resetDayOfMonth != null) {
                    properties["resetDayOfMonth"] = this.resetDayOfMonth;
                }
            }
            if (this.resetDayOfWeek != null) {
                properties["resetDayOfWeek"] = this.resetDayOfWeek.Value.Str(
                );
            }
            if (this.resetHourString != null) {
                properties["resetHour"] = this.resetHourString;
            } else {
                if (this.resetHour != null) {
                    properties["resetHour"] = this.resetHour;
                }
            }
            if (this.completeNotificationNamespaceId != null) {
                properties["completeNotificationNamespaceId"] = this.completeNotificationNamespaceId;
            }
            if (this.anchorTimestampString != null) {
                properties["anchorTimestamp"] = this.anchorTimestampString;
            } else {
                if (this.anchorTimestamp != null) {
                    properties["anchorTimestamp"] = this.anchorTimestamp;
                }
            }
            if (this.daysString != null) {
                properties["days"] = this.daysString;
            } else {
                if (this.days != null) {
                    properties["days"] = this.days;
                }
            }

            return properties;
        }

        public static MissionGroupModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MissionGroupModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("resetType", out var resetType) ? new Func<MissionGroupModelResetType>(() =>
                {
                    return resetType switch {
                        MissionGroupModelResetType e => e,
                        string s => MissionGroupModelResetTypeExt.New(s),
                        _ => MissionGroupModelResetType.NotReset
                    };
                })() : default,
                new MissionGroupModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    tasks = properties.TryGetValue("tasks", out var tasks) ? new Func<MissionTaskModel[]>(() =>
                    {
                        return tasks switch {
                            MissionTaskModel[] v => v,
                            List<MissionTaskModel> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(MissionTaskModel.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(MissionTaskModel.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    resetDayOfMonth = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetDayOfMonth", out var resetDayOfMonth) ? resetDayOfMonth switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    resetDayOfWeek = properties.TryGetValue("resetDayOfWeek", out var resetDayOfWeek) ? MissionGroupModelResetDayOfWeekExt.New(resetDayOfWeek as string) : null,
                    resetHour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("resetHour", out var resetHour) ? resetHour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    completeNotificationNamespaceId = properties.TryGetValue("completeNotificationNamespaceId", out var completeNotificationNamespaceId) ? (string)completeNotificationNamespaceId : null,
                    anchorTimestamp = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("anchorTimestamp", out var anchorTimestamp) ? anchorTimestamp switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    days = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("days", out var days) ? days switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
