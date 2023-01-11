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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Experience.Ref;
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        private string name;
        private string description;
        private string experienceCapScriptId;
        private ScriptSetting changeExperienceScript;
        private ScriptSetting changeRankScript;
        private ScriptSetting changeRankCapScript;
        private ScriptSetting overflowExperienceScript;
        private LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Experience_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.experienceCapScriptId = options?.experienceCapScriptId;
            this.changeExperienceScript = options?.changeExperienceScript;
            this.changeRankScript = options?.changeRankScript;
            this.changeRankCapScript = options?.changeRankCapScript;
            this.overflowExperienceScript = options?.overflowExperienceScript;
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
            return "GS2::Experience::Namespace";
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
            if (this.experienceCapScriptId != null) {
                properties["ExperienceCapScriptId"] = this.experienceCapScriptId;
            }
            if (this.changeExperienceScript != null) {
                properties["ChangeExperienceScript"] = this.changeExperienceScript?.Properties(
                );
            }
            if (this.changeRankScript != null) {
                properties["ChangeRankScript"] = this.changeRankScript?.Properties(
                );
            }
            if (this.changeRankCapScript != null) {
                properties["ChangeRankCapScript"] = this.changeRankCapScript?.Properties(
                );
            }
            if (this.overflowExperienceScript != null) {
                properties["OverflowExperienceScript"] = this.overflowExperienceScript?.Properties(
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
                null,
                null,
                "Item.NamespaceId"
            ));
        }

        public Namespace MasterData(
            ExperienceModel[] experienceModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                experienceModels
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
