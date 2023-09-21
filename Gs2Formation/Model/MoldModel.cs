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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.Model.Options;

namespace Gs2Cdk.Gs2Formation.Model
{
    public class MoldModel {
        private string name;
        private int initialMaxCapacity;
        private int maxCapacity;
        private FormModel formModel;
        private string metadata;

        public MoldModel(
            string name,
            int initialMaxCapacity,
            int maxCapacity,
            FormModel formModel,
            MoldModelOptions options = null
        ){
            this.name = name;
            this.initialMaxCapacity = initialMaxCapacity;
            this.maxCapacity = maxCapacity;
            this.formModel = formModel;
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
            if (this.initialMaxCapacity != null) {
                properties["initialMaxCapacity"] = this.initialMaxCapacity;
            }
            if (this.maxCapacity != null) {
                properties["maxCapacity"] = this.maxCapacity;
            }
            if (this.formModel != null) {
                properties["formModel"] = this.formModel?.Properties(
                );
            }

            return properties;
        }

        public static MoldModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MoldModel(
                (string)properties["name"],
                new Func<int>(() =>
                {
                    return properties["initialMaxCapacity"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["maxCapacity"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<FormModel>(() =>
                {
                    return properties["formModel"] switch {
                        FormModel v => v,
                        FormModel[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => FormModel.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? FormModel.FromProperties(v.First()) : null,
                        _ => null
                    };
                })(),
                new MoldModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
