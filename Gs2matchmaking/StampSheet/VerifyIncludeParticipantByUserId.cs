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
using Gs2Cdk.Gs2Matchmaking.StampSheet.Enums;

namespace Gs2Cdk.Gs2Matchmaking.StampSheet
{
    public class VerifyIncludeParticipantByUserId : VerifyAction {
        private string namespaceName;
        private string seasonName;
        private long season;
        private string seasonString;
        private long tier;
        private string tierString;
        private string userId;
        private VerifyIncludeParticipantByUserIdVerifyType? verifyType;
        private string seasonGatheringName;
        private string timeOffsetToken;


        public VerifyIncludeParticipantByUserId(
            string namespaceName,
            string seasonName,
            long season,
            long tier,
            VerifyIncludeParticipantByUserIdVerifyType verifyType,
            string seasonGatheringName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.seasonName = seasonName;
            this.season = season;
            this.tier = tier;
            this.verifyType = verifyType;
            this.seasonGatheringName = seasonGatheringName;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyIncludeParticipantByUserId(
            string namespaceName,
            string seasonName,
            string season,
            string tier,
            VerifyIncludeParticipantByUserIdVerifyType verifyType,
            string seasonGatheringName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.seasonName = seasonName;
            this.seasonString = season;
            this.tierString = tier;
            this.verifyType = verifyType;
            this.seasonGatheringName = seasonGatheringName;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.seasonName != null) {
                properties["seasonName"] = this.seasonName;
            }
            if (this.seasonString != null) {
                properties["season"] = this.seasonString;
            } else {
                if (this.season != null) {
                    properties["season"] = this.season;
                }
            }
            if (this.tierString != null) {
                properties["tier"] = this.tierString;
            } else {
                if (this.tier != null) {
                    properties["tier"] = this.tier;
                }
            }
            if (this.seasonGatheringName != null) {
                properties["seasonGatheringName"] = this.seasonGatheringName;
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

        public static VerifyIncludeParticipantByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyIncludeParticipantByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["seasonName"],
                    new Func<long>(() =>
                    {
                        return properties["season"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<long>(() =>
                    {
                        return properties["tier"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<VerifyIncludeParticipantByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyIncludeParticipantByUserIdVerifyType e => e,
                            string s => VerifyIncludeParticipantByUserIdVerifyTypeExt.New(s),
                            _ => VerifyIncludeParticipantByUserIdVerifyType.Include
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("seasonGatheringName", out var seasonGatheringName) ? seasonGatheringName as string : null;
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
                return new VerifyIncludeParticipantByUserId(
                    properties["namespaceName"].ToString(),
                    properties["seasonName"].ToString(),
                    properties["season"].ToString(),
                    properties["tier"].ToString(),
                    new Func<VerifyIncludeParticipantByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyIncludeParticipantByUserIdVerifyType e => e,
                            string s => VerifyIncludeParticipantByUserIdVerifyTypeExt.New(s),
                            _ => VerifyIncludeParticipantByUserIdVerifyType.Include
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("seasonGatheringName", out var seasonGatheringName) ? seasonGatheringName.ToString() : null;
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
            return "Gs2Matchmaking:VerifyIncludeParticipantByUserId";
        }

        public static string StaticAction() {
            return "Gs2Matchmaking:VerifyIncludeParticipantByUserId";
        }
    }
}
