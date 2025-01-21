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
using Gs2Cdk.Gs2Distributor.Model;
using Gs2Cdk.Gs2Distributor.Model.Options;

namespace Gs2Cdk.Gs2Distributor.Model
{
    public class BatchResultPayload {
        private string requestId;
        private int statusCode;
        private string statusCodeString;
        private string resultPayload;

        public BatchResultPayload(
            string requestId,
            int statusCode,
            string resultPayload,
            BatchResultPayloadOptions options = null
        ){
            this.requestId = requestId;
            this.statusCode = statusCode;
            this.resultPayload = resultPayload;
        }


        public BatchResultPayload(
            string requestId,
            string statusCode,
            string resultPayload,
            BatchResultPayloadOptions options = null
        ){
            this.requestId = requestId;
            this.statusCodeString = statusCode;
            this.resultPayload = resultPayload;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.requestId != null) {
                properties["requestId"] = this.requestId;
            }
            if (this.statusCodeString != null) {
                properties["statusCode"] = this.statusCodeString;
            } else {
                if (this.statusCode != null) {
                    properties["statusCode"] = this.statusCode;
                }
            }
            if (this.resultPayload != null) {
                properties["resultPayload"] = this.resultPayload;
            }

            return properties;
        }

        public static BatchResultPayload FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BatchResultPayload(
                properties.TryGetValue("requestId", out var requestId) ? new Func<string>(() =>
                {
                    return (string) requestId;
                })() : default,
                properties.TryGetValue("statusCode", out var statusCode) ? new Func<int>(() =>
                {
                    return statusCode switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("resultPayload", out var resultPayload) ? new Func<string>(() =>
                {
                    return (string) resultPayload;
                })() : default,
                new BatchResultPayloadOptions {
                }
            );

            return model;
        }
    }
}
