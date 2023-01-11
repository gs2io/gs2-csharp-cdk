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
        private Version_ warningVersion;
        private Version_ errorVersion;
        private VersionModelScope? scope;
        private string metadata;
        private Version_ currentVersion;
        private bool? needSignature;
        private string signatureKeyId;

        public VersionModel(
            string name,
            Version_ warningVersion,
            Version_ errorVersion,
            VersionModelScope scope,
            VersionModelOptions options = null
        ){
            this.name = name;
            this.warningVersion = warningVersion;
            this.errorVersion = errorVersion;
            this.scope = scope;
            this.metadata = options?.metadata;
            this.currentVersion = options?.currentVersion;
            this.needSignature = options?.needSignature;
            this.signatureKeyId = options?.signatureKeyId;
        }

        public static VersionModel ScopeIsPassive(
            string name,
            Version_ warningVersion,
            Version_ errorVersion,
            bool? needSignature,
            VersionModelScopeIsPassiveOptions options = null
        ){
            return (new VersionModel(
                name,
                warningVersion,
                errorVersion,
                VersionModelScope.Passive,
                new VersionModelOptions {
                    needSignature = needSignature,
                    metadata = options?.metadata,
                }
            ));
        }

        public static VersionModel ScopeIsActive(
            string name,
            Version_ warningVersion,
            Version_ errorVersion,
            Version_ currentVersion,
            VersionModelScopeIsActiveOptions options = null
        ){
            return (new VersionModel(
                name,
                warningVersion,
                errorVersion,
                VersionModelScope.Active,
                new VersionModelOptions {
                    currentVersion = currentVersion,
                    metadata = options?.metadata,
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
            if (this.warningVersion != null) {
                properties["warningVersion"] = this.warningVersion?.Properties(
                );
            }
            if (this.errorVersion != null) {
                properties["errorVersion"] = this.errorVersion?.Properties(
                );
            }
            if (this.scope != null) {
                properties["scope"] = this.scope?.Str(
                );
            }
            if (this.currentVersion != null) {
                properties["currentVersion"] = this.currentVersion?.Properties(
                );
            }
            if (this.needSignature != null) {
                properties["needSignature"] = this.needSignature;
            }
            if (this.signatureKeyId != null) {
                properties["signatureKeyId"] = this.signatureKeyId;
            }

            return properties;
        }
    }
}
