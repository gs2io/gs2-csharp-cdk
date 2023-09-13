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
using Gs2Cdk.Gs2Distributor.Model;
using Gs2Cdk.Gs2Distributor.Model.Options;

namespace Gs2Cdk.Gs2Distributor.Model
{
    public class DistributeResource {
        private string action;
        private string request;

        public DistributeResource(
            string action,
            string request,
            DistributeResourceOptions options = null
        ){
            this.action = action;
            this.request = request;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.request != null) {
                properties["request"] = this.request;
            }

            return properties;
        }

        public static DistributeResource FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DistributeResource(
                (string)properties["action"],
                (string)properties["request"],
                new DistributeResourceOptions {
                }
            );

            return model;
        }
    }
}
