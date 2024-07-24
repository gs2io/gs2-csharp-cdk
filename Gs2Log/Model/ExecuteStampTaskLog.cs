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
    public class ExecuteStampTaskLog {
        private long timestamp;
        private string timestampString;
        private string taskId;
        private string service;
        private string method;
        private string userId;
        private string action;
        private string args;

        public ExecuteStampTaskLog(
            long timestamp,
            string taskId,
            string service,
            string method,
            string userId,
            string action,
            string args,
            ExecuteStampTaskLogOptions options = null
        ){
            this.timestamp = timestamp;
            this.taskId = taskId;
            this.service = service;
            this.method = method;
            this.userId = userId;
            this.action = action;
            this.args = args;
        }


        public ExecuteStampTaskLog(
            string timestamp,
            string taskId,
            string service,
            string method,
            string userId,
            string action,
            string args,
            ExecuteStampTaskLogOptions options = null
        ){
            this.timestampString = timestamp;
            this.taskId = taskId;
            this.service = service;
            this.method = method;
            this.userId = userId;
            this.action = action;
            this.args = args;
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
            if (this.taskId != null) {
                properties["taskId"] = this.taskId;
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
            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.args != null) {
                properties["args"] = this.args;
            }

            return properties;
        }

        public static ExecuteStampTaskLog FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ExecuteStampTaskLog(
                properties.TryGetValue("timestamp", out var timestamp) ? new Func<long>(() =>
                {
                    return timestamp switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("taskId", out var taskId) ? new Func<string>(() =>
                {
                    return (string) taskId;
                })() : default,
                properties.TryGetValue("service", out var service) ? new Func<string>(() =>
                {
                    return (string) service;
                })() : default,
                properties.TryGetValue("method", out var method) ? new Func<string>(() =>
                {
                    return (string) method;
                })() : default,
                properties.TryGetValue("userId", out var userId) ? new Func<string>(() =>
                {
                    return (string) userId;
                })() : default,
                properties.TryGetValue("action", out var action) ? new Func<string>(() =>
                {
                    return (string) action;
                })() : default,
                properties.TryGetValue("args", out var args) ? new Func<string>(() =>
                {
                    return (string) args;
                })() : default,
                new ExecuteStampTaskLogOptions {
                }
            );

            return model;
        }
    }
}
