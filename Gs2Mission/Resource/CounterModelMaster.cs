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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Ref;

namespace Gs2Cdk.Gs2Mission.Resource
{
    public class CounterModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _metadata;
        private readonly string _description;
        private readonly CounterScopeModel[] _scopes;
        private readonly string _challengePeriodEventId;

        public CounterModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                CounterScopeModel[] scopes,
                string metadata = null,
                string description = null,
                string challengePeriodEventId = null
        ): base("Mission_CounterModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._metadata = metadata;
            this._description = description;
            this._scopes = scopes;
            this._challengePeriodEventId = challengePeriodEventId;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Mission::CounterModelMaster";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._scopes != null) {
                properties["Scopes"] = this._scopes.Select(v => v.Properties()).ToArray();
            }
            if (this._challengePeriodEventId != null) {
                properties["ChallengePeriodEventId"] = this._challengePeriodEventId;
            }
            return properties;
        }

        public CounterModelMasterRef Ref(
                string namespaceName
        ) {
            return new CounterModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrCounterId() {
            return new GetAttr(
                "Item.CounterId"
            );
        }
    }
}
