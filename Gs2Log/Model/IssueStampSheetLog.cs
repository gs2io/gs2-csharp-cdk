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
    public class IssueStampSheetLog {
        private long timestamp;
        private string transactionId;
        private string service;
        private string method;
        private string userId;
        private string action;
        private string args;
        private string[] tasks;

        public IssueStampSheetLog(
            long timestamp,
            string transactionId,
            string service,
            string method,
            string userId,
            string action,
            string args,
            IssueStampSheetLogOptions options = null
        ){
            this.timestamp = timestamp;
            this.transactionId = transactionId;
            this.service = service;
            this.method = method;
            this.userId = userId;
            this.action = action;
            this.args = args;
            this.tasks = options?.tasks;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.timestamp != null) {
                properties["timestamp"] = this.timestamp;
            }
            if (this.transactionId != null) {
                properties["transactionId"] = this.transactionId;
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
            if (this.tasks != null) {
                properties["tasks"] = this.tasks;
            }

            return properties;
        }

        public static IssueStampSheetLog FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new IssueStampSheetLog(
                new Func<long>(() =>
                {
                    return properties["timestamp"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["transactionId"],
                (string)properties["service"],
                (string)properties["method"],
                (string)properties["userId"],
                (string)properties["action"],
                (string)properties["args"],
                new IssueStampSheetLogOptions {
                    tasks = properties.TryGetValue("tasks", out var tasks) ? new Func<string[]>(() =>
                    {
                        return tasks switch {
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
