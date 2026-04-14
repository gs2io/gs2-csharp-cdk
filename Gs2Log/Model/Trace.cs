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
    public class Trace {
        private bool? truncated;
        private string truncatedString;
        private LogEntry[] spans;

        public Trace(
            bool? truncated,
            TraceOptions options = null
        ){
            this.truncated = truncated;
            this.spans = options?.spans;
        }


        public Trace(
            string truncated,
            TraceOptions options = null
        ){
            this.truncatedString = truncated;
            this.spans = options?.spans;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.spans != null) {
                properties["spans"] = this.spans.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.truncatedString != null) {
                properties["truncated"] = this.truncatedString;
            } else {
                if (this.truncated != null) {
                    properties["truncated"] = this.truncated;
                }
            }

            return properties;
        }

        public static Trace FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Trace(
                properties.TryGetValue("truncated", out var truncated) ? new Func<bool?>(() =>
                {
                    return truncated switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new TraceOptions {
                    spans = properties.TryGetValue("spans", out var spans) ? new Func<LogEntry[]>(() =>
                    {
                        return spans switch {
                            LogEntry[] v => v,
                            List<LogEntry> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(LogEntry.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(LogEntry.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
