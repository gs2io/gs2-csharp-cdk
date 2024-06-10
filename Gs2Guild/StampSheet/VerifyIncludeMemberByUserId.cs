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
using Gs2Cdk.Gs2Guild.StampSheet.Enums;

namespace Gs2Cdk.Gs2Guild.StampSheet
{
    public class VerifyIncludeMemberByUserId : ConsumeAction {
        private string namespaceName;
        private string guildModelName;
        private string userId;
        private VerifyIncludeMemberByUserIdVerifyType? verifyType;
        private string guildName;
        private string timeOffsetToken;


        public VerifyIncludeMemberByUserId(
            string namespaceName,
            string guildModelName,
            VerifyIncludeMemberByUserIdVerifyType verifyType,
            string guildName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.guildModelName = guildModelName;
            this.verifyType = verifyType;
            this.guildName = guildName;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.guildModelName != null) {
                properties["guildModelName"] = this.guildModelName;
            }
            if (this.guildName != null) {
                properties["guildName"] = this.guildName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyIncludeMemberByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyIncludeMemberByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["guildModelName"],
                    new Func<VerifyIncludeMemberByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyIncludeMemberByUserIdVerifyType e => e,
                            string s => VerifyIncludeMemberByUserIdVerifyTypeExt.New(s),
                            _ => VerifyIncludeMemberByUserIdVerifyType.Include
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("guildName", out var guildName) ? guildName as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyIncludeMemberByUserId(
                    properties["namespaceName"].ToString(),
                    properties["guildModelName"].ToString(),
                    new Func<VerifyIncludeMemberByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyIncludeMemberByUserIdVerifyType e => e,
                            string s => VerifyIncludeMemberByUserIdVerifyTypeExt.New(s),
                            _ => VerifyIncludeMemberByUserIdVerifyType.Include
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("guildName", out var guildName) ? guildName.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Guild:VerifyIncludeMemberByUserId";
        }

        public static string StaticAction() {
            return "Gs2Guild:VerifyIncludeMemberByUserId";
        }
    }
}
