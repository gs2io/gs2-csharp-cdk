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
using Gs2Cdk.Gs2Money.Ref;
using Gs2Cdk.Gs2Money.Model;
using Gs2Cdk.Gs2Money.Model.Enums;
using Gs2Cdk.Gs2Money.Model.Options;

namespace Gs2Cdk.Gs2Money.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public NamespacePriority? priority;
        public bool shareFree;
        public NamespaceCurrency? currency;
        public string description;
        public TransactionSetting transactionSetting;
        public string appleKey;
        public string googleKey;
        public bool? enableFakeReceipt;
        public ScriptSetting createWalletScript;
        public ScriptSetting depositScript;
        public ScriptSetting withdrawScript;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespacePriority priority,
            bool shareFree,
            NamespaceCurrency currency,
            NamespaceOptions options = null
        ): base(
            "Money_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.priority = priority;
            this.shareFree = shareFree;
            this.currency = currency;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.appleKey = options?.appleKey;
            this.googleKey = options?.googleKey;
            this.enableFakeReceipt = options?.enableFakeReceipt;
            this.createWalletScript = options?.createWalletScript;
            this.depositScript = options?.depositScript;
            this.withdrawScript = options?.withdrawScript;
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
            return "GS2::Money::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.priority != null) {
                properties["Priority"] = this.priority.Value.Str(
                );
            }
            if (this.shareFree != null) {
                properties["ShareFree"] = this.shareFree;
            }
            if (this.currency != null) {
                properties["Currency"] = this.currency.Value.Str(
                );
            }
            if (this.appleKey != null) {
                properties["AppleKey"] = this.appleKey;
            }
            if (this.googleKey != null) {
                properties["GoogleKey"] = this.googleKey;
            }
            if (this.enableFakeReceipt != null) {
                properties["EnableFakeReceipt"] = this.enableFakeReceipt;
            }
            if (this.createWalletScript != null) {
                properties["CreateWalletScript"] = this.createWalletScript?.Properties(
                );
            }
            if (this.depositScript != null) {
                properties["DepositScript"] = this.depositScript?.Properties(
                );
            }
            if (this.withdrawScript != null) {
                properties["WithdrawScript"] = this.withdrawScript?.Properties(
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
    }
}
