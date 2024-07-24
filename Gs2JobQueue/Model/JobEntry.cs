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
using Gs2Cdk.Gs2JobQueue.Model;
using Gs2Cdk.Gs2JobQueue.Model.Options;

namespace Gs2Cdk.Gs2JobQueue.Model
{
    public class JobEntry {
        private string scriptId;
        private string args;
        private int? maxTryCount;
        private string maxTryCountString;

        public JobEntry(
            string scriptId,
            string args,
            int? maxTryCount,
            JobEntryOptions options = null
        ){
            this.scriptId = scriptId;
            this.args = args;
            this.maxTryCount = maxTryCount;
        }


        public JobEntry(
            string scriptId,
            string args,
            string maxTryCount,
            JobEntryOptions options = null
        ){
            this.scriptId = scriptId;
            this.args = args;
            this.maxTryCountString = maxTryCount;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.scriptId != null) {
                properties["scriptId"] = this.scriptId;
            }
            if (this.args != null) {
                properties["args"] = this.args;
            }
            if (this.maxTryCountString != null) {
                properties["maxTryCount"] = this.maxTryCountString;
            } else {
                if (this.maxTryCount != null) {
                    properties["maxTryCount"] = this.maxTryCount;
                }
            }

            return properties;
        }

        public static JobEntry FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new JobEntry(
                properties.TryGetValue("scriptId", out var scriptId) ? new Func<string>(() =>
                {
                    return (string) scriptId;
                })() : default,
                properties.TryGetValue("args", out var args) ? new Func<string>(() =>
                {
                    return (string) args;
                })() : default,
                properties.TryGetValue("maxTryCount", out var maxTryCount) ? new Func<int?>(() =>
                {
                    return maxTryCount switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new JobEntryOptions {
                }
            );

            return model;
        }
    }
}
