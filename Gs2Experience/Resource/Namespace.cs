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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Ref;

namespace Gs2Cdk.Gs2Experience.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly string _experienceCapScriptId;
        private readonly ScriptSetting _changeExperienceScript;
        private readonly ScriptSetting _changeRankScript;
        private readonly ScriptSetting _changeRankCapScript;
        private readonly ScriptSetting _overflowExperienceScript;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string description = null,
                string experienceCapScriptId = null,
                ScriptSetting changeExperienceScript = null,
                ScriptSetting changeRankScript = null,
                ScriptSetting changeRankCapScript = null,
                ScriptSetting overflowExperienceScript = null,
                LogSetting logSetting = null
        ): base("Experience_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._experienceCapScriptId = experienceCapScriptId;
            this._changeExperienceScript = changeExperienceScript;
            this._changeRankScript = changeRankScript;
            this._changeRankCapScript = changeRankCapScript;
            this._overflowExperienceScript = overflowExperienceScript;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Experience::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._experienceCapScriptId != null) {
                properties["ExperienceCapScriptId"] = this._experienceCapScriptId;
            }
            if (this._changeExperienceScript != null) {
                properties["ChangeExperienceScript"] = this._changeExperienceScript.Properties();
            }
            if (this._changeRankScript != null) {
                properties["ChangeRankScript"] = this._changeRankScript.Properties();
            }
            if (this._changeRankCapScript != null) {
                properties["ChangeRankCapScript"] = this._changeRankCapScript.Properties();
            }
            if (this._overflowExperienceScript != null) {
                properties["OverflowExperienceScript"] = this._overflowExperienceScript.Properties();
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
                ExperienceModel[] experienceModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                experienceModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
