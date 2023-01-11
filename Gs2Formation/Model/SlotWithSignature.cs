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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.Model.Enums;
using Gs2Cdk.Gs2Formation.Model.Options;

namespace Gs2Cdk.Gs2Formation.Model
{
    public class SlotWithSignature {
        private string name;
        private SlotWithSignaturePropertyType? propertyType;
        private string body;
        private string signature;
        private string metadata;

        public SlotWithSignature(
            string name,
            SlotWithSignaturePropertyType propertyType,
            string body,
            string signature,
            SlotWithSignatureOptions options = null
        ){
            this.name = name;
            this.propertyType = propertyType;
            this.body = body;
            this.signature = signature;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.propertyType != null) {
                properties["propertyType"] = this.propertyType?.Str(
                );
            }
            if (this.body != null) {
                properties["body"] = this.body;
            }
            if (this.signature != null) {
                properties["signature"] = this.signature;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }

            return properties;
        }
    }
}
