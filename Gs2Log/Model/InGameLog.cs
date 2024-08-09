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
    public class InGameLog {
        private long timestamp;
        private string timestampString;
        private string requestId;
        private string payload;
        private string userId;
        private InGameLogTag[] tags;

        public InGameLog(
            long timestamp,
            string requestId,
            string payload,
            InGameLogOptions options = null
        ){
            this.timestamp = timestamp;
            this.requestId = requestId;
            this.payload = payload;
            this.userId = options?.userId;
            this.tags = options?.tags;
        }


        public InGameLog(
            string timestamp,
            string requestId,
            string payload,
            InGameLogOptions options = null
        ){
            this.timestampString = timestamp;
            this.requestId = requestId;
            this.payload = payload;
            this.userId = options?.userId;
            this.tags = options?.tags;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.timestampString != null) {
                properties["timestamp"] = this.timestampString;
            } else {
                if (this.timestamp != null) {
                    properties["timestamp"] = this.timestamp;
                }
            }
            if (this.requestId != null) {
                properties["requestId"] = this.requestId;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.tags != null) {
                properties["tags"] = this.tags.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.payload != null) {
                properties["payload"] = this.payload;
            }

            return properties;
        }

        public static InGameLog FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new InGameLog(
                properties.TryGetValue("timestamp", out var timestamp) ? new Func<long>(() =>
                {
                    return timestamp switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("requestId", out var requestId) ? new Func<string>(() =>
                {
                    return (string) requestId;
                })() : default,
                properties.TryGetValue("payload", out var payload) ? new Func<string>(() =>
                {
                    return (string) payload;
                })() : default,
                new InGameLogOptions {
                    userId = properties.TryGetValue("userId", out var userId) ? (string)userId : null,
                    tags = properties.TryGetValue("tags", out var tags) ? new Func<InGameLogTag[]>(() =>
                    {
                        return tags switch {
                            InGameLogTag[] v => v,
                            List<InGameLogTag> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(InGameLogTag.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(InGameLogTag.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
