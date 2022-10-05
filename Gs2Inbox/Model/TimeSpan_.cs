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
using Gs2Cdk.Gs2Inbox.Resource;

namespace Gs2Cdk.Gs2Inbox.Model
{

    public class TimeSpan_
    {
	    private readonly int? _days;
	    private readonly int? _hours;
	    private readonly int? _minutes;

        public TimeSpan_(
                int? days,
                int? hours,
                int? minutes
        )
        {
            this._days = days;
            this._hours = hours;
            this._minutes = minutes;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._days != null) {
                properties["Days"] = this._days;
            }
            if (this._hours != null) {
                properties["Hours"] = this._hours;
            }
            if (this._minutes != null) {
                properties["Minutes"] = this._minutes;
            }
            return properties;
        }
    }
}
