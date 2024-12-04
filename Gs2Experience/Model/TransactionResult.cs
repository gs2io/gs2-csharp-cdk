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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class TransactionResult {
        private string transactionId;
        private VerifyActionResult[] verifyResults;
        private ConsumeActionResult[] consumeResults;
        private AcquireActionResult[] acquireResults;

        public TransactionResult(
            string transactionId,
            TransactionResultOptions options = null
        ){
            this.transactionId = transactionId;
            this.verifyResults = options?.verifyResults;
            this.consumeResults = options?.consumeResults;
            this.acquireResults = options?.acquireResults;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.transactionId != null) {
                properties["transactionId"] = this.transactionId;
            }
            if (this.verifyResults != null) {
                properties["verifyResults"] = this.verifyResults.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.consumeResults != null) {
                properties["consumeResults"] = this.consumeResults.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.acquireResults != null) {
                properties["acquireResults"] = this.acquireResults.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static TransactionResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TransactionResult(
                properties.TryGetValue("transactionId", out var transactionId) ? new Func<string>(() =>
                {
                    return (string) transactionId;
                })() : default,
                new TransactionResultOptions {
                    verifyResults = properties.TryGetValue("verifyResults", out var verifyResults) ? new Func<VerifyActionResult[]>(() =>
                    {
                        return verifyResults switch {
                            VerifyActionResult[] v => v,
                            List<VerifyActionResult> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(VerifyActionResult.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(VerifyActionResult.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    consumeResults = properties.TryGetValue("consumeResults", out var consumeResults) ? new Func<ConsumeActionResult[]>(() =>
                    {
                        return consumeResults switch {
                            ConsumeActionResult[] v => v,
                            List<ConsumeActionResult> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeActionResult.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeActionResult.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    acquireResults = properties.TryGetValue("acquireResults", out var acquireResults) ? new Func<AcquireActionResult[]>(() =>
                    {
                        return acquireResults switch {
                            AcquireActionResult[] v => v,
                            List<AcquireActionResult> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireActionResult.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireActionResult.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
