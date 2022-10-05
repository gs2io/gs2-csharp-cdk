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
using Gs2Cdk.Gs2Mission.Resource;

namespace Gs2Cdk.Gs2Mission.Model
{

    public static class ScopedValueResetTypeExt
    {
        public static string ToString(this ScopedValue.ResetType self)
        {
            switch (self) {
                case ScopedValue.ResetType.NotReset:
                    return "notReset";
                case ScopedValue.ResetType.Daily:
                    return "daily";
                case ScopedValue.ResetType.Weekly:
                    return "weekly";
                case ScopedValue.ResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }
    }

    public class ScopedValue
    {

        public enum ResetType
        {
            NotReset,
            Daily,
            Weekly,
            Monthly
        }
	    private readonly ResetType _resetType;
	    private readonly long? _value;
	    private readonly long? _nextResetAt;
	    private readonly long? _updatedAt;

        public ScopedValue(
                ResetType resetType,
                long? value,
                long? updatedAt,
                long? nextResetAt = null
        )
        {
            this._resetType = resetType;
            this._value = value;
            this._nextResetAt = nextResetAt;
            this._updatedAt = updatedAt;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._resetType != null) {
                properties["ResetType"] = this._resetType.ToString();
            }
            if (this._value != null) {
                properties["Value"] = this._value;
            }
            if (this._nextResetAt != null) {
                properties["NextResetAt"] = this._nextResetAt;
            }
            if (this._updatedAt != null) {
                properties["UpdatedAt"] = this._updatedAt;
            }
            return properties;
        }
    }
}
