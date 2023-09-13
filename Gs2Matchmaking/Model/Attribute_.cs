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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class Attribute_ {
        private string name;
        private int? value;

        public Attribute_(
            string name,
            int? value,
            AttributeOptions options = null
        ){
            this.name = name;
            this.value = value;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.value != null) {
                properties["value"] = this.value;
            }

            return properties;
        }

        public static Attribute_ FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Attribute_(
                (string)properties["name"],
                new Func<int?>(() =>
                {
                    return properties["value"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new AttributeOptions {
                }
            );

            return model;
        }
    }
}
