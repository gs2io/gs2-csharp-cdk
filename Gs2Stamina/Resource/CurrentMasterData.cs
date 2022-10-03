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
using Gs2Cdk.Gs2Stamina.Model;

namespace Gs2Cdk.Gs2Stamina.Resource
{
    public class CurrentMasterData : CdkResource
    {
        private readonly string _version = "2019-02-14";
        private readonly string _namespaceName;
        private readonly StaminaModel[] _staminaModels;

        public CurrentMasterData(
                Stack stack,
                string namespaceName,
                StaminaModel[] staminaModels
        ): base("Stamina_CurrentStaminaMaster_" + namespaceName) {
            this._namespaceName = namespaceName;
            this._staminaModels = staminaModels;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Stamina::CurrentStaminaMaster";
        }

        public override Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"NamespaceName", this._namespaceName},
                {"Settings", new Dictionary<string, object>() {
                    {"version", this._version},
                    {"staminaModels", this._staminaModels.Select(v => v.Properties()).ToArray()},
                }},
            };
        }
    }
}