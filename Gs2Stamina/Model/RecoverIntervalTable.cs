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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.Model.Options;

namespace Gs2Cdk.Gs2Stamina.Model
{
    public class RecoverIntervalTable {
        private string name;
        private string experienceModelId;
        private int[] values;
        private string metadata;

        public RecoverIntervalTable(
            string name,
            string experienceModelId,
            int[] values,
            RecoverIntervalTableOptions options = null
        ){
            this.name = name;
            this.experienceModelId = experienceModelId;
            this.values = values;
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
            if (this.experienceModelId != null) {
                properties["experienceModelId"] = this.experienceModelId;
            }
            if (this.values != null) {
                properties["values"] = this.values;
            }

            return properties;
        }
    }
}
