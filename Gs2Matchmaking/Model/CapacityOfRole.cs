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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class CapacityOfRole {
        private string roleName;
        private int capacity;
        private string capacityString;
        private string[] roleAliases;
        private Player[] participants;

        public CapacityOfRole(
            string roleName,
            int capacity,
            CapacityOfRoleOptions options = null
        ){
            this.roleName = roleName;
            this.capacity = capacity;
            this.roleAliases = options?.roleAliases;
            this.participants = options?.participants;
        }


        public CapacityOfRole(
            string roleName,
            string capacity,
            CapacityOfRoleOptions options = null
        ){
            this.roleName = roleName;
            this.capacityString = capacity;
            this.roleAliases = options?.roleAliases;
            this.participants = options?.participants;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.roleName != null) {
                properties["roleName"] = this.roleName;
            }
            if (this.roleAliases != null) {
                properties["roleAliases"] = this.roleAliases;
            }
            if (this.capacityString != null) {
                properties["capacity"] = this.capacityString;
            } else {
                if (this.capacity != null) {
                    properties["capacity"] = this.capacity;
                }
            }
            if (this.participants != null) {
                properties["participants"] = this.participants.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static CapacityOfRole FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CapacityOfRole(
                (string)properties["roleName"],
                new Func<int>(() =>
                {
                    return properties["capacity"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new CapacityOfRoleOptions {
                    roleAliases = properties.TryGetValue("roleAliases", out var roleAliases) ? new Func<string[]>(() =>
                    {
                        return roleAliases switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    participants = properties.TryGetValue("participants", out var participants) ? new Func<Player[]>(() =>
                    {
                        return participants switch {
                            Player[] v => v,
                            List<Player> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(Player.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(Player.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
