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
using Gs2Cdk.Gs2Distributor.Model.Enums;
using Gs2Cdk.Gs2Distributor.Model.Options;

namespace Gs2Cdk.Gs2Distributor.Model
{
    public class BatchRequestPayload {
        private string requestId;
        private BatchRequestPayloadService? service;
        private string methodName;
        private string parameter;

        public BatchRequestPayload(
            string requestId,
            BatchRequestPayloadService service,
            string methodName,
            string parameter,
            BatchRequestPayloadOptions options = null
        ){
            this.requestId = requestId;
            this.service = service;
            this.methodName = methodName;
            this.parameter = parameter;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.requestId != null) {
                properties["requestId"] = this.requestId;
            }
            if (this.service != null) {
                properties["service"] = this.service.Value.Str(
                );
            }
            if (this.methodName != null) {
                properties["methodName"] = this.methodName;
            }
            if (this.parameter != null) {
                properties["parameter"] = this.parameter;
            }

            return properties;
        }

        public static BatchRequestPayload FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BatchRequestPayload(
                properties.TryGetValue("requestId", out var requestId) ? new Func<string>(() =>
                {
                    return (string) requestId;
                })() : default,
                properties.TryGetValue("service", out var service) ? new Func<BatchRequestPayloadService>(() =>
                {
                    return service switch {
                        BatchRequestPayloadService e => e,
                        string s => BatchRequestPayloadServiceExt.New(s),
                        _ => BatchRequestPayloadService.Account
                    };
                })() : default,
                properties.TryGetValue("methodName", out var methodName) ? new Func<string>(() =>
                {
                    return (string) methodName;
                })() : default,
                properties.TryGetValue("parameter", out var parameter) ? new Func<string>(() =>
                {
                    return (string) parameter;
                })() : default,
                new BatchRequestPayloadOptions {
                }
            );

            return model;
        }
    }
}
