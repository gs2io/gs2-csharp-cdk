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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.Model.Enums;
using Gs2Cdk.Gs2SerialKey.Model.Options;

namespace Gs2Cdk.Gs2SerialKey.Model
{
    public class IssueJob {
        private string name;
        private int? issuedCount;
        private string issuedCountString;
        private int issueRequestCount;
        private string issueRequestCountString;
        private IssueJobStatus? status;
        private string metadata;
        private long? revision;
        private string revisionString;

        public IssueJob(
            string name,
            int? issuedCount,
            int issueRequestCount,
            IssueJobStatus status,
            IssueJobOptions options = null
        ){
            this.name = name;
            this.issuedCount = issuedCount;
            this.issueRequestCount = issueRequestCount;
            this.status = status;
            this.metadata = options?.metadata;
            this.revision = options?.revision;
        }


        public IssueJob(
            string name,
            string issuedCount,
            string issueRequestCount,
            IssueJobStatus status,
            IssueJobOptions options = null
        ){
            this.name = name;
            this.issuedCountString = issuedCount;
            this.issueRequestCountString = issueRequestCount;
            this.status = status;
            this.metadata = options?.metadata;
            this.revision = options?.revision;
            this.revisionString = options?.revisionString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.issuedCountString != null) {
                properties["issuedCount"] = this.issuedCountString;
            } else {
                if (this.issuedCount != null) {
                    properties["issuedCount"] = this.issuedCount;
                }
            }
            if (this.issueRequestCountString != null) {
                properties["issueRequestCount"] = this.issueRequestCountString;
            } else {
                if (this.issueRequestCount != null) {
                    properties["issueRequestCount"] = this.issueRequestCount;
                }
            }
            if (this.status != null) {
                properties["status"] = this.status.Value.Str(
                );
            }

            return properties;
        }

        public static IssueJob FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new IssueJob(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("issuedCount", out var issuedCount) ? new Func<int?>(() =>
                {
                    return issuedCount switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("issueRequestCount", out var issueRequestCount) ? new Func<int>(() =>
                {
                    return issueRequestCount switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("status", out var status) ? new Func<IssueJobStatus>(() =>
                {
                    return status switch {
                        IssueJobStatus e => e,
                        string s => IssueJobStatusExt.New(s),
                        _ => IssueJobStatus.Processing
                    };
                })() : default,
                new IssueJobOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
