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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.Model.Options;

namespace Gs2Cdk.Gs2Enchant.Model
{
    public class RarityParameterModel {
        private string name;
        private int? maximumParameterCount;
        private RarityParameterCountModel[] parameterCounts;
        private RarityParameterValueModel[] parameters;
        private string metadata;

        public RarityParameterModel(
            string name,
            int? maximumParameterCount,
            RarityParameterCountModel[] parameterCounts,
            RarityParameterValueModel[] parameters,
            RarityParameterModelOptions options = null
        ){
            this.name = name;
            this.maximumParameterCount = maximumParameterCount;
            this.parameterCounts = parameterCounts;
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
            if (this.maximumParameterCount != null) {
                properties["maximumParameterCount"] = this.maximumParameterCount;
            }
            if (this.parameterCounts != null) {
                properties["parameterCounts"] = this.parameterCounts.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.parameters != null) {
                properties["parameters"] = this.parameters.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }
    }
}
