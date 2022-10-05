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
using Gs2Cdk.Gs2Log.Resource;

namespace Gs2Cdk.Gs2Log.Model
{

    public class IssueStampSheetLog
    {
	    private readonly long? _timestamp;
	    private readonly string _transactionId;
	    private readonly string _service;
	    private readonly string _method;
	    private readonly string _userId;
	    private readonly string _action;
	    private readonly string _args;
	    private readonly string[] _tasks;

        public IssueStampSheetLog(
                long? timestamp,
                string transactionId,
                string service,
                string method,
                string userId,
                string action,
                string args,
                string[] tasks = null
        )
        {
            this._timestamp = timestamp;
            this._transactionId = transactionId;
            this._service = service;
            this._method = method;
            this._userId = userId;
            this._action = action;
            this._args = args;
            this._tasks = tasks;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._timestamp != null) {
                properties["Timestamp"] = this._timestamp;
            }
            if (this._transactionId != null) {
                properties["TransactionId"] = this._transactionId;
            }
            if (this._service != null) {
                properties["Service"] = this._service;
            }
            if (this._method != null) {
                properties["Method"] = this._method;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._action != null) {
                properties["Action"] = this._action;
            }
            if (this._args != null) {
                properties["Args"] = this._args;
            }
            if (this._tasks != null) {
                properties["Tasks"] = this._tasks;
            }
            return properties;
        }
    }
}
