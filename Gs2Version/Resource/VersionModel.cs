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

    public static class VersionModelScopeExt
    {
        public static string ToString(this VersionModel.Scope self)
        {
            switch (self) {
                case VersionModel.Scope.Passive:
                    return "passive";
                case VersionModel.Scope.Active:
                    return "active";
            }
            return "unknown";
        }
    }

    public class VersionModel {

        public enum Scope
        {
            Passive,
            Active
        }
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly Version_ _warningVersion;
	    private readonly Version_ _errorVersion;
	    private readonly Scope _scope;
	    private readonly Version_ _currentVersion;
	    private readonly bool? _needSignature;
	    private readonly string _signatureKeyId;

        public VersionModel(
                string name,
                Version_ warningVersion,
                Version_ errorVersion,
                Scope scope,
                string metadata = null,
                Version_ currentVersion = null,
                bool? needSignature = null,
                string signatureKeyId = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._warningVersion = warningVersion;
            this._errorVersion = errorVersion;
            this._scope = scope;
            this._currentVersion = currentVersion;
            this._needSignature = needSignature;
            this._signatureKeyId = signatureKeyId;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
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

        public VersionModelRef Ref(
                string namespaceName
        )
        {
            return new VersionModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
