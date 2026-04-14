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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Log.Ref;
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class Dashboard : CdkResource {
        private Stack? stack;
        public string namespaceName;
        public string displayName;
        public string description;

        public Dashboard(
            Stack stack,
            string namespaceName,
            string displayName,
            DashboardOptions options = null
        ): base(
            "Log_Dashboard_" + displayName
        ){

            this.stack = stack;
            this.namespaceName = namespaceName;
            this.displayName = displayName;
            this.description = options?.description;
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
            return "GS2::Log::Dashboard";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (this.displayName != null) {
                properties["DisplayName"] = this.displayName;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }

            return properties;
        }

        public DashboardRef Ref(
            string name
        ){
            return (new DashboardRef(
                this.namespaceName,
                name
            ));
        }

        public GetAttr GetAttrDashboardId(
        ){
            return (new GetAttr(
                this,
                "Item.DashboardId",
                null
            ));
        }
    }
}
