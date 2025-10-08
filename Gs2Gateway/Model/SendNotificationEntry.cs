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
using Gs2Cdk.Gs2Gateway.Model;
using Gs2Cdk.Gs2Gateway.Model.Options;

namespace Gs2Cdk.Gs2Gateway.Model
{
    public class SendNotificationEntry {
        private string userId;
        private string issuer;
        private string subject;
        private string payload;
        private bool? enableTransferMobileNotification;
        private string enableTransferMobileNotificationString;
        private string sound;

        public SendNotificationEntry(
            string userId,
            string issuer,
            string subject,
            string payload,
            bool? enableTransferMobileNotification,
            SendNotificationEntryOptions options = null
        ){
            this.userId = userId;
            this.issuer = issuer;
            this.subject = subject;
            this.payload = payload;
            this.enableTransferMobileNotification = enableTransferMobileNotification;
            this.sound = options?.sound;
        }


        public SendNotificationEntry(
            string userId,
            string issuer,
            string subject,
            string payload,
            string enableTransferMobileNotification,
            SendNotificationEntryOptions options = null
        ){
            this.userId = userId;
            this.issuer = issuer;
            this.subject = subject;
            this.payload = payload;
            this.enableTransferMobileNotificationString = enableTransferMobileNotification;
            this.sound = options?.sound;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.issuer != null) {
                properties["issuer"] = this.issuer;
            }
            if (this.subject != null) {
                properties["subject"] = this.subject;
            }
            if (this.payload != null) {
                properties["payload"] = this.payload;
            }
            if (this.enableTransferMobileNotificationString != null) {
                properties["enableTransferMobileNotification"] = this.enableTransferMobileNotificationString;
            } else {
                if (this.enableTransferMobileNotification != null) {
                    properties["enableTransferMobileNotification"] = this.enableTransferMobileNotification;
                }
            }
            if (this.sound != null) {
                properties["sound"] = this.sound;
            }

            return properties;
        }

        public static SendNotificationEntry FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SendNotificationEntry(
                properties.TryGetValue("userId", out var userId) ? new Func<string>(() =>
                {
                    return (string) userId;
                })() : default,
                properties.TryGetValue("issuer", out var issuer) ? new Func<string>(() =>
                {
                    return (string) issuer;
                })() : default,
                properties.TryGetValue("subject", out var subject) ? new Func<string>(() =>
                {
                    return (string) subject;
                })() : default,
                properties.TryGetValue("payload", out var payload) ? new Func<string>(() =>
                {
                    return (string) payload;
                })() : default,
                properties.TryGetValue("enableTransferMobileNotification", out var enableTransferMobileNotification) ? new Func<bool?>(() =>
                {
                    return enableTransferMobileNotification switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new SendNotificationEntryOptions {
                    sound = properties.TryGetValue("sound", out var sound) ? (string)sound : null
                }
            );

            return model;
        }
    }
}
