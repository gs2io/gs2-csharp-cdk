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
using Gs2Cdk.Gs2Chat.Model;
using Gs2Cdk.Gs2Chat.Model.Options;

namespace Gs2Cdk.Gs2Chat.Model
{
    public class NotificationType {
        private int? category;
        private string categoryString;
        private bool? enableTransferMobilePushNotification;
        private string enableTransferMobilePushNotificationString;

        public NotificationType(
            int? category,
            bool? enableTransferMobilePushNotification,
            NotificationTypeOptions options = null
        ){
            this.category = category;
            this.enableTransferMobilePushNotification = enableTransferMobilePushNotification;
        }


        public NotificationType(
            string category,
            string enableTransferMobilePushNotification,
            NotificationTypeOptions options = null
        ){
            this.categoryString = category;
            this.enableTransferMobilePushNotificationString = enableTransferMobilePushNotification;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.categoryString != null) {
                properties["category"] = this.categoryString;
            } else {
                if (this.category != null) {
                    properties["category"] = this.category;
                }
            }
            if (this.enableTransferMobilePushNotificationString != null) {
                properties["enableTransferMobilePushNotification"] = this.enableTransferMobilePushNotificationString;
            } else {
                if (this.enableTransferMobilePushNotification != null) {
                    properties["enableTransferMobilePushNotification"] = this.enableTransferMobilePushNotification;
                }
            }

            return properties;
        }

        public static NotificationType FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new NotificationType(
                properties.TryGetValue("category", out var category) ? new Func<int?>(() =>
                {
                    return category switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("enableTransferMobilePushNotification", out var enableTransferMobilePushNotification) ? new Func<bool?>(() =>
                {
                    return enableTransferMobilePushNotification switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new NotificationTypeOptions {
                }
            );

            return model;
        }
    }
}
