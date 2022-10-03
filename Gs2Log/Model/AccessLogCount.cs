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

namespace Gs2Cdk.Gs2Log.Model
{

    public class AccessLogCount
    {
	    private readonly string _service;
	    private readonly string _method;
	    private readonly string _userId;
	    private readonly long? _count;

        public AccessLogCount(
                long? count,
                string service = null,
                string method = null,
                string userId = null
        )
        {
            this._service = service;
            this._method = method;
            this._userId = userId;
            this._count = count;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._service != null) {
                properties["Service"] = this._service;
            }
            if (this._method != null) {
                properties["Method"] = this._method;
            }
            if (this._userId != null) {
                properties["UserId"] = this._userId;
            }
            if (this._count != null) {
                properties["Count"] = this._count;
            }
            return properties;
        }
    }
}
