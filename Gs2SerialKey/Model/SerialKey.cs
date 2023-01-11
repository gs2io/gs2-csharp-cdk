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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.Model.Enums;
using Gs2Cdk.Gs2SerialKey.Model.Options;

namespace Gs2Cdk.Gs2SerialKey.Model
{
    public class SerialKey {
        private string campaignModelName;
        private string code;
        private SerialKeyStatus? status;
        private long? createdAt;
        private long? updatedAt;
        private string metadata;
        private string usedUserId;
        private long? usedAt;

        public SerialKey(
            string campaignModelName,
            string code,
            SerialKeyStatus status,
            long? createdAt,
            long? updatedAt,
            SerialKeyOptions options = null
        ){
            this.campaignModelName = campaignModelName;
            this.code = code;
            this.status = status;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.metadata = options?.metadata;
            this.usedUserId = options?.usedUserId;
            this.usedAt = options?.usedAt;
        }

        public static SerialKey StatusIsActive(
            string campaignModelName,
            string code,
            long? createdAt,
            long? updatedAt,
            SerialKeyStatusIsActiveOptions options = null
        ){
            return (new SerialKey(
                campaignModelName,
                code,
                SerialKeyStatus.Active,
                createdAt,
                updatedAt,
                new SerialKeyOptions {
                    metadata = options?.metadata,
                    usedAt = options?.usedAt,
                }
            ));
        }

        public static SerialKey StatusIsUsed(
            string campaignModelName,
            string code,
            long? createdAt,
            long? updatedAt,
            string usedUserId,
            SerialKeyStatusIsUsedOptions options = null
        ){
            return (new SerialKey(
                campaignModelName,
                code,
                SerialKeyStatus.Used,
                createdAt,
                updatedAt,
                new SerialKeyOptions {
                    usedUserId = usedUserId,
                    metadata = options?.metadata,
                    usedAt = options?.usedAt,
                }
            ));
        }

        public static SerialKey StatusIsInactive(
            string campaignModelName,
            string code,
            long? createdAt,
            long? updatedAt,
            SerialKeyStatusIsInactiveOptions options = null
        ){
            return (new SerialKey(
                campaignModelName,
                code,
                SerialKeyStatus.Inactive,
                createdAt,
                updatedAt,
                new SerialKeyOptions {
                    metadata = options?.metadata,
                    usedAt = options?.usedAt,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.campaignModelName != null) {
                properties["campaignModelName"] = this.campaignModelName;
            }
            if (this.code != null) {
                properties["code"] = this.code;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.status != null) {
                properties["status"] = this.status?.Str(
                );
            }
            if (this.usedUserId != null) {
                properties["usedUserId"] = this.usedUserId;
            }
            if (this.createdAt != null) {
                properties["createdAt"] = this.createdAt;
            }
            if (this.usedAt != null) {
                properties["usedAt"] = this.usedAt;
            }
            if (this.updatedAt != null) {
                properties["updatedAt"] = this.updatedAt;
            }

            return properties;
        }
    }
}
