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
        private ScopedValueResetType? resetType;
        private long? value;
        private string valueString;
        private long? nextResetAt;
        private string nextResetAtString;

        public ScopedValue(
            ScopedValueResetType resetType,
            long? value,
            ScopedValueOptions options = null
        ){
            this.resetType = resetType;
            this.value = value;
            this.nextResetAt = options?.nextResetAt;
        }


        public ScopedValue(
            ScopedValueResetType resetType,
            string value,
            ScopedValueOptions options = null
        ){
            this.resetType = resetType;
            this.valueString = value;
            this.nextResetAt = options?.nextResetAt;
            this.nextResetAtString = options?.nextResetAtString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
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
                new Func<ScopedValueResetType>(() =>
                {
                    return properties["resetType"] switch {
                        ScopedValueResetType e => e,
                        string s => ScopedValueResetTypeExt.New(s),
                        _ => ScopedValueResetType.NotReset
                    };
                })(),
                new Func<long?>(() =>
                {
                    return properties["value"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new ScopedValueOptions {
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
