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
    public class TimeseriesMetadata {
        private string[] keys;
        private string[] groupBy;

        public TimeseriesMetadata(
            TimeseriesMetadataOptions options = null
        ){
            this.keys = options?.keys;
            this.groupBy = options?.groupBy;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.keys != null) {
                properties["keys"] = this.keys;
            }
            if (this.groupBy != null) {
                properties["groupBy"] = this.groupBy;
            }

            return properties;
        }

        public static TimeseriesMetadata FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TimeseriesMetadata(
                new TimeseriesMetadataOptions {
                    keys = properties.TryGetValue("keys", out var keys) ? new Func<string[]>(() =>
                    {
                        return keys switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    groupBy = properties.TryGetValue("groupBy", out var groupBy) ? new Func<string[]>(() =>
                    {
                        return groupBy switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
