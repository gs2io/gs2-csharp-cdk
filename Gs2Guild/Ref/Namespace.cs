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
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public GuildModelRef GuildModel(
            string guildModelName
        ){
            return (new GuildModelRef(
                this.namespaceName,
                guildModelName
            ));
        }

        public IncreaseMaximumCurrentMaximumMemberCountByGuildName IncreaseMaximumCurrentMaximumMemberCountByGuildName(
            string guildModelName,
            string guildName,
            int? value = null
        ){
            return (new IncreaseMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                guildModelName,
                guildName,
                value
            ));
        }

        public SetMaximumCurrentMaximumMemberCountByGuildName SetMaximumCurrentMaximumMemberCountByGuildName(
            string guildName,
            string guildModelName,
            int? value = null
        ){
            return (new SetMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                guildName,
                guildModelName,
                value
            ));
        }

        public DecreaseMaximumCurrentMaximumMemberCountByGuildName DecreaseMaximumCurrentMaximumMemberCountByGuildName(
            string guildModelName,
            string guildName,
            int? value = null
        ){
            return (new DecreaseMaximumCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                guildModelName,
                guildName,
                value
            ));
        }

        public VerifyCurrentMaximumMemberCountByGuildName VerifyCurrentMaximumMemberCountByGuildName(
            string guildModelName,
            string guildName,
            VerifyCurrentMaximumMemberCountByGuildNameVerifyType verifyType,
            int? value = null,
            bool? multiplyValueSpecifyingQuantity = null
        ){
            return (new VerifyCurrentMaximumMemberCountByGuildName(
                this.namespaceName,
                guildModelName,
                guildName,
                verifyType,
                value,
                multiplyValueSpecifyingQuantity
            ));
        }

        public VerifyIncludeMemberByUserId VerifyIncludeMember(
            string guildModelName,
            VerifyIncludeMemberByUserIdVerifyType verifyType,
            string guildName = null,
            string userId = "#{userId}"
        ){
            return (new VerifyIncludeMemberByUserId(
                this.namespaceName,
                guildModelName,
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
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
