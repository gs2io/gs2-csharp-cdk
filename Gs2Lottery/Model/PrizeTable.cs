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
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Model.Options;

namespace Gs2Cdk.Gs2Lottery.Model
{
    public class PrizeTable {
        private string name;
        private Prize[] prizes;
        private string metadata;

        public PrizeTable(
            string name,
            Prize[] prizes,
            PrizeTableOptions options = null
        ){
            this.name = name;
            this.prizes = prizes;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.prizes != null) {
                properties["prizes"] = this.prizes.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static PrizeTable FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new PrizeTable(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("prizes", out var prizes) ? new Func<Prize[]>(() =>
                {
                    return prizes switch {
                        Dictionary<string, object>[] v => v.Select(Prize.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ Prize.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(Prize.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as Prize).ToArray(),
                        { } v => new []{ v as Prize },
                        _ => null
                    };
                })() : null,
                new PrizeTableOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
