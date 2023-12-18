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
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class CounterModel {
        private string name;
        private CounterScopeModel[] scopes;
        private string metadata;
        private string challengePeriodEventId;

        public CounterModel(
            string name,
            CounterScopeModel[] scopes,
            CounterModelOptions options = null
        ){
            this.name = name;
            this.scopes = scopes;
            this.metadata = options?.metadata;
            this.challengePeriodEventId = options?.challengePeriodEventId;
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
            if (this.scopes != null) {
                properties["scopes"] = this.scopes.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.challengePeriodEventId != null) {
                properties["challengePeriodEventId"] = this.challengePeriodEventId;
            }

            return properties;
        }

        public static CounterModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CounterModel(
                (string)properties["name"],
                new Func<CounterScopeModel[]>(() =>
                {
                    return properties["scopes"] switch {
                        Dictionary<string, object>[] v => v.Select(CounterScopeModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ CounterScopeModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(CounterScopeModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as CounterScopeModel).ToArray(),
                        { } v => new []{ v as CounterScopeModel },
                        _ => null
                    };
                })(),
                new CounterModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    challengePeriodEventId = properties.TryGetValue("challengePeriodEventId", out var challengePeriodEventId) ? (string)challengePeriodEventId : null
                }
            );

            return model;
        }
    }
}
