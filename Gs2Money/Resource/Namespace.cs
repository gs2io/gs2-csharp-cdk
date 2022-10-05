/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Money.Model;
using Gs2Cdk.Gs2Money.Ref;

namespace Gs2Cdk.Gs2Money.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly string _priority;
        private readonly bool? _shareFree;
        private readonly string _currency;
        private readonly string _appleKey;
        private readonly string _googleKey;
        private readonly bool? _enableFakeReceipt;
        private readonly ScriptSetting _createWalletScript;
        private readonly ScriptSetting _depositScript;
        private readonly ScriptSetting _withdrawScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string priority,
                bool? shareFree,
                string currency,
                bool? enableFakeReceipt,
                string description = null,
                string appleKey = null,
                string googleKey = null,
                ScriptSetting createWalletScript = null,
                ScriptSetting depositScript = null,
                ScriptSetting withdrawScript = null,
                LogSetting logSetting = null
        ): base("Money_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._priority = priority;
            this._shareFree = shareFree;
            this._currency = currency;
            this._appleKey = appleKey;
            this._googleKey = googleKey;
            this._enableFakeReceipt = enableFakeReceipt;
            this._createWalletScript = createWalletScript;
            this._depositScript = depositScript;
            this._withdrawScript = withdrawScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Money::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._priority != null) {
                properties["Priority"] = this._priority.ToString();
            }
            if (this._shareFree != null) {
                properties["ShareFree"] = this._shareFree;
            }
            if (this._currency != null) {
                properties["Currency"] = this._currency.ToString();
            }
            if (this._appleKey != null) {
                properties["AppleKey"] = this._appleKey;
            }
            if (this._googleKey != null) {
                properties["GoogleKey"] = this._googleKey;
            }
            if (this._enableFakeReceipt != null) {
                properties["EnableFakeReceipt"] = this._enableFakeReceipt;
            }
            if (this._createWalletScript != null) {
                properties["CreateWalletScript"] = this._createWalletScript.Properties();
            }
            if (this._depositScript != null) {
                properties["DepositScript"] = this._depositScript.Properties();
            }
            if (this._withdrawScript != null) {
                properties["WithdrawScript"] = this._withdrawScript.Properties();
            }
            if (this._logSetting != null) {
                properties["LogSetting"] = this._logSetting.Properties();
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }
    }
}
