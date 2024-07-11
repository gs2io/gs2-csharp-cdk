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
    public class AccessLogCount {
        private long count;
        private string countString;
        private string service;
        private string method;
        private string userId;

        public AccessLogCount(
            long count,
            AccessLogCountOptions options = null
        ){
            this.count = count;
            this.service = options?.service;
            this.method = options?.method;
            this.userId = options?.userId;
        }


        public AccessLogCount(
            string count,
            AccessLogCountOptions options = null
        ){
            this.countString = count;
            this.service = options?.service;
            this.method = options?.method;
            this.userId = options?.userId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.service != null) {
                properties["service"] = this.service;
            }
            if (this.method != null) {
                properties["method"] = this.method;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
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

        public static AccessLogCount FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AccessLogCount(
                new Func<long>(() =>
                {
                    return properties["count"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new AccessLogCountOptions {
                    service = properties.TryGetValue("service", out var service) ? (string)service : null,
                    method = properties.TryGetValue("method", out var method) ? (string)method : null,
                    userId = properties.TryGetValue("userId", out var userId) ? (string)userId : null
                }
            );

            return model;
        }
    }
}
