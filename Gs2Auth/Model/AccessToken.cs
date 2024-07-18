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
using Gs2Cdk.Gs2Auth.Model;
using Gs2Cdk.Gs2Auth.Model.Options;

namespace Gs2Cdk.Gs2Auth.Model
{
    public class AccessToken {
        private string ownerId;
        private string userId;
        private string realUserId;
        private long? expire;
        private string expireString;
        private int? timeOffset;
        private string timeOffsetString;
        private string federationFromUserId;
        private string federationPolicyDocument;

        public AccessToken(
            string ownerId,
            string userId,
            string realUserId,
            long? expire,
            int? timeOffset,
            AccessTokenOptions options = null
        ){
            this.ownerId = ownerId;
            this.userId = userId;
            this.realUserId = realUserId;
            this.expire = expire;
            this.timeOffset = timeOffset;
            this.federationFromUserId = options?.federationFromUserId;
            this.federationPolicyDocument = options?.federationPolicyDocument;
        }


        public AccessToken(
            string ownerId,
            string userId,
            string realUserId,
            string expire,
            string timeOffset,
            AccessTokenOptions options = null
        ){
            this.ownerId = ownerId;
            this.userId = userId;
            this.realUserId = realUserId;
            this.expireString = expire;
            this.timeOffsetString = timeOffset;
            this.federationFromUserId = options?.federationFromUserId;
            this.federationPolicyDocument = options?.federationPolicyDocument;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.ownerId != null) {
                properties["ownerId"] = this.ownerId;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.realUserId != null) {
                properties["realUserId"] = this.realUserId;
            }
            if (this.federationFromUserId != null) {
                properties["federationFromUserId"] = this.federationFromUserId;
            }
            if (this.federationPolicyDocument != null) {
                properties["federationPolicyDocument"] = this.federationPolicyDocument;
            }
            if (this.expireString != null) {
                properties["expire"] = this.expireString;
            } else {
                if (this.expire != null) {
                    properties["expire"] = this.expire;
                }
            }
            if (this.timeOffsetString != null) {
                properties["timeOffset"] = this.timeOffsetString;
            } else {
                if (this.timeOffset != null) {
                    properties["timeOffset"] = this.timeOffset;
                }
            }

            return properties;
        }

        public static AccessToken FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AccessToken(
                (string)properties["ownerId"],
                (string)properties["userId"],
                (string)properties["realUserId"],
                new Func<long?>(() =>
                {
                    return properties["expire"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int?>(() =>
                {
                    return properties["timeOffset"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new AccessTokenOptions {
                    federationFromUserId = properties.TryGetValue("federationFromUserId", out var federationFromUserId) ? (string)federationFromUserId : null,
                    federationPolicyDocument = properties.TryGetValue("federationPolicyDocument", out var federationPolicyDocument) ? (string)federationPolicyDocument : null
                }
            );

            return model;
        }
    }
}
