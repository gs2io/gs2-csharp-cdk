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
using Gs2Cdk.Gs2JobQueue.Resource;

namespace Gs2Cdk.Gs2JobQueue.Model
{

    public class JobResultBody
    {
	    private readonly int? _tryNumber;
	    private readonly int? _statusCode;
	    private readonly string _result;
	    private readonly long? _tryAt;

        public JobResultBody(
                int? tryNumber,
                int? statusCode,
                string result,
                long? tryAt
        )
        {
            this._tryNumber = tryNumber;
            this._statusCode = statusCode;
            this._result = result;
            this._tryAt = tryAt;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._tryNumber != null) {
                properties["TryNumber"] = this._tryNumber;
            }
            if (this._statusCode != null) {
                properties["StatusCode"] = this._statusCode;
            }
            if (this._result != null) {
                properties["Result"] = this._result;
            }
            if (this._tryAt != null) {
                properties["TryAt"] = this._tryAt;
            }
            return properties;
        }
    }
}
