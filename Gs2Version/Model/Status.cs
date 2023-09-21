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
    public class Status {
        private VersionModel versionModel;
        private Version_ currentVersion;

        public Status(
            VersionModel versionModel,
            StatusOptions options = null
        ){
            this.versionModel = versionModel;
            this.currentVersion = options?.currentVersion;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.versionModel != null) {
                properties["versionModel"] = this.versionModel?.Properties(
                );
            }
            if (this.currentVersion != null) {
                properties["currentVersion"] = this.currentVersion?.Properties(
                );
            }

            return properties;
        }

        public static Status FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Status(
                new Func<VersionModel>(() =>
                {
                    return properties["versionModel"] switch {
                        VersionModel v => v,
                        VersionModel[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => VersionModel.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? VersionModel.FromProperties(v.First()) : null,
                        _ => null
                    };
                })(),
                new StatusOptions {
                    currentVersion = properties.TryGetValue("currentVersion", out var currentVersion) ? new Func<Version_>(() =>
                    {
                        return currentVersion switch {
                            Version_ v => v,
                            Dictionary<string, object> v => Version_.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
