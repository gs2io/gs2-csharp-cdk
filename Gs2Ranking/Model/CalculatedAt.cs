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
    public class CalculatedAt {
        private string categoryName;
        private long calculatedAt;
        private string calculatedAtString;

        public CalculatedAt(
            string categoryName,
            long calculatedAt,
            CalculatedAtOptions options = null
        ){
            this.categoryName = categoryName;
            this.calculatedAt = calculatedAt;
        }


        public CalculatedAt(
            string categoryName,
            string calculatedAt,
            CalculatedAtOptions options = null
        ){
            this.categoryName = categoryName;
            this.calculatedAtString = calculatedAt;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.categoryName != null) {
                properties["categoryName"] = this.categoryName;
            }
            if (this.calculatedAtString != null) {
                properties["calculatedAt"] = this.calculatedAtString;
            } else {
                if (this.calculatedAt != null) {
                    properties["calculatedAt"] = this.calculatedAt;
                }
            }

            return properties;
        }

        public static CalculatedAt FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CalculatedAt(
                properties.TryGetValue("categoryName", out var categoryName) ? new Func<string>(() =>
                {
                    return (string) categoryName;
                })() : default,
                properties.TryGetValue("calculatedAt", out var calculatedAt) ? new Func<long>(() =>
                {
                    return calculatedAt switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new CalculatedAtOptions {
                }
            );

            return model;
        }
    }
}
