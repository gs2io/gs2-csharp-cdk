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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class RandomShowcase {
        private string name;
        private int maximumNumberOfChoice;
        private RandomDisplayItemModel[] displayItems;
        private long baseTimestamp;
        private int resetIntervalHours;
        private string metadata;
        private string salesPeriodEventId;

        public RandomShowcase(
            string name,
            int maximumNumberOfChoice,
            RandomDisplayItemModel[] displayItems,
            long baseTimestamp,
            int resetIntervalHours,
            RandomShowcaseOptions options = null
        ){
            this.name = name;
            this.maximumNumberOfChoice = maximumNumberOfChoice;
            this.displayItems = displayItems;
            this.baseTimestamp = baseTimestamp;
            this.resetIntervalHours = resetIntervalHours;
            this.metadata = options?.metadata;
            this.salesPeriodEventId = options?.salesPeriodEventId;
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
            if (this.maximumNumberOfChoice != null) {
                properties["maximumNumberOfChoice"] = this.maximumNumberOfChoice;
            }
            if (this.displayItems != null) {
                properties["displayItems"] = this.displayItems.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.baseTimestamp != null) {
                properties["baseTimestamp"] = this.baseTimestamp;
            }
            if (this.resetIntervalHours != null) {
                properties["resetIntervalHours"] = this.resetIntervalHours;
            }
            if (this.salesPeriodEventId != null) {
                properties["salesPeriodEventId"] = this.salesPeriodEventId;
            }

            return properties;
        }

        public static RandomShowcase FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RandomShowcase(
                (string)properties["name"],
                (int)properties["maximumNumberOfChoice"],
                new Func<RandomDisplayItemModel[]>(() =>
                {
                    return properties["displayItems"] switch {
                        Dictionary<string, object>[] v => v.Select(RandomDisplayItemModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(RandomDisplayItemModel.FromProperties).ToArray(),
                        _ => null
                    };
                })(),
                (long)properties["baseTimestamp"],
                (int)properties["resetIntervalHours"],
                new RandomShowcaseOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    salesPeriodEventId = properties.TryGetValue("salesPeriodEventId", out var salesPeriodEventId) ? (string)salesPeriodEventId : null
                }
            );

            return model;
        }
    }
}
