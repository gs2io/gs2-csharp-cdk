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
using Gs2Cdk.Gs2Auth.Model;
using Gs2Cdk.Gs2Auth.Model.Options;

namespace Gs2Cdk.Gs2Auth.Model
{
    public class AccessToken {
        private string ownerId;
        private string userId;
        private long? expire;
        private int? timeOffset;

        public AccessToken(
            string ownerId,
            string userId,
            long? expire,
            int? timeOffset,
            AccessTokenOptions options = null
        ){
            this.ownerId = ownerId;
            this.userId = userId;
            this.expire = expire;
            this.timeOffset = timeOffset;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.ownerId != null) {
                properties["ownerId"] = this.ownerId;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.expire != null) {
                properties["expire"] = this.expire;
            }
            if (this.timeOffset != null) {
                properties["timeOffset"] = this.timeOffset;
            }

            return properties;
        }
    }
}
