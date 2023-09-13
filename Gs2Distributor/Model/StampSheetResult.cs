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
    public class StampSheetResult {
        private string userId;
        private string transactionId;
        private AcquireAction sheetRequest;
        private ConsumeAction[] taskRequests;
        private string[] taskResults;
        private string sheetResult;
        private string nextTransactionId;
        private long? revision;

        public StampSheetResult(
            string userId,
            string transactionId,
            AcquireAction sheetRequest,
            StampSheetResultOptions options = null
        ){
            this.userId = userId;
            this.transactionId = transactionId;
            this.sheetRequest = sheetRequest;
            this.taskRequests = options?.taskRequests;
            this.taskResults = options?.taskResults;
            this.sheetResult = options?.sheetResult;
            this.nextTransactionId = options?.nextTransactionId;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.transactionId != null) {
                properties["transactionId"] = this.transactionId;
            }
            if (this.taskRequests != null) {
                properties["taskRequests"] = this.taskRequests.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.sheetRequest != null) {
                properties["sheetRequest"] = this.sheetRequest?.Properties(
                );
            }
            if (this.taskResults != null) {
                properties["taskResults"] = this.taskResults;
            }
            if (this.sheetResult != null) {
                properties["sheetResult"] = this.sheetResult;
            }
            if (this.nextTransactionId != null) {
                properties["nextTransactionId"] = this.nextTransactionId;
            }

            return properties;
        }

        public static StampSheetResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new StampSheetResult(
                (string)properties["userId"],
                (string)properties["transactionId"],
                new Func<AcquireAction>(() =>
                {
                    return properties["sheetRequest"] switch {
                        AcquireAction v => v,
                        Dictionary<string, object> v => AcquireAction.FromProperties(v),
                        _ => null
                    };
                })(),
                new StampSheetResultOptions {
                    taskRequests = properties.TryGetValue("taskRequests", out var taskRequests) ? new Func<ConsumeAction[]>(() =>
                    {
                        return taskRequests switch {
                            ConsumeAction[] v => v,
                            List<ConsumeAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    taskResults = properties.TryGetValue("taskResults", out var taskResults) ? new Func<string[]>(() =>
                    {
                        return taskResults switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    sheetResult = properties.TryGetValue("sheetResult", out var sheetResult) ? (string)sheetResult : null,
                    nextTransactionId = properties.TryGetValue("nextTransactionId", out var nextTransactionId) ? (string)nextTransactionId : null,
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
