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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.Model.Options;

namespace Gs2Cdk.Gs2SerialKey.Model
{
    public class CampaignModel {
        private string name;
        private bool? enableCampaignCode;
        private string metadata;

        public CampaignModel(
            string name,
            bool? enableCampaignCode,
            CampaignModelOptions options = null
        ){
            this.name = name;
            this.enableCampaignCode = enableCampaignCode;
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
            if (this.enableCampaignCode != null) {
                properties["enableCampaignCode"] = this.enableCampaignCode;
            }

            return properties;
        }

        public static CampaignModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CampaignModel(
                (string)properties["name"],
                new Func<bool?>(() =>
                {
                    return properties["enableCampaignCode"] switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })(),
                new CampaignModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
