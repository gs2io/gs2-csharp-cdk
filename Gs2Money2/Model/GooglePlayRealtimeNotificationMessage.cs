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
using Gs2Cdk.Gs2Money2.Model;
using Gs2Cdk.Gs2Money2.Model.Options;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class GooglePlayRealtimeNotificationMessage {
        private string data;
        private string messageId;
        private string publishTime;

        public GooglePlayRealtimeNotificationMessage(
            string data,
            string messageId,
            string publishTime,
            GooglePlayRealtimeNotificationMessageOptions options = null
        ){
            this.data = data;
            this.messageId = messageId;
            this.publishTime = publishTime;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.data != null) {
                properties["data"] = this.data;
            }
            if (this.messageId != null) {
                properties["messageId"] = this.messageId;
            }
            if (this.publishTime != null) {
                properties["publishTime"] = this.publishTime;
            }

            return properties;
        }

        public static GooglePlayRealtimeNotificationMessage FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GooglePlayRealtimeNotificationMessage(
                properties.TryGetValue("data", out var data) ? new Func<string>(() =>
                {
                    return (string) data;
                })() : default,
                properties.TryGetValue("messageId", out var messageId) ? new Func<string>(() =>
                {
                    return (string) messageId;
                })() : default,
                properties.TryGetValue("publishTime", out var publishTime) ? new Func<string>(() =>
                {
                    return (string) publishTime;
                })() : default,
                new GooglePlayRealtimeNotificationMessageOptions {
                }
            );

            return model;
        }
    }
}
