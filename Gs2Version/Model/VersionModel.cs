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
using Gs2Cdk.Gs2Version.Model.Enums;
using Gs2Cdk.Gs2Version.Model.Options;

namespace Gs2Cdk.Gs2Version.Model
{
    public class VersionModel {
        private string name;
        private VersionModelScope? scope;
        private VersionModelType? type;
        private string metadata;
        private Version_ currentVersion;
        private Version_ warningVersion;
        private Version_ errorVersion;
        private ScheduleVersion[] scheduleVersions;
        private bool? needSignature;
        private string signatureKeyId;

        public VersionModel(
            string name,
            VersionModelScope scope,
            VersionModelType type,
            VersionModelOptions options = null
        ){
            this.name = name;
            this.scope = scope;
            this.type = type;
            this.metadata = options?.metadata;
            this.currentVersion = options?.currentVersion;
            this.warningVersion = options?.warningVersion;
            this.errorVersion = options?.errorVersion;
            this.scheduleVersions = options?.scheduleVersions;
            this.needSignature = options?.needSignature;
            this.signatureKeyId = options?.signatureKeyId;
        }

        public static VersionModel TypeIsSimple(
            string name,
            VersionModelScope scope,
            Version_ warningVersion,
            Version_ errorVersion,
            VersionModelTypeIsSimpleOptions options = null
        ){
            return (new VersionModel(
                name,
                scope,
                VersionModelType.Simple,
                new VersionModelOptions {
                    warningVersion = warningVersion,
                    errorVersion = errorVersion,
                    metadata = options?.metadata,
                    scheduleVersions = options?.scheduleVersions,
                }
            ));
        }

        public static VersionModel TypeIsSchedule(
            string name,
            VersionModelScope scope,
            VersionModelTypeIsScheduleOptions options = null
        ){
            return (new VersionModel(
                name,
                scope,
                VersionModelType.Schedule,
                new VersionModelOptions {
                    metadata = options?.metadata,
                    scheduleVersions = options?.scheduleVersions,
                }
            ));
        }

        public static VersionModel ScopeIsPassive(
            string name,
            VersionModelType type,
            bool? needSignature,
            VersionModelScopeIsPassiveOptions options = null
        ){
            return (new VersionModel(
                name,
                VersionModelScope.Passive,
                type,
                new VersionModelOptions {
                    needSignature = needSignature,
                    metadata = options?.metadata,
                    scheduleVersions = options?.scheduleVersions,
                }
            ));
        }

        public static VersionModel ScopeIsActive(
            string name,
            VersionModelType type,
            VersionModelScopeIsActiveOptions options = null
        ){
            return (new VersionModel(
                name,
                VersionModelScope.Active,
                type,
                new VersionModelOptions {
                    metadata = options?.metadata,
                    scheduleVersions = options?.scheduleVersions,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.scope != null) {
                properties["scope"] = this.scope?.Str(
                );
            }
            if (this.type != null) {
                properties["type"] = this.type?.Str(
                );
            }
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
            if (this.scheduleVersions != null) {
                properties["scheduleVersions"] = this.scheduleVersions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.needSignature != null) {
                properties["needSignature"] = this.needSignature;
            }
            if (this.signatureKeyId != null) {
                properties["signatureKeyId"] = this.signatureKeyId;
            }

            return properties;
        }

        public static VersionModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new VersionModel(
                (string)properties["name"],
                new Func<VersionModelScope>(() =>
                {
                    return properties["scope"] switch {
                        VersionModelScope e => e,
                        string s => VersionModelScopeExt.New(s),
                        _ => VersionModelScope.Passive
                    };
                })(),
                new Func<VersionModelType>(() =>
                {
                    return properties["type"] switch {
                        VersionModelType e => e,
                        string s => VersionModelTypeExt.New(s),
                        _ => VersionModelType.Simple
                    };
                })(),
                new VersionModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    currentVersion = properties.TryGetValue("currentVersion", out var currentVersion) ? new Func<Version_>(() =>
                    {
                        return currentVersion switch {
                            Version_ v => v,
                            Dictionary<string, object> v => Version_.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    warningVersion = properties.TryGetValue("warningVersion", out var warningVersion) ? new Func<Version_>(() =>
                    {
                        return warningVersion switch {
                            Version_ v => v,
                            Dictionary<string, object> v => Version_.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    errorVersion = properties.TryGetValue("errorVersion", out var errorVersion) ? new Func<Version_>(() =>
                    {
                        return errorVersion switch {
                            Version_ v => v,
                            Dictionary<string, object> v => Version_.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    scheduleVersions = properties.TryGetValue("scheduleVersions", out var scheduleVersions) ? new Func<ScheduleVersion[]>(() =>
                    {
                        return scheduleVersions switch {
                            ScheduleVersion[] v => v,
                            List<ScheduleVersion> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ScheduleVersion.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ScheduleVersion.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    needSignature = new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("needSignature", out var needSignature) ? needSignature switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    signatureKeyId = properties.TryGetValue("signatureKeyId", out var signatureKeyId) ? (string)signatureKeyId : null
                }
            );

            return model;
        }
    }
}
