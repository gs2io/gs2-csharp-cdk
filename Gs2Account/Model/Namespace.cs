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
using Gs2Cdk.Gs2Account.Ref;
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public bool? changePasswordIfTakeOver;
        public bool? differentUserIdForLoginAndDataRetention;
        public ScriptSetting createAccountScript;
        public ScriptSetting authenticationScript;
        public ScriptSetting createTakeOverScript;
        public ScriptSetting doTakeOverScript;
        public ScriptSetting banScript;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Account_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.changePasswordIfTakeOver = options?.changePasswordIfTakeOver;
            this.differentUserIdForLoginAndDataRetention = options?.differentUserIdForLoginAndDataRetention;
            this.createAccountScript = options?.createAccountScript;
            this.authenticationScript = options?.authenticationScript;
            this.createTakeOverScript = options?.createTakeOverScript;
            this.doTakeOverScript = options?.doTakeOverScript;
            this.banScript = options?.banScript;
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
            return "GS2::Account::Namespace";
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
            if (this.changePasswordIfTakeOver != null) {
                properties["ChangePasswordIfTakeOver"] = this.changePasswordIfTakeOver;
            }
            if (this.differentUserIdForLoginAndDataRetention != null) {
                properties["DifferentUserIdForLoginAndDataRetention"] = this.differentUserIdForLoginAndDataRetention;
            }
            if (this.createAccountScript != null) {
                properties["CreateAccountScript"] = this.createAccountScript?.Properties(
                );
            }
            if (this.authenticationScript != null) {
                properties["AuthenticationScript"] = this.authenticationScript?.Properties(
                );
            }
            if (this.createTakeOverScript != null) {
                properties["CreateTakeOverScript"] = this.createTakeOverScript?.Properties(
                );
            }
            if (this.doTakeOverScript != null) {
                properties["DoTakeOverScript"] = this.doTakeOverScript?.Properties(
                );
            }
            if (this.banScript != null) {
                properties["BanScript"] = this.banScript?.Properties(
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
            TakeOverTypeModel[] takeOverTypeModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                takeOverTypeModels
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
                new Func<TakeOverTypeModel[]>(() =>
                {
                    return properties["takeOverTypeModels"] switch {
                        TakeOverTypeModel[] v => v,
                        List<TakeOverTypeModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(TakeOverTypeModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(TakeOverTypeModel.FromProperties).ToArray(),
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
