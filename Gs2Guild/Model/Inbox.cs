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
    public class Inbox {
        private string guildName;
        private string[] fromUserIds;
        private ReceiveMemberRequest[] receiveMemberRequests;
        private long? revision;
        private string revisionString;

        public Inbox(
            string guildName,
            InboxOptions options = null
        ){
            this.guildName = guildName;
            this.fromUserIds = options?.fromUserIds;
            this.receiveMemberRequests = options?.receiveMemberRequests;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.guildName != null) {
                properties["guildName"] = this.guildName;
            }
            if (this.fromUserIds != null) {
                properties["fromUserIds"] = this.fromUserIds;
            }
            if (this.receiveMemberRequests != null) {
                properties["receiveMemberRequests"] = this.receiveMemberRequests.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static Inbox FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Inbox(
                properties.TryGetValue("guildName", out var guildName) ? new Func<string>(() =>
                {
                    return (string) guildName;
                })() : default,
                new InboxOptions {
                    fromUserIds = properties.TryGetValue("fromUserIds", out var fromUserIds) ? new Func<string[]>(() =>
                    {
                        return fromUserIds switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    receiveMemberRequests = properties.TryGetValue("receiveMemberRequests", out var receiveMemberRequests) ? new Func<ReceiveMemberRequest[]>(() =>
                    {
                        return receiveMemberRequests switch {
                            ReceiveMemberRequest[] v => v,
                            List<ReceiveMemberRequest> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ReceiveMemberRequest.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ReceiveMemberRequest.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
