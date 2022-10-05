/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Ref;

namespace Gs2Cdk.Gs2Version.Resource
{
    public class VersionModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly Version_ _warningVersion;
        private readonly Version_ _errorVersion;
        private readonly string _scope;
        private readonly Version_ _currentVersion;
        private readonly bool? _needSignature;
        private readonly string _signatureKeyId;

        public VersionModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                Version_ warningVersion,
                Version_ errorVersion,
                string scope,
                Version_ currentVersion,
                bool? needSignature,
                string signatureKeyId,
                string description = null,
                string metadata = null
        ): base("Version_VersionModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._warningVersion = warningVersion;
            this._errorVersion = errorVersion;
            this._scope = scope;
            this._currentVersion = currentVersion;
            this._needSignature = needSignature;
            this._signatureKeyId = signatureKeyId;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Version::VersionModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._warningVersion != null) {
                properties["WarningVersion"] = this._warningVersion.Properties();
            }
            if (this._errorVersion != null) {
                properties["ErrorVersion"] = this._errorVersion.Properties();
            }
            if (this._scope != null) {
                properties["Scope"] = this._scope.ToString();
            }
            if (this._currentVersion != null) {
                properties["CurrentVersion"] = this._currentVersion.Properties();
            }
            if (this._needSignature != null) {
                properties["NeedSignature"] = this._needSignature;
            }
            if (this._signatureKeyId != null) {
                properties["SignatureKeyId"] = this._signatureKeyId;
            }
            return properties;
        }

        public VersionModelMasterRef Ref(
                string namespaceName
        ) {
            return new VersionModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrVersionModelId() {
            return new GetAttr(
                "Item.VersionModelId"
            );
        }
    }
}
