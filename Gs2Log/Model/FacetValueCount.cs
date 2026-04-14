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
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class FacetValueCount {
        private string value;
        private long count;
        private string countString;

        public FacetValueCount(
            string value,
            long count,
            FacetValueCountOptions options = null
        ){
            this.value = value;
            this.count = count;
        }


        public FacetValueCount(
            string value,
            string count,
            FacetValueCountOptions options = null
        ){
            this.value = value;
            this.countString = count;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.value != null) {
                properties["value"] = this.value;
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

        public static FacetValueCount FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new FacetValueCount(
                properties.TryGetValue("value", out var value) ? new Func<string>(() =>
                {
                    return (string) value;
                })() : default,
                properties.TryGetValue("count", out var count) ? new Func<long>(() =>
                {
                    return count switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new FacetValueCountOptions {
                }
            );

            return model;
        }
    }
}
