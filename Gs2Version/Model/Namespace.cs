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
using Gs2Cdk.Gs2Version.Ref;
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Model.Options;

namespace Gs2Cdk.Gs2Version.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string assumeUserId;
        public string description;
        public TransactionSetting transactionSetting;
        public ScriptSetting acceptVersionScript;
        public string checkVersionTriggerScriptId;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            string assumeUserId,
            NamespaceOptions options = null
        ): base(
            "Version_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.assumeUserId = assumeUserId;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.acceptVersionScript = options?.acceptVersionScript;
            this.checkVersionTriggerScriptId = options?.checkVersionTriggerScriptId;
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
            return "GS2::Version::Namespace";
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
            if (this.assumeUserId != null) {
                properties["AssumeUserId"] = this.assumeUserId;
            }
            if (this.acceptVersionScript != null) {
                properties["AcceptVersionScript"] = this.acceptVersionScript?.Properties(
                );
            }
            if (this.checkVersionTriggerScriptId != null) {
                properties["CheckVersionTriggerScriptId"] = this.checkVersionTriggerScriptId;
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
            VersionModel[] versionModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                versionModels
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
                new Func<VersionModel[]>(() =>
                {
                    return properties["versionModels"] switch {
                        VersionModel[] v => v,
                        List<VersionModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(VersionModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(VersionModel.FromProperties).ToArray(),
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
