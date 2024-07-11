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
using Gs2Cdk.Gs2Enhance.Model;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class Material {
        private string materialItemSetId;
        private int? count;
        private string countString;

        public Material(
            string materialItemSetId,
            int? count,
            MaterialOptions options = null
        ){
            this.materialItemSetId = materialItemSetId;
            this.count = count;
        }


        public Material(
            string materialItemSetId,
            string count,
            MaterialOptions options = null
        ){
            this.materialItemSetId = materialItemSetId;
            this.countString = count;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.materialItemSetId != null) {
                properties["materialItemSetId"] = this.materialItemSetId;
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }

            return properties;
        }

        public static Material FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Material(
                (string)properties["materialItemSetId"],
                new Func<int?>(() =>
                {
                    return properties["count"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new MaterialOptions {
                }
            );

            return model;
        }
    }
}
