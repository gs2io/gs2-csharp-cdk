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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class Player {
        private string userId;
        private string roleName;
        private Attribute_[] attributes;
        private string[] denyUserIds;

        public Player(
            string userId,
            string roleName,
            PlayerOptions options = null
        ){
            this.userId = userId;
            this.roleName = roleName;
            this.attributes = options?.attributes;
            this.denyUserIds = options?.denyUserIds;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.attributes != null) {
                properties["attributes"] = this.attributes.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.roleName != null) {
                properties["roleName"] = this.roleName;
            }
            if (this.denyUserIds != null) {
                properties["denyUserIds"] = this.denyUserIds;
            }

            return properties;
        }
    }
}
