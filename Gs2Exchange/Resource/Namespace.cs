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
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Ref;

namespace Gs2Cdk.Gs2Exchange.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly bool? _enableAwaitExchange;
        private readonly bool? _enableDirectExchange;
        private readonly TransactionSetting _transactionSetting;
        private readonly ScriptSetting _exchangeScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                bool? enableAwaitExchange,
                bool? enableDirectExchange,
                TransactionSetting transactionSetting,
                string description = null,
                ScriptSetting exchangeScript = null,
                LogSetting logSetting = null
        ): base("Exchange_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._enableAwaitExchange = enableAwaitExchange;
            this._enableDirectExchange = enableDirectExchange;
            this._transactionSetting = transactionSetting;
            this._exchangeScript = exchangeScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Exchange::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._enableAwaitExchange != null) {
                properties["EnableAwaitExchange"] = this._enableAwaitExchange;
            }
            if (this._enableDirectExchange != null) {
                properties["EnableDirectExchange"] = this._enableDirectExchange;
            }
            if (this._transactionSetting != null) {
                properties["TransactionSetting"] = this._transactionSetting.Properties();
            }
            if (this._exchangeScript != null) {
                properties["ExchangeScript"] = this._exchangeScript.Properties();
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

        public Namespace MasterData(
                RateModel[] rateModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                rateModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
