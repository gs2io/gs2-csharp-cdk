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
using Gs2Cdk.Gs2Ranking.Model;
using Gs2Cdk.Gs2Ranking.Model.Options;

namespace Gs2Cdk.Gs2Ranking.Model
{
    public class Scope {
        private string name;
        private long targetDays;

        public Scope(
            string name,
            long targetDays,
            ScopeOptions options = null
        ){
            this.name = name;
            this.targetDays = targetDays;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.targetDays != null) {
                properties["targetDays"] = this.targetDays;
            }

            return properties;
        }

        public static Scope FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Scope(
                (string)properties["name"],
                new Func<long>(() =>
                {
                    return properties["targetDays"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new ScopeOptions {
                }
            );

            return model;
        }
    }
}
