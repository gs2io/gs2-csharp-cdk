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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.Model.Enums;
using Gs2Cdk.Gs2Limit.Model.Options;

namespace Gs2Cdk.Gs2Limit.Model
{
    public class LimitModel {
        private string name;
        private LimitModelResetType? resetType;
        private string metadata;
        private int? resetDayOfMonth;
        private LimitModelResetDayOfWeek? resetDayOfWeek;
        private int? resetHour;

        public LimitModel(
            string name,
            LimitModelResetType resetType,
            LimitModelOptions options = null
        ){
            this.name = name;
            this.resetType = resetType;
            this.metadata = options?.metadata;
            this.resetDayOfMonth = options?.resetDayOfMonth;
            this.resetDayOfWeek = options?.resetDayOfWeek;
            this.resetHour = options?.resetHour;
        }

        public static LimitModel ResetTypeIsNotReset(
            string name,
            LimitModelResetTypeIsNotResetOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.NotReset,
                new LimitModelOptions {
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsDaily(
            string name,
            int? resetHour,
            LimitModelResetTypeIsDailyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Daily,
                new LimitModelOptions {
                    resetHour = resetHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsWeekly(
            string name,
            LimitModelResetDayOfWeek resetDayOfWeek,
            int? resetHour,
            LimitModelResetTypeIsWeeklyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Weekly,
                new LimitModelOptions {
                    resetDayOfWeek = resetDayOfWeek,
                    resetHour = resetHour,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LimitModel ResetTypeIsMonthly(
            string name,
            int? resetDayOfMonth,
            int? resetHour,
            LimitModelResetTypeIsMonthlyOptions options = null
        ){
            return (new LimitModel(
                name,
                LimitModelResetType.Monthly,
                new LimitModelOptions {
                    resetDayOfMonth = resetDayOfMonth,
                    resetHour = resetHour,
                    metadata = options?.metadata,
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
            if (this.resetType != null) {
                properties["resetType"] = this.resetType?.Str(
                );
            }
            if (this.resetDayOfMonth != null) {
                properties["resetDayOfMonth"] = this.resetDayOfMonth;
            }
            if (this.resetDayOfWeek != null) {
                properties["resetDayOfWeek"] = this.resetDayOfWeek?.Str(
                );
            }
            if (this.resetHour != null) {
                properties["resetHour"] = this.resetHour;
            }

            return properties;
        }
    }
}
