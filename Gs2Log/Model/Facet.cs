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
    public class Facet {
        private string field;
        private FacetValueCount[] values;
        private NumericRange range;
        private NumericRange globalRange;

        public Facet(
            string field,
            FacetOptions options = null
        ){
            this.field = field;
            this.values = options?.values;
            this.range = options?.range;
            this.globalRange = options?.globalRange;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.field != null) {
                properties["field"] = this.field;
            }
            if (this.values != null) {
                properties["values"] = this.values.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.range != null) {
                properties["range"] = this.range?.Properties(
                );
            }
            if (this.globalRange != null) {
                properties["globalRange"] = this.globalRange?.Properties(
                );
            }

            return properties;
        }

        public static Facet FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Facet(
                properties.TryGetValue("field", out var field) ? new Func<string>(() =>
                {
                    return (string) field;
                })() : default,
                new FacetOptions {
                    values = properties.TryGetValue("values", out var values) ? new Func<FacetValueCount[]>(() =>
                    {
                        return values switch {
                            FacetValueCount[] v => v,
                            List<FacetValueCount> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(FacetValueCount.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(FacetValueCount.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    range = properties.TryGetValue("range", out var range) ? new Func<NumericRange>(() =>
                    {
                        return range switch {
                            NumericRange v => v,
                            Dictionary<string, object> v => NumericRange.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    globalRange = properties.TryGetValue("globalRange", out var globalRange) ? new Func<NumericRange>(() =>
                    {
                        return globalRange switch {
                            NumericRange v => v,
                            Dictionary<string, object> v => NumericRange.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
