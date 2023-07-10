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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.Model.Options;

namespace Gs2Cdk.Gs2Schedule.Model
{
    public class RepeatSchedule {
        private int? repeatCount;
        private long? currentRepeatStartAt;
        private long? currentRepeatEndAt;
        private long? lastRepeatEndAt;
        private long? nextRepeatStartAt;

        public RepeatSchedule(
            int? repeatCount,
            RepeatScheduleOptions options = null
        ){
            this.repeatCount = repeatCount;
            this.currentRepeatStartAt = options?.currentRepeatStartAt;
            this.currentRepeatEndAt = options?.currentRepeatEndAt;
            this.lastRepeatEndAt = options?.lastRepeatEndAt;
            this.nextRepeatStartAt = options?.nextRepeatStartAt;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.repeatCount != null) {
                properties["repeatCount"] = this.repeatCount;
            }
            if (this.currentRepeatStartAt != null) {
                properties["currentRepeatStartAt"] = this.currentRepeatStartAt;
            }
            if (this.currentRepeatEndAt != null) {
                properties["currentRepeatEndAt"] = this.currentRepeatEndAt;
            }
            if (this.lastRepeatEndAt != null) {
                properties["lastRepeatEndAt"] = this.lastRepeatEndAt;
            }
            if (this.nextRepeatStartAt != null) {
                properties["nextRepeatStartAt"] = this.nextRepeatStartAt;
            }

            return properties;
        }
    }
}
