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
using Gs2Cdk.Gs2Money2.Model;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class CurrentMasterData : CdkResource {
        private string version= "2024-06-20";
        private string namespaceName;
        private StoreContentModel[] storeContentModels;
        private StoreSubscriptionContentModel[] storeSubscriptionContentModels;

        public CurrentMasterData(
            Stack stack,
            string namespaceName,
            StoreContentModel[] storeContentModels,
            StoreSubscriptionContentModel[] storeSubscriptionContentModels
        ): base(
            "Money2_CurrentModelMaster_" + namespaceName
        ){

            this.namespaceName = namespaceName;
            this.storeContentModels = storeContentModels;
            this.storeSubscriptionContentModels = storeSubscriptionContentModels;
            stack.AddResource(
                this
            );
        }

        public string AlternateKeys(
        ){
            return this.namespaceName;
        }

        public override string ResourceType(
        ){
            return "GS2::Money2::CurrentModelMaster";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();
            var settings = new Dictionary<string, object>();

            settings["version"] = this.version;
            if (this.storeContentModels != null) {
                settings["storeContentModels"] = this.storeContentModels.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.storeSubscriptionContentModels != null) {
                settings["storeSubscriptionContentModels"] = this.storeSubscriptionContentModels.Select(v => v?.Properties(
                        )).ToList();
            }

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (settings != null) {
                properties["Settings"] = settings;
            }

            return properties;
        }
    }
}