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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.Ref;

namespace Gs2Cdk.Gs2Formation.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly TransactionSetting _transactionSetting;
        private readonly ScriptSetting _updateMoldScript;
        private readonly ScriptSetting _updateFormScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string description = null,
                TransactionSetting transactionSetting = null,
                ScriptSetting updateMoldScript = null,
                ScriptSetting updateFormScript = null,
                LogSetting logSetting = null
        ): base("Formation_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._transactionSetting = transactionSetting;
            this._updateMoldScript = updateMoldScript;
            this._updateFormScript = updateFormScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Formation::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._transactionSetting != null) {
                properties["TransactionSetting"] = this._transactionSetting.Properties();
            }
            if (this._updateMoldScript != null) {
                properties["UpdateMoldScript"] = this._updateMoldScript.Properties();
            }
            if (this._updateFormScript != null) {
                properties["UpdateFormScript"] = this._updateFormScript.Properties();
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
                MoldModel[] moldModels,
                FormModel[] formModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                moldModels,
                formModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
