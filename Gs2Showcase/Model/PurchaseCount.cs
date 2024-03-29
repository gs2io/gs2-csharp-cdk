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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class PurchaseCount {
        private string name;
        private int count;

        public PurchaseCount(
            string name,
            int count,
            PurchaseCountOptions options = null
        ){
            this.name = name;
            this.count = count;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }

            return properties;
        }

        public static PurchaseCount FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new PurchaseCount(
                (string)properties["name"],
                new Func<int>(() =>
                {
                    return properties["count"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new PurchaseCountOptions {
                }
            );

            return model;
        }
    }
}
