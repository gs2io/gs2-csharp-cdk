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
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Enums;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class MetricModel {
        private string name;
        private MetricModelType? type;
        private string[] labels;

        public MetricModel(
            string name,
            MetricModelType type,
            MetricModelOptions options = null
        ){
            this.name = name;
            this.type = type;
            this.labels = options?.labels;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.type != null) {
                properties["type"] = this.type.Value.Str(
                );
            }
            if (this.labels != null) {
                properties["labels"] = this.labels;
            }

            return properties;
        }

        public static MetricModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MetricModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("type", out var type) ? new Func<MetricModelType>(() =>
                {
                    return type switch {
                        MetricModelType e => e,
                        string s => MetricModelTypeExt.New(s),
                        _ => MetricModelType.String
                    };
                })() : default,
                new MetricModelOptions {
                    labels = properties.TryGetValue("labels", out var labels) ? new Func<string[]>(() =>
                    {
                        return labels switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
