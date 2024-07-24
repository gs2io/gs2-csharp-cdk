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
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Model.Options;

namespace Gs2Cdk.Gs2Version.Model
{
    public class ScheduleVersion {
        private Version_ currentVersion;
        private Version_ warningVersion;
        private Version_ errorVersion;
        private string scheduleEventId;

        public ScheduleVersion(
            Version_ currentVersion,
            Version_ warningVersion,
            Version_ errorVersion,
            ScheduleVersionOptions options = null
        ){
            this.currentVersion = currentVersion;
            this.warningVersion = warningVersion;
            this.errorVersion = errorVersion;
            this.scheduleEventId = options?.scheduleEventId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.currentVersion != null) {
                properties["currentVersion"] = this.currentVersion?.Properties(
                );
            }
            if (this.warningVersion != null) {
                properties["warningVersion"] = this.warningVersion?.Properties(
                );
            }
            if (this.errorVersion != null) {
                properties["errorVersion"] = this.errorVersion?.Properties(
                );
            }
            if (this.scheduleEventId != null) {
                properties["scheduleEventId"] = this.scheduleEventId;
            }

            return properties;
        }

        public static ScheduleVersion FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ScheduleVersion(
                properties.TryGetValue("currentVersion", out var currentVersion) ? new Func<Version_>(() =>
                {
                    return currentVersion switch {
                        Version_ v => v,
                        Version_[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Version_.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Version_.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("warningVersion", out var warningVersion) ? new Func<Version_>(() =>
                {
                    return warningVersion switch {
                        Version_ v => v,
                        Version_[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Version_.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Version_.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("errorVersion", out var errorVersion) ? new Func<Version_>(() =>
                {
                    return errorVersion switch {
                        Version_ v => v,
                        Version_[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Version_.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Version_.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                new ScheduleVersionOptions {
                    scheduleEventId = properties.TryGetValue("scheduleEventId", out var scheduleEventId) ? (string)scheduleEventId : null
                }
            );

            return model;
        }
    }
}
