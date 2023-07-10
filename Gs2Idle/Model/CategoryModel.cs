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

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Idle.Model;
using Gs2Cdk.Gs2Idle.Model.Options;

namespace Gs2Cdk.Gs2Idle.Model
{
    public class CategoryModel {
        private string name;
        private int? rewardIntervalMinutes;
        private int? defaultMaximumIdleMinutes;
        private AcquireActionList[] acquireActions;
        private string metadata;
        private string idlePeriodScheduleId;
        private string receivePeriodScheduleId;

        public CategoryModel(
            string name,
            int? rewardIntervalMinutes,
            int? defaultMaximumIdleMinutes,
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

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.rewardIntervalMinutes != null) {
                properties["rewardIntervalMinutes"] = this.rewardIntervalMinutes;
            }
            if (this.defaultMaximumIdleMinutes != null) {
                properties["defaultMaximumIdleMinutes"] = this.defaultMaximumIdleMinutes;
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v.Properties(
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
    }
}
