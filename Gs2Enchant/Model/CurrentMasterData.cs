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

namespace Gs2Cdk.Gs2Enchant.Model
{
    public class CurrentMasterData : CdkResource {
        private string? version= "2023-07-18";
        private string? namespaceName;
        private BalanceParameterModel[] balanceParameterModels;
        private RarityParameterModel[] rarityParameterModels;

        public CurrentMasterData(
            Stack stack,
            string namespaceName,
            BalanceParameterModel[] balanceParameterModels,
            RarityParameterModel[] rarityParameterModels
        ): base(
            "Enchant_CurrentParameterMaster_" + namespaceName
        ){

            this.namespaceName = namespaceName;
            this.balanceParameterModels = balanceParameterModels;
            this.rarityParameterModels = rarityParameterModels;
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
            return "GS2::Enchant::CurrentParameterMaster";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();
            var settings = new Dictionary<string, object>();

            settings["version"] = this.version;
            if (this.balanceParameterModels != null) {
                settings["balanceParameterModels"] = this.balanceParameterModels.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.rarityParameterModels != null) {
                settings["rarityParameterModels"] = this.rarityParameterModels.Select(v => v?.Properties(
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