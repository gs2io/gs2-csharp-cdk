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
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class BanStatus {
        private string reason;
        private long releaseTimestamp;
        private string releaseTimestampString;

        public BanStatus(
            string reason,
            long releaseTimestamp,
            BanStatusOptions options = null
        ){
            this.reason = reason;
            this.releaseTimestamp = releaseTimestamp;
        }


        public BanStatus(
            string reason,
            string releaseTimestamp,
            BanStatusOptions options = null
        ){
            this.reason = reason;
            this.releaseTimestampString = releaseTimestamp;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.reason != null) {
                properties["reason"] = this.reason;
            }
            if (this.releaseTimestampString != null) {
                properties["releaseTimestamp"] = this.releaseTimestampString;
            } else {
                if (this.releaseTimestamp != null) {
                    properties["releaseTimestamp"] = this.releaseTimestamp;
                }
            }

            return properties;
        }

        public static BanStatus FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BanStatus(
                properties.TryGetValue("reason", out var reason) ? new Func<string>(() =>
                {
                    return (string) reason;
                })() : default,
                properties.TryGetValue("releaseTimestamp", out var releaseTimestamp) ? new Func<long>(() =>
                {
                    return releaseTimestamp switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })() : default,
                new BanStatusOptions {
                }
            );

            return model;
        }
    }
}
