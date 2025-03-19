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
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.Model.Options;

namespace Gs2Cdk.Gs2Guild.Model
{
    public class AcquireActionResult {
        private string action;
        private string acquireRequest;
        private int? statusCode;
        private string statusCodeString;
        private string acquireResult;

        public AcquireActionResult(
            string action,
            string acquireRequest,
            AcquireActionResultOptions options = null
        ){
            this.action = action;
            this.acquireRequest = acquireRequest;
            this.statusCode = options?.statusCode;
            this.acquireResult = options?.acquireResult;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.acquireRequest != null) {
                properties["acquireRequest"] = this.acquireRequest;
            }
            if (this.statusCodeString != null) {
                properties["statusCode"] = this.statusCodeString;
            } else {
                if (this.statusCode != null) {
                    properties["statusCode"] = this.statusCode;
                }
            }
            if (this.acquireResult != null) {
                properties["acquireResult"] = this.acquireResult;
            }

            return properties;
        }

        public static AcquireActionResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AcquireActionResult(
                properties.TryGetValue("action", out var action) ? new Func<string>(() =>
                {
                    return (string) action;
                })() : default,
                properties.TryGetValue("acquireRequest", out var acquireRequest) ? new Func<string>(() =>
                {
                    return (string) acquireRequest;
                })() : default,
                new AcquireActionResultOptions {
                    statusCode = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("statusCode", out var statusCode) ? statusCode switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    acquireResult = properties.TryGetValue("acquireResult", out var acquireResult) ? (string)acquireResult : null
                }
            );

            return model;
        }
    }
}
