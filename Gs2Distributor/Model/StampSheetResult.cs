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
    }
}
