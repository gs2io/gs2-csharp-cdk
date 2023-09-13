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
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.Model.Enums;
using Gs2Cdk.Gs2Enchant.Model.Options;

namespace Gs2Cdk.Gs2Enchant.Model
{
    public class BalanceParameterModel {
        private string name;
        private long totalValue;
        private BalanceParameterModelInitialValueStrategy? initialValueStrategy;
        private BalanceParameterValueModel[] parameters;
        private string metadata;

        public BalanceParameterModel(
            string name,
            long totalValue,
            BalanceParameterModelInitialValueStrategy initialValueStrategy,
            BalanceParameterValueModel[] parameters,
            BalanceParameterModelOptions options = null
        ){
            this.name = name;
            this.totalValue = totalValue;
            this.initialValueStrategy = initialValueStrategy;
            this.parameters = parameters;
            this.metadata = options?.metadata;
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
            if (this.totalValue != null) {
                properties["totalValue"] = this.totalValue;
            }
            if (this.initialValueStrategy != null) {
                properties["initialValueStrategy"] = this.initialValueStrategy?.Str(
                );
            }
            if (this.parameters != null) {
                properties["parameters"] = this.parameters.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static BalanceParameterModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BalanceParameterModel(
                (string)properties["name"],
                (long)properties["totalValue"],
                new Func<BalanceParameterModelInitialValueStrategy>(() =>
                {
                    return properties["initialValueStrategy"] switch {
                        BalanceParameterModelInitialValueStrategy e => e,
                        string s => BalanceParameterModelInitialValueStrategyExt.New(s),
                        _ => BalanceParameterModelInitialValueStrategy.Average
                    };
                })(),
                new Func<BalanceParameterValueModel[]>(() =>
                {
                    return properties["parameters"] switch {
                        Dictionary<string, object>[] v => v.Select(BalanceParameterValueModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(BalanceParameterValueModel.FromProperties).ToArray(),
                        _ => null
                    };
                })(),
                new BalanceParameterModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
