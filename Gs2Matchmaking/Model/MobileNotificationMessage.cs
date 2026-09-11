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
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class MobileNotificationMessage {
        private string locale;
        private string title;
        private string message;

        public MobileNotificationMessage(
            MobileNotificationMessageOptions options = null
        ){
            this.locale = options?.locale;
            this.title = options?.title;
            this.message = options?.message;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.locale != null) {
                properties["locale"] = this.locale;
            }
            if (this.title != null) {
                properties["title"] = this.title;
            }
            if (this.message != null) {
                properties["message"] = this.message;
            }

            return properties;
        }

        public static MobileNotificationMessage FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MobileNotificationMessage(
                new MobileNotificationMessageOptions {
                    locale = properties.TryGetValue("locale", out var locale) ? (string)locale : null,
                    title = properties.TryGetValue("title", out var title) ? (string)title : null,
                    message = properties.TryGetValue("message", out var message) ? (string)message : null
                }
            );

            return model;
        }
    }
}
