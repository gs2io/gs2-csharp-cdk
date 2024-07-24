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
using Gs2Cdk.Gs2Idle.Model;
using Gs2Cdk.Gs2Idle.Model.Options;

namespace Gs2Cdk.Gs2Idle.Model
{
    public class CategoryModel {
        private string name;
        private int rewardIntervalMinutes;
        private string rewardIntervalMinutesString;
        private int defaultMaximumIdleMinutes;
        private string defaultMaximumIdleMinutesString;
        private AcquireActionList[] acquireActions;
        private string metadata;
        private string idlePeriodScheduleId;
        private string receivePeriodScheduleId;

        public CategoryModel(
            string name,
            int rewardIntervalMinutes,
            int defaultMaximumIdleMinutes,
            AcquireActionList[] acquireActions,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.rewardIntervalMinutes = rewardIntervalMinutes;
            this.defaultMaximumIdleMinutes = defaultMaximumIdleMinutes;
            this.acquireActions = acquireActions;
            this.metadata = options?.metadata;
            this.idlePeriodScheduleId = options?.idlePeriodScheduleId;
            this.receivePeriodScheduleId = options?.receivePeriodScheduleId;
        }


        public CategoryModel(
            string name,
            string rewardIntervalMinutes,
            string defaultMaximumIdleMinutes,
            AcquireActionList[] acquireActions,
            CategoryModelOptions options = null
        ){
            this.name = name;
            this.rewardIntervalMinutesString = rewardIntervalMinutes;
            this.defaultMaximumIdleMinutesString = defaultMaximumIdleMinutes;
            this.acquireActions = acquireActions;
            this.metadata = options?.metadata;
            this.idlePeriodScheduleId = options?.idlePeriodScheduleId;
            this.receivePeriodScheduleId = options?.receivePeriodScheduleId;
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
            if (this.rewardIntervalMinutesString != null) {
                properties["rewardIntervalMinutes"] = this.rewardIntervalMinutesString;
            } else {
                if (this.rewardIntervalMinutes != null) {
                    properties["rewardIntervalMinutes"] = this.rewardIntervalMinutes;
                }
            }
            if (this.defaultMaximumIdleMinutesString != null) {
                properties["defaultMaximumIdleMinutes"] = this.defaultMaximumIdleMinutesString;
            } else {
                if (this.defaultMaximumIdleMinutes != null) {
                    properties["defaultMaximumIdleMinutes"] = this.defaultMaximumIdleMinutes;
                }
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.idlePeriodScheduleId != null) {
                properties["idlePeriodScheduleId"] = this.idlePeriodScheduleId;
            }
            if (this.receivePeriodScheduleId != null) {
                properties["receivePeriodScheduleId"] = this.receivePeriodScheduleId;
            }

            return properties;
        }

        public static CategoryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CategoryModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("rewardIntervalMinutes", out var rewardIntervalMinutes) ? new Func<int>(() =>
                {
                    return rewardIntervalMinutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("defaultMaximumIdleMinutes", out var defaultMaximumIdleMinutes) ? new Func<int>(() =>
                {
                    return defaultMaximumIdleMinutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireActionList[]>(() =>
                {
                    return acquireActions switch {
                        Dictionary<string, object>[] v => v.Select(AcquireActionList.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ AcquireActionList.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(AcquireActionList.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as AcquireActionList).ToArray(),
                        { } v => new []{ v as AcquireActionList },
                        _ => null
                    };
                })() : null,
                new CategoryModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    idlePeriodScheduleId = properties.TryGetValue("idlePeriodScheduleId", out var idlePeriodScheduleId) ? (string)idlePeriodScheduleId : null,
                    receivePeriodScheduleId = properties.TryGetValue("receivePeriodScheduleId", out var receivePeriodScheduleId) ? (string)receivePeriodScheduleId : null
                }
            );

            return model;
        }
    }
}
