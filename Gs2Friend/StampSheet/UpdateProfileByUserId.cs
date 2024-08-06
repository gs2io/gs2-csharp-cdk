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

namespace Gs2Cdk.Gs2Friend.StampSheet
{
    public class UpdateProfileByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string publicProfile;
        private string followerProfile;
        private string friendProfile;
        private string timeOffsetToken;


        public UpdateProfileByUserId(
            string namespaceName,
            string publicProfile = null,
            string followerProfile = null,
            string friendProfile = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.publicProfile = publicProfile;
            this.followerProfile = followerProfile;
            this.friendProfile = friendProfile;
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
            if (this.publicProfile != null) {
                properties["publicProfile"] = this.publicProfile;
            }
            if (this.followerProfile != null) {
                properties["followerProfile"] = this.followerProfile;
            }
            if (this.friendProfile != null) {
                properties["friendProfile"] = this.friendProfile;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static UpdateProfileByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new UpdateProfileByUserId(
                    (string)properties["namespaceName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("publicProfile", out var publicProfile) ? publicProfile as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("followerProfile", out var followerProfile) ? followerProfile as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("friendProfile", out var friendProfile) ? friendProfile as string : null;
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
                return new UpdateProfileByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("publicProfile", out var publicProfile) ? publicProfile.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("followerProfile", out var followerProfile) ? followerProfile.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("friendProfile", out var friendProfile) ? friendProfile.ToString() : null;
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
            return "Gs2Friend:UpdateProfileByUserId";
        }

        public static string StaticAction() {
            return "Gs2Friend:UpdateProfileByUserId";
        }
    }
}
