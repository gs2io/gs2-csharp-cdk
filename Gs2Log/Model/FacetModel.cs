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
using Gs2Cdk.Gs2Log.Ref;
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Enums;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class FacetModel : CdkResource {
        private Stack? stack;
        public string namespaceName;
        public string field;
        public FacetModelType? type;
        public string displayName;
        public int? order;

        public FacetModel(
            Stack stack,
            string namespaceName,
            string field,
            FacetModelType type,
            string displayName,
            FacetModelOptions options = null
        ): base(
            "Log_FacetModel_" + field
        ){

            this.stack = stack;
            this.namespaceName = namespaceName;
            this.field = field;
            this.type = type;
            this.displayName = displayName;
            this.order = options?.order;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "field";
        }

        public override string ResourceType(
        ){
            return "GS2::Log::FacetModel";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (this.field != null) {
                properties["Field"] = this.field;
            }
            if (this.type != null) {
                properties["Type"] = this.type.Value.Str(
                );
            }
            if (this.displayName != null) {
                properties["DisplayName"] = this.displayName;
            }
            if (this.order != null) {
                properties["Order"] = this.order;
            }

            return properties;
        }

        public FacetModelRef Ref(
        ){
            return (new FacetModelRef(
                this.namespaceName,
                this.field
            ));
        }

        public GetAttr GetAttrFacetModelId(
        ){
            return (new GetAttr(
                this,
                "Item.FacetModelId",
                null
            ));
        }
    }
}
