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

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.StampSheet;
using Gs2Cdk.Gs2Guild.StampSheet.Enums;

namespace Gs2Cdk.Gs2Guild.Ref
{
    public class GuildModelRef {
        private string namespaceName;
        private string guildModelName;

        public GuildModelRef(
            string namespaceName,
            string guildModelName
        ){
            this.namespaceName = namespaceName;
            this.guildModelName = guildModelName;
        }

        public RoleModelRef RoleModel(
        ){
            return (new RoleModelRef(
                this.namespaceName,
                this.guildModelName
            ));
        }

        public IncreaseMaximumCurrentMaximumMemberCountByGuildName IncreaseMaximumCurrentMaximumMemberCountByGuildName(
            string guildName,
            int? value = null
        ){
            return (new IncreaseMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                this.guildModelName,
                guildName,
                value
            ));
        }

        public SetMaximumCurrentMaximumMemberCountByGuildName SetMaximumCurrentMaximumMemberCountByGuildName(
            string guildName,
            int? value = null
        ){
            return (new SetMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                guildName,
                this.guildModelName,
                value
            ));
        }

        public DecreaseMaximumCurrentMaximumMemberCountByGuildName DecreaseMaximumCurrentMaximumMemberCountByGuildName(
            string guildName,
            int? value = null
        ){
            return (new DecreaseMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                this.guildModelName,
                guildName,
                value
            ));
        }

        public VerifyCurrentMaximumMemberCountByGuildName VerifyCurrentMaximumMemberCountByGuildName(
            string guildName,
            VerifyCurrentMaximumMemberCountByGuildNameVerifyType verifyType,
            int? value = null,
            bool? multiplyValueSpecifyingQuantity = null
        ){
            return (new VerifyCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                this.guildModelName,
                guildName,
                verifyType,
                value,
                multiplyValueSpecifyingQuantity
            ));
        }

        public VerifyIncludeMemberByUserId VerifyIncludeMember(
            VerifyIncludeMemberByUserIdVerifyType verifyType,
            string guildName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyIncludeMemberByUserId(
                this.namespaceName,
                this.guildModelName,
                verifyType,
                guildName,
                userId
            ));
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "guild",
                    this.namespaceName,
                    "model",
                    this.guildModelName
                }
            )).Str(
            );
        }
    }
}
