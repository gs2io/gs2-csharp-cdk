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
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Ref;

namespace Gs2Cdk.Gs2Account.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly bool? _changePasswordIfTakeOver;
        private readonly bool? _differentUserIdForLoginAndDataRetention;
        private readonly ScriptSetting _createAccountScript;
        private readonly ScriptSetting _authenticationScript;
        private readonly ScriptSetting _createTakeOverScript;
        private readonly ScriptSetting _doTakeOverScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                bool? changePasswordIfTakeOver,
                bool? differentUserIdForLoginAndDataRetention,
                string description = null,
                ScriptSetting createAccountScript = null,
                ScriptSetting authenticationScript = null,
                ScriptSetting createTakeOverScript = null,
                ScriptSetting doTakeOverScript = null,
                LogSetting logSetting = null
        ): base("Account_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._changePasswordIfTakeOver = changePasswordIfTakeOver;
            this._differentUserIdForLoginAndDataRetention = differentUserIdForLoginAndDataRetention;
            this._createAccountScript = createAccountScript;
            this._authenticationScript = authenticationScript;
            this._createTakeOverScript = createTakeOverScript;
            this._doTakeOverScript = doTakeOverScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Account::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._changePasswordIfTakeOver != null) {
                properties["ChangePasswordIfTakeOver"] = this._changePasswordIfTakeOver;
            }
            if (this._differentUserIdForLoginAndDataRetention != null) {
                properties["DifferentUserIdForLoginAndDataRetention"] = this._differentUserIdForLoginAndDataRetention;
            }
            if (this._createAccountScript != null) {
                properties["CreateAccountScript"] = this._createAccountScript.Properties();
            }
            if (this._authenticationScript != null) {
                properties["AuthenticationScript"] = this._authenticationScript.Properties();
            }
            if (this._createTakeOverScript != null) {
                properties["CreateTakeOverScript"] = this._createTakeOverScript.Properties();
            }
            if (this._doTakeOverScript != null) {
                properties["DoTakeOverScript"] = this._doTakeOverScript.Properties();
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
