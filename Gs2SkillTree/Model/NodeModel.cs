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
using Gs2Cdk.Gs2SkillTree.Model;
using Gs2Cdk.Gs2SkillTree.Model.Options;

namespace Gs2Cdk.Gs2SkillTree.Model
{
    public class NodeModel {
        private string name;
        private ConsumeAction[] releaseConsumeActions;
        private float? restrainReturnRate;
        private string restrainReturnRateString;
        private string metadata;
        private VerifyAction[] releaseVerifyActions;
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
            this.releaseVerifyActions = options?.releaseVerifyActions;
            this.returnAcquireActions = options?.returnAcquireActions;
            this.premiseNodeNames = options?.premiseNodeNames;
        }


        public NodeModel(
            string name,
            ConsumeAction[] releaseConsumeActions,
            string restrainReturnRate,
            NodeModelOptions options = null
        ){
            this.name = name;
            this.releaseConsumeActions = releaseConsumeActions;
            this.restrainReturnRateString = restrainReturnRate;
            this.metadata = options?.metadata;
            this.releaseVerifyActions = options?.releaseVerifyActions;
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
            if (this.releaseVerifyActions != null) {
                properties["releaseVerifyActions"] = this.releaseVerifyActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.releaseConsumeActions != null) {
                properties["releaseConsumeActions"] = this.releaseConsumeActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.restrainReturnRateString != null) {
                properties["restrainReturnRate"] = this.restrainReturnRateString;
            } else {
                if (this.restrainReturnRate != null) {
                    properties["restrainReturnRate"] = this.restrainReturnRate;
                }
            }
            if (this.premiseNodeNames != null) {
                properties["premiseNodeNames"] = this.premiseNodeNames;
            }

            return properties;
        }

        public static NodeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new NodeModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("releaseConsumeActions", out var releaseConsumeActions) ? new Func<ConsumeAction[]>(() =>
                {
                    return releaseConsumeActions switch {
                        Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ ConsumeAction.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as ConsumeAction).ToArray(),
                        { } v => new []{ v as ConsumeAction },
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("restrainReturnRate", out var restrainReturnRate) ? new Func<float?>(() =>
                {
                    return restrainReturnRate switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })() : default,
                new NodeModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    releaseVerifyActions = properties.TryGetValue("releaseVerifyActions", out var releaseVerifyActions) ? new Func<VerifyAction[]>(() =>
                    {
                        return releaseVerifyActions switch {
                            VerifyAction[] v => v,
                            List<VerifyAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(VerifyAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(VerifyAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    returnAcquireActions = properties.TryGetValue("returnAcquireActions", out var returnAcquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return returnAcquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    premiseNodeNames = properties.TryGetValue("premiseNodeNames", out var premiseNodeNames) ? new Func<string[]>(() =>
                    {
                        return premiseNodeNames switch {
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
