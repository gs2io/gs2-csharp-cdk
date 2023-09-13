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
    public class SignTargetVersion {
        private string region;
        private string ownerId;
        private string namespaceName;
        private string versionName;
        private Version_ version;

        public SignTargetVersion(
            string region,
            string ownerId,
            string namespaceName,
            string versionName,
            Version_ version,
            SignTargetVersionOptions options = null
        ){
            this.region = region;
            this.ownerId = ownerId;
            this.namespaceName = namespaceName;
            this.versionName = versionName;
            this.version = version;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.region != null) {
                properties["region"] = this.region;
            }
            if (this.ownerId != null) {
                properties["ownerId"] = this.ownerId;
            }
            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.versionName != null) {
                properties["versionName"] = this.versionName;
            }
            if (this.version != null) {
                properties["version"] = this.version?.Properties(
                );
            }

            return properties;
        }

        public static SignTargetVersion FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SignTargetVersion(
                (string)properties["region"],
                (string)properties["ownerId"],
                (string)properties["namespaceName"],
                (string)properties["versionName"],
                new Func<Version_>(() =>
                {
                    return properties["version"] switch {
                        Version_ m => m,
                        Dictionary<string, object> v => Version_.FromProperties(v),
                        _ => null
                    };
                })(),
                new SignTargetVersionOptions {
                }
            );

            return model;
        }
    }
}
