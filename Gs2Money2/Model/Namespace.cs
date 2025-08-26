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
        public ScriptSetting depositBalanceScript;
        public ScriptSetting withdrawBalanceScript;
        public ScriptSetting verifyReceiptScript;
        public string subscribeScript;
        public string renewScript;
        public string unsubscribeScript;
        public ScriptSetting takeOverScript;
        public NotificationSetting changeSubscriptionStatusNotification;
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
            this.depositBalanceScript = options?.depositBalanceScript;
            this.withdrawBalanceScript = options?.withdrawBalanceScript;
            this.verifyReceiptScript = options?.verifyReceiptScript;
            this.subscribeScript = options?.subscribeScript;
            this.renewScript = options?.renewScript;
            this.unsubscribeScript = options?.unsubscribeScript;
            this.takeOverScript = options?.takeOverScript;
            this.changeSubscriptionStatusNotification = options?.changeSubscriptionStatusNotification;
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
            if (this.depositBalanceScript != null) {
                properties["DepositBalanceScript"] = this.depositBalanceScript?.Properties(
                );
            }
            if (this.withdrawBalanceScript != null) {
                properties["WithdrawBalanceScript"] = this.withdrawBalanceScript?.Properties(
                );
            }
            if (this.verifyReceiptScript != null) {
                properties["VerifyReceiptScript"] = this.verifyReceiptScript?.Properties(
                );
            }
            if (this.subscribeScript != null) {
                properties["SubscribeScript"] = this.subscribeScript;
            }
            if (this.renewScript != null) {
                properties["RenewScript"] = this.renewScript;
            }
            if (this.unsubscribeScript != null) {
                properties["UnsubscribeScript"] = this.unsubscribeScript;
            }
            if (this.takeOverScript != null) {
                properties["TakeOverScript"] = this.takeOverScript?.Properties(
                );
            }
            if (this.changeSubscriptionStatusNotification != null) {
                properties["ChangeSubscriptionStatusNotification"] = this.changeSubscriptionStatusNotification?.Properties(
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
            StoreContentModel[] storeContentModels,
            StoreSubscriptionContentModel[] storeSubscriptionContentModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                storeContentModels,
                storeSubscriptionContentModels
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
                })(),
                new Func<StoreSubscriptionContentModel[]>(() =>
                {
                    return properties["storeSubscriptionContentModels"] switch {
                        StoreSubscriptionContentModel[] v => v,
                        List<StoreSubscriptionContentModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(StoreSubscriptionContentModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(StoreSubscriptionContentModel.FromProperties).ToArray(),
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
