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
using Gs2Cdk.Gs2Ranking2.Model;
using Gs2Cdk.Gs2Ranking2.Model.Options;

namespace Gs2Cdk.Gs2Ranking2.Model
{
    public class ConsumeActionResult {
        private string action;
        private string consumeRequest;
        private int? statusCode;
        private string statusCodeString;
        private string consumeResult;

        public ConsumeActionResult(
            string action,
            string consumeRequest,
            ConsumeActionResultOptions options = null
        ){
            this.action = action;
            this.consumeRequest = consumeRequest;
            this.statusCode = options?.statusCode;
            this.consumeResult = options?.consumeResult;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.consumeRequest != null) {
                properties["consumeRequest"] = this.consumeRequest;
            }
            if (this.statusCodeString != null) {
                properties["statusCode"] = this.statusCodeString;
            } else {
                if (this.statusCode != null) {
                    properties["statusCode"] = this.statusCode;
                }
            }
            if (this.consumeResult != null) {
                properties["consumeResult"] = this.consumeResult;
            }

            return properties;
        }

        public static ConsumeActionResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ConsumeActionResult(
                properties.TryGetValue("action", out var action) ? new Func<string>(() =>
                {
                    return (string) action;
                })() : default,
                properties.TryGetValue("consumeRequest", out var consumeRequest) ? new Func<string>(() =>
                {
                    return (string) consumeRequest;
                })() : default,
                new ConsumeActionResultOptions {
                    statusCode = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("statusCode", out var statusCode) ? statusCode switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    consumeResult = properties.TryGetValue("consumeResult", out var consumeResult) ? (string)consumeResult : null
                }
            );

            return model;
        }
    }
}
