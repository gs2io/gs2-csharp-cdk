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
    public class LogEntry {
        private long timestamp;
        private string timestampString;
        private LogEntryStatus? status;
        private long? duration;
        private string durationString;
        private string line;
        private Label[] labels;

        public LogEntry(
            long timestamp,
            LogEntryStatus status,
            long? duration,
            string line,
            LogEntryOptions options = null
        ){
            this.timestamp = timestamp;
            this.status = status;
            this.duration = duration;
            this.line = line;
            this.labels = options?.labels;
        }


        public LogEntry(
            string timestamp,
            LogEntryStatus status,
            string duration,
            string line,
            LogEntryOptions options = null
        ){
            this.timestampString = timestamp;
            this.status = status;
            this.durationString = duration;
            this.line = line;
            this.labels = options?.labels;
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
            if (this.status != null) {
                properties["status"] = this.status.Value.Str(
                );
            }
            if (this.durationString != null) {
                properties["duration"] = this.durationString;
            } else {
                if (this.duration != null) {
                    properties["duration"] = this.duration;
                }
            }
            if (this.line != null) {
                properties["line"] = this.line;
            }
            if (this.labels != null) {
                properties["labels"] = this.labels.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static LogEntry FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new LogEntry(
                properties.TryGetValue("timestamp", out var timestamp) ? new Func<long>(() =>
                {
                    return timestamp switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("status", out var status) ? new Func<LogEntryStatus>(() =>
                {
                    return status switch {
                        LogEntryStatus e => e,
                        string s => LogEntryStatusExt.New(s),
                        _ => LogEntryStatus.Ok
                    };
                })() : default,
                properties.TryGetValue("duration", out var duration) ? new Func<long?>(() =>
                {
                    return duration switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("line", out var line) ? new Func<string>(() =>
                {
                    return (string) line;
                })() : default,
                new LogEntryOptions {
                    labels = properties.TryGetValue("labels", out var labels) ? new Func<Label[]>(() =>
                    {
                        return labels switch {
                            Label[] v => v,
                            List<Label> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(Label.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(Label.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
