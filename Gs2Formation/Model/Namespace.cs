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
using Gs2Cdk.Gs2Formation.Ref;
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.Model.Options;

namespace Gs2Cdk.Gs2Formation.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        private string name;
        private string description;
        private TransactionSetting transactionSetting;
        private ScriptSetting updateMoldScript;
        private ScriptSetting updateFormScript;
        private ScriptSetting updatePropertyFormScript;
        private LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Formation_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.updateMoldScript = options?.updateMoldScript;
            this.updateFormScript = options?.updateFormScript;
            this.updatePropertyFormScript = options?.updatePropertyFormScript;
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
            return "GS2::Formation::Namespace";
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
            if (this.updateMoldScript != null) {
                properties["UpdateMoldScript"] = this.updateMoldScript?.Properties(
                );
            }
            if (this.updateFormScript != null) {
                properties["UpdateFormScript"] = this.updateFormScript?.Properties(
                );
            }
            if (this.updatePropertyFormScript != null) {
                properties["UpdatePropertyFormScript"] = this.updatePropertyFormScript?.Properties(
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
            MoldModel[] moldModels,
            PropertyFormModel[] propertyFormModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                moldModels,
                propertyFormModels
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
                new Func<MoldModel[]>(() =>
                {
                    return properties["moldModels"] switch {
                        MoldModel[] v => v,
                        List<MoldModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(MoldModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(MoldModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<PropertyFormModel[]>(() =>
                {
                    return properties["propertyFormModels"] switch {
                        PropertyFormModel[] v => v,
                        List<PropertyFormModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(PropertyFormModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(PropertyFormModel.FromProperties).ToArray(),
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
