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
        private long? updatedAt;
        private long? nextResetAt;

        public ScopedValue(
            ScopedValueResetType resetType,
            long? value,
            long? updatedAt,
            ScopedValueOptions options = null
        ){
            this.resetType = resetType;
            this.value = value;
            this.updatedAt = updatedAt;
            this.nextResetAt = options?.nextResetAt;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.resetType != null) {
                properties["resetType"] = this.resetType?.Str(
                );
            }
            if (this.value != null) {
                properties["value"] = this.value;
            }
            if (this.nextResetAt != null) {
                properties["nextResetAt"] = this.nextResetAt;
            }
            if (this.updatedAt != null) {
                properties["updatedAt"] = this.updatedAt;
            }

            return properties;
        }
    }
}
