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
using Gs2Cdk.Gs2SkillTree.Model;
using Gs2Cdk.Gs2SkillTree.Model.Options;

namespace Gs2Cdk.Gs2SkillTree.Model
{
    public class VerifyActionResult {
        private string action;
        private string verifyRequest;
        private int? statusCode;
        private string statusCodeString;
        private string verifyResult;

        public VerifyActionResult(
            string action,
            string verifyRequest,
            VerifyActionResultOptions options = null
        ){
            this.action = action;
            this.verifyRequest = verifyRequest;
            this.statusCode = options?.statusCode;
            this.verifyResult = options?.verifyResult;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.verifyRequest != null) {
                properties["verifyRequest"] = this.verifyRequest;
            }
            if (this.statusCodeString != null) {
                properties["statusCode"] = this.statusCodeString;
            } else {
                if (this.statusCode != null) {
                    properties["statusCode"] = this.statusCode;
                }
            }
            if (this.verifyResult != null) {
                properties["verifyResult"] = this.verifyResult;
            }

            return properties;
        }

        public static VerifyActionResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new VerifyActionResult(
                properties.TryGetValue("action", out var action) ? new Func<string>(() =>
                {
                    return (string) action;
                })() : default,
                properties.TryGetValue("verifyRequest", out var verifyRequest) ? new Func<string>(() =>
                {
                    return (string) verifyRequest;
                })() : default,
                new VerifyActionResultOptions {
                    statusCode = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("statusCode", out var statusCode) ? statusCode switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    verifyResult = properties.TryGetValue("verifyResult", out var verifyResult) ? (string)verifyResult : null
                }
            );

            return model;
        }
    }
}
