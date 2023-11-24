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
using Gs2Cdk.Gs2JobQueue.Model;
using Gs2Cdk.Gs2JobQueue.Model.Options;

namespace Gs2Cdk.Gs2JobQueue.Model
{
    public class Namespace {
        private string ownerId;
        private string name;
        private bool? enableAutoRun;
        private string description;
        private NotificationSetting runNotification;
        private NotificationSetting pushNotification;
        private LogSetting logSetting;
        private long? revision;

        public Namespace(
            string ownerId,
            string name,
            bool? enableAutoRun,
            NamespaceOptions options = null
        ){
            this.ownerId = ownerId;
            this.name = name;
            this.enableAutoRun = enableAutoRun;
            this.description = options?.description;
            this.runNotification = options?.runNotification;
            this.pushNotification = options?.pushNotification;
            this.logSetting = options?.logSetting;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.ownerId != null) {
                properties["ownerId"] = this.ownerId;
            }
            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.description != null) {
                properties["description"] = this.description;
            }
            if (this.enableAutoRun != null) {
                properties["enableAutoRun"] = this.enableAutoRun;
            }
            if (this.runNotification != null) {
                properties["runNotification"] = this.runNotification?.Properties(
                );
            }
            if (this.pushNotification != null) {
                properties["pushNotification"] = this.pushNotification?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["logSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public static Namespace FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Namespace(
                (string)properties["ownerId"],
                (string)properties["name"],
                new Func<bool?>(() =>
                {
                    return properties["enableAutoRun"] switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })(),
                new NamespaceOptions {
                    description = properties.TryGetValue("description", out var description) ? (string)description : null,
                    runNotification = properties.TryGetValue("runNotification", out var runNotification) ? new Func<NotificationSetting>(() =>
                    {
                        return runNotification switch {
                            NotificationSetting v => v,
                            Dictionary<string, object> v => NotificationSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    pushNotification = properties.TryGetValue("pushNotification", out var pushNotification) ? new Func<NotificationSetting>(() =>
                    {
                        return pushNotification switch {
                            NotificationSetting v => v,
                            Dictionary<string, object> v => NotificationSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    logSetting = properties.TryGetValue("logSetting", out var logSetting) ? new Func<LogSetting>(() =>
                    {
                        return logSetting switch {
                            LogSetting v => v,
                            Dictionary<string, object> v => LogSetting.FromProperties(v),
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
