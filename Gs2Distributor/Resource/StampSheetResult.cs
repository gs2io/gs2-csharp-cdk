/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Distributor.Model;
using Gs2Cdk.Gs2Distributor.Ref;

namespace Gs2Cdk.Gs2Distributor.Resource
{

    public class StampSheetResult {
	    private readonly string _userId;
	    private readonly string _transactionId;
	    private readonly ConsumeAction[] _taskRequests;
	    private readonly AcquireAction _sheetRequest;
	    private readonly string[] _taskResults;
	    private readonly string _sheetResult;
	    private readonly string _nextTransactionId;
	    private readonly long? _createdAt;
	    private readonly long? _ttlAt;

        public StampSheetResult(
                string userId,
                string transactionId,
                AcquireAction sheetRequest,
                long? createdAt,
                long? ttlAt,
                ConsumeAction[] taskRequests = null,
                string[] taskResults = null,
                string sheetResult = null,
                string nextTransactionId = null
        )
        {
            this._userId = userId;
            this._transactionId = transactionId;
            this._taskRequests = taskRequests;
            this._sheetRequest = sheetRequest;
            this._taskResults = taskResults;
            this._sheetResult = sheetResult;
            this._nextTransactionId = nextTransactionId;
            this._createdAt = createdAt;
            this._ttlAt = ttlAt;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._transactionId != null) {
                properties["TransactionId"] = this._transactionId;
            }
            if (this._taskRequests != null) {
                properties["TaskRequests"] = this._taskRequests.Select(v => v.Properties()).ToArray();
            }
            if (this._sheetRequest != null) {
                properties["SheetRequest"] = this._sheetRequest.Properties();
            }
            if (this._taskResults != null) {
                properties["TaskResults"] = this._taskResults;
            }
            if (this._sheetResult != null) {
                properties["SheetResult"] = this._sheetResult;
            }
            if (this._nextTransactionId != null) {
                properties["NextTransactionId"] = this._nextTransactionId;
            }
            if (this._createdAt != null) {
                properties["CreatedAt"] = this._createdAt;
            }
            if (this._ttlAt != null) {
                properties["TtlAt"] = this._ttlAt;
            }
            return properties;
        }
    }
}
