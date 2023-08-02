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
using Gs2Cdk.Gs2Mission.Model;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class CurrentMasterData : CdkResource {
        private string? version= "2019-05-28";
        private string? namespaceName;
        private MissionGroupModel[] groups;
        private CounterModel[] counters;

        public CurrentMasterData(
            Stack stack,
            string namespaceName,
            MissionGroupModel[] groups,
            CounterModel[] counters
        ): base(
            "Mission_CurrentMissionMaster_" + namespaceName
        ){

            this.namespaceName = namespaceName;
            this.groups = groups;
            this.counters = counters;
            stack.AddResource(
                this
            );
        }

        public string AlternateKeys(
        ){
            return this.namespaceName;
        }

        public override string ResourceType(
        ){
            return "GS2::Mission::CurrentMissionMaster";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();
            var settings = new Dictionary<string, object>();

            settings["version"] = this.version;
            if (this.groups != null) {
                settings["groups"] = this.groups.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.counters != null) {
                settings["counters"] = this.counters.Select(v => v.Properties(
                        )).ToList();
            }

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (settings != null) {
                properties["Settings"] = settings;
            }

            return properties;
        }
    }
}