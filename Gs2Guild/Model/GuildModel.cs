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
    public class GuildModel {
        private string name;
        private int defaultMaximumMemberCount;
        private int maximumMemberCount;
        private RoleModel[] roles;
        private string guildMasterRole;
        private string guildMemberDefaultRole;
        private int? rejoinCoolTimeMinutes;
        private string metadata;

        public GuildModel(
            string name,
            int defaultMaximumMemberCount,
            int maximumMemberCount,
            RoleModel[] roles,
            string guildMasterRole,
            string guildMemberDefaultRole,
            int? rejoinCoolTimeMinutes,
            GuildModelOptions options = null
        ){
            this.name = name;
            this.defaultMaximumMemberCount = defaultMaximumMemberCount;
            this.maximumMemberCount = maximumMemberCount;
            this.roles = roles;
            this.guildMasterRole = guildMasterRole;
            this.guildMemberDefaultRole = guildMemberDefaultRole;
            this.rejoinCoolTimeMinutes = rejoinCoolTimeMinutes;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.defaultMaximumMemberCount != null) {
                properties["defaultMaximumMemberCount"] = this.defaultMaximumMemberCount;
            }
            if (this.maximumMemberCount != null) {
                properties["maximumMemberCount"] = this.maximumMemberCount;
            }
            if (this.roles != null) {
                properties["roles"] = this.roles.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.guildMasterRole != null) {
                properties["guildMasterRole"] = this.guildMasterRole;
            }
            if (this.guildMemberDefaultRole != null) {
                properties["guildMemberDefaultRole"] = this.guildMemberDefaultRole;
            }
            if (this.rejoinCoolTimeMinutes != null) {
                properties["rejoinCoolTimeMinutes"] = this.rejoinCoolTimeMinutes;
            }

            return properties;
        }

        public static GuildModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GuildModel(
                (string)properties["name"],
                new Func<int>(() =>
                {
                    return properties["defaultMaximumMemberCount"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["maximumMemberCount"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<RoleModel[]>(() =>
                {
                    return properties["roles"] switch {
                        Dictionary<string, object>[] v => v.Select(RoleModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ RoleModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(RoleModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as RoleModel).ToArray(),
                        { } v => new []{ v as RoleModel },
                        _ => null
                    };
                })(),
                (string)properties["guildMasterRole"],
                (string)properties["guildMemberDefaultRole"],
                new Func<int?>(() =>
                {
                    return properties["rejoinCoolTimeMinutes"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new GuildModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
