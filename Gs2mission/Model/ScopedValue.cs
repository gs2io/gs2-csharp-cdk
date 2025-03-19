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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Model.Enums;
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class ScopedValue {
        private ScopedValueScopeType? scopeType;
        private long? value;
        private string valueString;
        private ScopedValueResetType? resetType;
        private string conditionName;
        private long? nextResetAt;
        private string nextResetAtString;

        public ScopedValue(
            ScopedValueScopeType scopeType,
            long? value,
            ScopedValueOptions options = null
        ){
            this.scopeType = scopeType;
            this.value = value;
            this.resetType = options?.resetType;
            this.conditionName = options?.conditionName;
            this.nextResetAt = options?.nextResetAt;
        }

        public static ScopedValue ScopeTypeIsResetTiming(
            long? value,
            ScopedValueResetType resetType,
            ScopedValueScopeTypeIsResetTimingOptions options = null
        ){
            return (new ScopedValue(
                ScopedValueScopeType.ResetTiming,
                value,
                new ScopedValueOptions {
                    resetType = resetType,
                    nextResetAt = options?.nextResetAt,
                }
            ));
        }

        public static ScopedValue ScopeTypeIsVerifyAction(
            long? value,
            string conditionName,
            ScopedValueScopeTypeIsVerifyActionOptions options = null
        ){
            return (new ScopedValue(
                ScopedValueScopeType.VerifyAction,
                value,
                new ScopedValueOptions {
                    conditionName = conditionName,
                    nextResetAt = options?.nextResetAt,
                }
            ));
        }


        public ScopedValue(
            ScopedValueScopeType scopeType,
            string value,
            ScopedValueOptions options = null
        ){
            this.scopeType = scopeType;
            this.valueString = value;
            this.resetType = options?.resetType;
            this.conditionName = options?.conditionName;
            this.nextResetAt = options?.nextResetAt;
            this.nextResetAtString = options?.nextResetAtString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.scopeType != null) {
                properties["scopeType"] = this.scopeType.Value.Str(
                );
            }
            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.conditionName != null) {
                properties["conditionName"] = this.conditionName;
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }
            if (this.nextResetAtString != null) {
                properties["nextResetAt"] = this.nextResetAtString;
            } else {
                if (this.nextResetAt != null) {
                    properties["nextResetAt"] = this.nextResetAt;
                }
            }

            return properties;
        }

        public static ScopedValue FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ScopedValue(
                properties.TryGetValue("scopeType", out var scopeType) ? new Func<ScopedValueScopeType>(() =>
                {
                    return scopeType switch {
                        ScopedValueScopeType e => e,
                        string s => ScopedValueScopeTypeExt.New(s),
                        _ => ScopedValueScopeType.ResetTiming
                    };
                })() : default,
                properties.TryGetValue("value", out var value) ? new Func<long?>(() =>
                {
                    return value switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new ScopedValueOptions {
                    resetType = properties.TryGetValue("resetType", out var resetType) ? ScopedValueResetTypeExt.New(resetType as string) : null,
                    conditionName = properties.TryGetValue("conditionName", out var conditionName) ? (string)conditionName : null,
                    nextResetAt = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("nextResetAt", out var nextResetAt) ? nextResetAt switch {
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
