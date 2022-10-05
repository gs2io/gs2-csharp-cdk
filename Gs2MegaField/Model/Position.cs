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
using Gs2Cdk.Gs2MegaField.Resource;

namespace Gs2Cdk.Gs2MegaField.Model
{

    public class Position
    {
	    private readonly float? _x;
	    private readonly float? _y;
	    private readonly float? _z;

        public Position(
                float? x,
                float? y,
                float? z
        )
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._x != null) {
                properties["X"] = this._x;
            }
            if (this._y != null) {
                properties["Y"] = this._y;
            }
            if (this._z != null) {
                properties["Z"] = this._z;
            }
            return properties;
        }
    }
}
