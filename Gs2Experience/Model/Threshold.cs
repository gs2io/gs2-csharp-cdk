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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class Threshold {
        private long[] values;
        private string metadata;

        public Threshold(
            long[] values,
            ThresholdOptions options = null
        ){
            this.values = values;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.values != null) {
                properties["values"] = this.values;
            }

            return properties;
        }

        public static Threshold FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Threshold(
                new Func<long[]>(() =>
                {
                    return properties["values"] switch {
                        long[] v => v.ToArray(),
                        List<long> v => v.ToArray(),
                        object[] v => v.Select(v2 => long.Parse(v2?.ToString())).ToArray(),
                        { } v => new []{ long.Parse(v.ToString()) },
                        _ => null
                    };
                })(),
                new ThresholdOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
