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
using Gs2Cdk.Gs2Friend.Model;
using Gs2Cdk.Gs2Friend.StampSheet.Enums;

namespace Gs2Cdk.Gs2Friend.StampSheet
{
    public class VerifyFriendByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string targetUserId;
        private VerifyFriendByUserIdVerifyType? verifyType;
        private string timeOffsetToken;


        public VerifyFriendByUserId(
            string namespaceName,
            string targetUserId,
            VerifyFriendByUserIdVerifyType verifyType,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.targetUserId = targetUserId;
            this.verifyType = verifyType;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.targetUserId != null) {
                properties["targetUserId"] = this.targetUserId;
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

        public static VerifyFriendByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyFriendByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["targetUserId"],
                    new Func<VerifyFriendByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFriendByUserIdVerifyType e => e,
                            string s => VerifyFriendByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFriendByUserIdVerifyType.Include
                        };
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
                return new VerifyFriendByUserId(
                    properties["namespaceName"].ToString(),
                    properties["targetUserId"].ToString(),
                    new Func<VerifyFriendByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFriendByUserIdVerifyType e => e,
                            string s => VerifyFriendByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFriendByUserIdVerifyType.Include
                        };
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
            return "Gs2Friend:VerifyFriendByUserId";
        }

        public static string StaticAction() {
            return "Gs2Friend:VerifyFriendByUserId";
        }
    }
}
