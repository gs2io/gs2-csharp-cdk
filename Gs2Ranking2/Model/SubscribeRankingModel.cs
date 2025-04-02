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
using Gs2Cdk.Gs2Ranking2.Model;
using Gs2Cdk.Gs2Ranking2.Model.Enums;
using Gs2Cdk.Gs2Ranking2.Model.Options;

namespace Gs2Cdk.Gs2Ranking2.Model
{
    public class SubscribeRankingModel {
        private string name;
        private bool? sum;
        private string sumString;
        private SubscribeRankingModelOrderDirection? orderDirection;
        private string metadata;
        private long? minimumValue;
        private string minimumValueString;
        private long? maximumValue;
        private string maximumValueString;
        private string entryPeriodEventId;
        private string accessPeriodEventId;

        public SubscribeRankingModel(
            string name,
            bool? sum,
            SubscribeRankingModelOrderDirection orderDirection,
            SubscribeRankingModelOptions options = null
        ){
            this.name = name;
            this.sum = sum;
            this.orderDirection = orderDirection;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.maximumValue = options?.maximumValue;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.accessPeriodEventId = options?.accessPeriodEventId;
        }


        public SubscribeRankingModel(
            string name,
            string sum,
            SubscribeRankingModelOrderDirection orderDirection,
            SubscribeRankingModelOptions options = null
        ){
            this.name = name;
            this.sumString = sum;
            this.orderDirection = orderDirection;
            this.metadata = options?.metadata;
            this.minimumValue = options?.minimumValue;
            this.minimumValueString = options?.minimumValueString;
            this.maximumValue = options?.maximumValue;
            this.maximumValueString = options?.maximumValueString;
            this.entryPeriodEventId = options?.entryPeriodEventId;
            this.accessPeriodEventId = options?.accessPeriodEventId;
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
            if (this.minimumValueString != null) {
                properties["minimumValue"] = this.minimumValueString;
            } else {
                if (this.minimumValue != null) {
                    properties["minimumValue"] = this.minimumValue;
                }
            }
            if (this.maximumValueString != null) {
                properties["maximumValue"] = this.maximumValueString;
            } else {
                if (this.maximumValue != null) {
                    properties["maximumValue"] = this.maximumValue;
                }
            }
            if (this.sumString != null) {
                properties["sum"] = this.sumString;
            } else {
                if (this.sum != null) {
                    properties["sum"] = this.sum;
                }
            }
            if (this.orderDirection != null) {
                properties["orderDirection"] = this.orderDirection.Value.Str(
                );
            }
            if (this.entryPeriodEventId != null) {
                properties["entryPeriodEventId"] = this.entryPeriodEventId;
            }
            if (this.accessPeriodEventId != null) {
                properties["accessPeriodEventId"] = this.accessPeriodEventId;
            }

            return properties;
        }

        public static SubscribeRankingModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SubscribeRankingModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("sum", out var sum) ? new Func<bool?>(() =>
                {
                    return sum switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                properties.TryGetValue("orderDirection", out var orderDirection) ? new Func<SubscribeRankingModelOrderDirection>(() =>
                {
                    return orderDirection switch {
                        SubscribeRankingModelOrderDirection e => e,
                        string s => SubscribeRankingModelOrderDirectionExt.New(s),
                        _ => SubscribeRankingModelOrderDirection.Asc
                    };
                })() : default,
                new SubscribeRankingModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    minimumValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("minimumValue", out var minimumValue) ? minimumValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    maximumValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("maximumValue", out var maximumValue) ? maximumValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    entryPeriodEventId = properties.TryGetValue("entryPeriodEventId", out var entryPeriodEventId) ? (string)entryPeriodEventId : null,
                    accessPeriodEventId = properties.TryGetValue("accessPeriodEventId", out var accessPeriodEventId) ? (string)accessPeriodEventId : null
                }
            );

            return model;
        }
    }
}
