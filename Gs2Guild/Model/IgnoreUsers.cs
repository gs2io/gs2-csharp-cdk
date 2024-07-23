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
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.Model.Options;

namespace Gs2Cdk.Gs2Guild.Model
{
    public class IgnoreUsers {
        private string guildModelName;
        private IgnoreUser[] users;
        private long? revision;
        private string revisionString;

        public IgnoreUsers(
            string guildModelName,
            IgnoreUsersOptions options = null
        ){
            this.guildModelName = guildModelName;
            this.users = options?.users;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.guildModelName != null) {
                properties["guildModelName"] = this.guildModelName;
            }
            if (this.users != null) {
                properties["users"] = this.users.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static IgnoreUsers FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new IgnoreUsers(
                (string)properties["guildModelName"],
                new IgnoreUsersOptions {
                    users = properties.TryGetValue("users", out var users) ? new Func<IgnoreUser[]>(() =>
                    {
                        return users switch {
                            IgnoreUser[] v => v,
                            List<IgnoreUser> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(IgnoreUser.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(IgnoreUser.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
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
