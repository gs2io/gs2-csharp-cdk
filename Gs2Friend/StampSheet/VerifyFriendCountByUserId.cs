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
    public class VerifyFriendCountByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private VerifyFriendCountByUserIdVerifyType? verifyType;
        private int count;
        private string countString;
        private string timeOffsetToken;


        public VerifyFriendCountByUserId(
            string namespaceName,
            VerifyFriendCountByUserIdVerifyType verifyType,
            int count,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.verifyType = verifyType;
            this.count = count;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyFriendCountByUserId(
            string namespaceName,
            VerifyFriendCountByUserIdVerifyType verifyType,
            string count,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.verifyType = verifyType;
            this.countString = count;
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
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyFriendCountByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyFriendCountByUserId(
                    (string)properties["namespaceName"],
                    new Func<VerifyFriendCountByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFriendCountByUserIdVerifyType e => e,
                            string s => VerifyFriendCountByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFriendCountByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<int>(() =>
                    {
                        return properties["count"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
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
                return new VerifyFriendCountByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<VerifyFriendCountByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFriendCountByUserIdVerifyType e => e,
                            string s => VerifyFriendCountByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFriendCountByUserIdVerifyType.Less
                        };
                    })(),
                    properties["count"].ToString(),
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
            return "Gs2Friend:VerifyFriendCountByUserId";
        }

        public static string StaticAction() {
            return "Gs2Friend:VerifyFriendCountByUserId";
        }
    }
}
