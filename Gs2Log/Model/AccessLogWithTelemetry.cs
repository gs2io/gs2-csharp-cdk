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
using Gs2Cdk.Gs2Log.Model.Enums;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class AccessLogWithTelemetry {
        private long timestamp;
        private string timestampString;
        private string sourceRequestId;
        private string requestId;
        private long duration;
        private string durationString;
        private string service;
        private string method;
        private string request;
        private string result;
        private AccessLogWithTelemetryStatus? status;
        private string userId;

        public AccessLogWithTelemetry(
            long timestamp,
            string sourceRequestId,
            string requestId,
            long duration,
            string service,
            string method,
            string request,
            string result,
            AccessLogWithTelemetryStatus status,
            AccessLogWithTelemetryOptions options = null
        ){
            this.timestamp = timestamp;
            this.sourceRequestId = sourceRequestId;
            this.requestId = requestId;
            this.duration = duration;
            this.service = service;
            this.method = method;
            this.request = request;
            this.result = result;
            this.status = status;
            this.userId = options?.userId;
        }


        public AccessLogWithTelemetry(
            string timestamp,
            string sourceRequestId,
            string requestId,
            string duration,
            string service,
            string method,
            string request,
            string result,
            AccessLogWithTelemetryStatus status,
            AccessLogWithTelemetryOptions options = null
        ){
            this.timestampString = timestamp;
            this.sourceRequestId = sourceRequestId;
            this.requestId = requestId;
            this.durationString = duration;
            this.service = service;
            this.method = method;
            this.request = request;
            this.result = result;
            this.status = status;
            this.userId = options?.userId;
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
            if (this.sourceRequestId != null) {
                properties["sourceRequestId"] = this.sourceRequestId;
            }
            if (this.requestId != null) {
                properties["requestId"] = this.requestId;
            }
            if (this.durationString != null) {
                properties["duration"] = this.durationString;
            } else {
                if (this.duration != null) {
                    properties["duration"] = this.duration;
                }
            }
            if (this.service != null) {
                properties["service"] = this.service;
            }
            if (this.method != null) {
                properties["method"] = this.method;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.request != null) {
                properties["request"] = this.request;
            }
            if (this.result != null) {
                properties["result"] = this.result;
            }
            if (this.status != null) {
                properties["status"] = this.status.Value.Str(
                );
            }

            return properties;
        }

        public static AccessLogWithTelemetry FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AccessLogWithTelemetry(
                new Func<long>(() =>
                {
                    return properties["timestamp"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["sourceRequestId"],
                (string)properties["requestId"],
                new Func<long>(() =>
                {
                    return properties["duration"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["service"],
                (string)properties["method"],
                (string)properties["request"],
                (string)properties["result"],
                new Func<AccessLogWithTelemetryStatus>(() =>
                {
                    return properties["status"] switch {
                        AccessLogWithTelemetryStatus e => e,
                        string s => AccessLogWithTelemetryStatusExt.New(s),
                        _ => AccessLogWithTelemetryStatus.Ok
                    };
                })(),
                new AccessLogWithTelemetryOptions {
                    userId = properties.TryGetValue("userId", out var userId) ? (string)userId : null
                }
            );

            return model;
        }
    }
}
