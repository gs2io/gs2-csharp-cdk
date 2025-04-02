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
    public class AttributeRange {
        private string name;
        private int? min;
        private string minString;
        private int? max;
        private string maxString;

        public AttributeRange(
            string name,
            int? min,
            int? max,
            AttributeRangeOptions options = null
        ){
            this.name = name;
            this.min = min;
            this.max = max;
        }


        public AttributeRange(
            string name,
            string min,
            string max,
            AttributeRangeOptions options = null
        ){
            this.name = name;
            this.minString = min;
            this.maxString = max;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.minString != null) {
                properties["min"] = this.minString;
            } else {
                if (this.min != null) {
                    properties["min"] = this.min;
                }
            }
            if (this.maxString != null) {
                properties["max"] = this.maxString;
            } else {
                if (this.max != null) {
                    properties["max"] = this.max;
                }
            }

            return properties;
        }

        public static AttributeRange FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AttributeRange(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("min", out var min) ? new Func<int?>(() =>
                {
                    return min switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("max", out var max) ? new Func<int?>(() =>
                {
                    return max switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new AttributeRangeOptions {
                }
            );

            return model;
        }
    }
}
