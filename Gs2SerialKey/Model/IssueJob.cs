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
        private int? issueRequestCount;
        private IssueJobStatus? status;
        private long? createdAt;
        private string metadata;

        public IssueJob(
            string name,
            int? issuedCount,
            int? issueRequestCount,
            IssueJobStatus status,
            long? createdAt,
            IssueJobOptions options = null
        ){
            this.name = name;
            this.issuedCount = issuedCount;
            this.issueRequestCount = issueRequestCount;
            this.status = status;
            this.createdAt = createdAt;
            this.metadata = options?.metadata;
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
            if (this.issuedCount != null) {
                properties["issuedCount"] = this.issuedCount;
            }
            if (this.issueRequestCount != null) {
                properties["issueRequestCount"] = this.issueRequestCount;
            }
            if (this.status != null) {
                properties["status"] = this.status?.Str(
                );
            }
            if (this.createdAt != null) {
                properties["createdAt"] = this.createdAt;
            }

            return properties;
        }
    }
}
