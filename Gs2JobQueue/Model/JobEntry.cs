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

namespace Gs2Cdk.Gs2JobQueue.Model
{

    public class JobEntry
    {
	    private readonly string _scriptId;
	    private readonly string _args;
	    private readonly int? _maxTryCount;

        public JobEntry(
                string scriptId,
                string args,
                int? maxTryCount
        )
        {
            this._scriptId = scriptId;
            this._args = args;
            this._maxTryCount = maxTryCount;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._scriptId != null) {
                properties["ScriptId"] = this._scriptId;
            }
            if (this._args != null) {
                properties["Args"] = this._args;
            }
            if (this._maxTryCount != null) {
                properties["MaxTryCount"] = this._maxTryCount;
            }
            return properties;
        }
    }
}
