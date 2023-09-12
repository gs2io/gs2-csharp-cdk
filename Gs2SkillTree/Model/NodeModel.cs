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
using Gs2Cdk.Gs2SkillTree.Model;
using Gs2Cdk.Gs2SkillTree.Model.Options;

namespace Gs2Cdk.Gs2SkillTree.Model
{
    public class NodeModel {
        private string name;
        private ConsumeAction[] releaseConsumeActions;
        private float? restrainReturnRate;
        private string metadata;
        private AcquireAction[] returnAcquireActions;
        private string[] premiseNodeNames;

        public NodeModel(
            string name,
            ConsumeAction[] releaseConsumeActions,
            float? restrainReturnRate,
            NodeModelOptions options = null
        ){
            this.name = name;
            this.releaseConsumeActions = releaseConsumeActions;
            this.restrainReturnRate = restrainReturnRate;
            this.metadata = options?.metadata;
            this.returnAcquireActions = options?.returnAcquireActions;
            this.premiseNodeNames = options?.premiseNodeNames;
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
            if (this.releaseConsumeActions != null) {
                properties["releaseConsumeActions"] = this.releaseConsumeActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.restrainReturnRate != null) {
                properties["restrainReturnRate"] = this.restrainReturnRate;
            }
            if (this.premiseNodeNames != null) {
                properties["premiseNodeNames"] = this.premiseNodeNames;
            }

            return properties;
        }
    }
}
