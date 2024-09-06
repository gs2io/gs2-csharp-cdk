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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Money2.Ref;
using Gs2Cdk.Gs2Money2.Model;
using Gs2Cdk.Gs2Money2.Model.Enums;
using Gs2Cdk.Gs2Money2.Model.Options;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public NamespaceCurrencyUsagePriority? currencyUsagePriority;
        public bool sharedFreeCurrency;
        public PlatformSetting platformSetting;
        public string description;
        public ScriptSetting changeBalanceScript;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceCurrencyUsagePriority currencyUsagePriority,
            bool sharedFreeCurrency,
            PlatformSetting platformSetting,
            NamespaceOptions options = null
        ): base(
            "Money2_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.currencyUsagePriority = currencyUsagePriority;
            this.sharedFreeCurrency = sharedFreeCurrency;
            this.platformSetting = platformSetting;
            this.description = options?.description;
            this.changeBalanceScript = options?.changeBalanceScript;
            this.logSetting = options?.logSetting;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::Money2::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.currencyUsagePriority != null) {
                properties["CurrencyUsagePriority"] = this.currencyUsagePriority.Value.Str(
                );
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.sharedFreeCurrency != null) {
                properties["SharedFreeCurrency"] = this.sharedFreeCurrency;
            }
            if (this.platformSetting != null) {
                properties["PlatformSetting"] = this.platformSetting?.Properties(
                );
            }
            if (this.changeBalanceScript != null) {
                properties["ChangeBalanceScript"] = this.changeBalanceScript?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["LogSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public NamespaceRef Ref(
        ){
            return (new NamespaceRef(
                this.name
            ));
        }

        public GetAttr GetAttrNamespaceId(
        ){
            return (new GetAttr(
                this,
                "Item.NamespaceId",
                null
            ));
        }

        public Namespace MasterData(
            StoreContentModel[] storeContentModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                storeContentModels
            )).AddDependsOn(
                this
            );
            return this;
        }

        public Namespace MasterData(
            Dictionary<string, object> properties
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                new Func<StoreContentModel[]>(() =>
                {
                    return properties["storeContentModels"] switch {
                        StoreContentModel[] v => v,
                        List<StoreContentModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(StoreContentModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(StoreContentModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })()
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
