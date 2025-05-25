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
using Gs2Cdk.Gs2Freeze.Ref;
using Gs2Cdk.Gs2Freeze.Model;
using Gs2Cdk.Gs2Freeze.Model.Enums;
using Gs2Cdk.Gs2Freeze.Model.Options;

namespace Gs2Cdk.Gs2Freeze.Model
{
    public class Stage : CdkResource {
        private Stack? stack;
        public string ownerId;
        public string name;
        public int sortNumber;
        public string sourceStageName;

        public Stage(
            Stack stack,
            string ownerId,
            string name,
            int sortNumber,
            StageOptions options = null
        ): base(
            "Freeze_Stage_" + name
        ){

            this.stack = stack;
            this.ownerId = ownerId;
            this.name = name;
            this.sortNumber = sortNumber;
            this.sourceStageName = options?.sourceStageName;
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
            return "GS2::Freeze::Stage";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.ownerId != null) {
                properties["OwnerId"] = this.ownerId;
            }
            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.sourceStageName != null) {
                properties["SourceStageName"] = this.sourceStageName;
            }
            if (this.sortNumber != null) {
                properties["SortNumber"] = this.sortNumber;
            }

            return properties;
        }

        public StageRef Ref(
        ){
            return (new StageRef(
                this.name
            ));
        }

        public GetAttr GetAttrStageId(
        ){
            return (new GetAttr(
                this,
                "Item.StageId",
                null
            ));
        }
    }
}
