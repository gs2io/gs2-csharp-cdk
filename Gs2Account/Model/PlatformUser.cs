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
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class PlatformUser {
        private int type;
        private string typeString;
        private string userIdentifier;
        private string userId;

        public PlatformUser(
            int type,
            string userIdentifier,
            string userId,
            PlatformUserOptions options = null
        ){
            this.type = type;
            this.userIdentifier = userIdentifier;
            this.userId = userId;
        }


        public PlatformUser(
            string type,
            string userIdentifier,
            string userId,
            PlatformUserOptions options = null
        ){
            this.typeString = type;
            this.userIdentifier = userIdentifier;
            this.userId = userId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.typeString != null) {
                properties["type"] = this.typeString;
            } else {
                if (this.type != null) {
                    properties["type"] = this.type;
                }
            }
            if (this.userIdentifier != null) {
                properties["userIdentifier"] = this.userIdentifier;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }

            return properties;
        }

        public static PlatformUser FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new PlatformUser(
                new Func<int>(() =>
                {
                    return properties["type"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["userIdentifier"],
                (string)properties["userId"],
                new PlatformUserOptions {
                }
            );

            return model;
        }
    }
}
