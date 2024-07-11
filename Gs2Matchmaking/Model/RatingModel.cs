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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class RatingModel {
        private string name;
        private int? initialValue;
        private string initialValueString;
        private int? volatility;
        private string volatilityString;
        private string metadata;

        public RatingModel(
            string name,
            int? initialValue,
            int? volatility,
            RatingModelOptions options = null
        ){
            this.name = name;
            this.initialValue = initialValue;
            this.volatility = volatility;
            this.metadata = options?.metadata;
        }


        public RatingModel(
            string name,
            string initialValue,
            string volatility,
            RatingModelOptions options = null
        ){
            this.name = name;
            this.initialValueString = initialValue;
            this.volatilityString = volatility;
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
            if (this.initialValueString != null) {
                properties["initialValue"] = this.initialValueString;
            } else {
                if (this.initialValue != null) {
                    properties["initialValue"] = this.initialValue;
                }
            }
            if (this.volatilityString != null) {
                properties["volatility"] = this.volatilityString;
            } else {
                if (this.volatility != null) {
                    properties["volatility"] = this.volatility;
                }
            }

            return properties;
        }

        public static RatingModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RatingModel(
                (string)properties["name"],
                new Func<int?>(() =>
                {
                    return properties["initialValue"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int?>(() =>
                {
                    return properties["volatility"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new RatingModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
