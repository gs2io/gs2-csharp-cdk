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
    public class FormModel {
        private string name;
        private SlotModel[] slots;
        private string metadata;

        public FormModel(
            string name,
            SlotModel[] slots,
            FormModelOptions options = null
        ){
            this.name = name;
            this.slots = slots;
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
            if (this.slots != null) {
                properties["slots"] = this.slots.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static FormModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new FormModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("slots", out var slots) ? new Func<SlotModel[]>(() =>
                {
                    return slots switch {
                        Dictionary<string, object>[] v => v.Select(SlotModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ SlotModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(SlotModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as SlotModel).ToArray(),
                        { } v => new []{ v as SlotModel },
                        _ => null
                    };
                })() : null,
                new FormModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
