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
using Gs2Cdk.Gs2MegaField.Model;
using Gs2Cdk.Gs2MegaField.Model.Options;

namespace Gs2Cdk.Gs2MegaField.Model
{
    public class Scope {
        private string layerName;
        private float r;
        private int limit;

        public Scope(
            string layerName,
            float r,
            int limit,
            ScopeOptions options = null
        ){
            this.layerName = layerName;
            this.r = r;
            this.limit = limit;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.layerName != null) {
                properties["layerName"] = this.layerName;
            }
            if (this.r != null) {
                properties["r"] = this.r;
            }
            if (this.limit != null) {
                properties["limit"] = this.limit;
            }

            return properties;
        }

        public static Scope FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Scope(
                (string)properties["layerName"],
                (float)properties["r"],
                (int)properties["limit"],
                new ScopeOptions {
                }
            );

            return model;
        }
    }
}
