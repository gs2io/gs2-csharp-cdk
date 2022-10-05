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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.Ref;

namespace Gs2Cdk.Gs2Limit.Resource
{
    public class LimitModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly string _resetType;
        private readonly int? _resetDayOfMonth;
        private readonly string _resetDayOfWeek;
        private readonly int? _resetHour;

        public LimitModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                string resetType,
                int? resetDayOfMonth,
                string resetDayOfWeek,
                int? resetHour,
                string description = null,
                string metadata = null
        ): base("Limit_LimitModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._resetType = resetType;
            this._resetDayOfMonth = resetDayOfMonth;
            this._resetDayOfWeek = resetDayOfWeek;
            this._resetHour = resetHour;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Limit::LimitModelMaster";
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
            if (this._resetType != null) {
                properties["ResetType"] = this._resetType.ToString();
            }
            if (this._resetDayOfMonth != null) {
                properties["ResetDayOfMonth"] = this._resetDayOfMonth;
            }
            if (this._resetDayOfWeek != null) {
                properties["ResetDayOfWeek"] = this._resetDayOfWeek.ToString();
            }
            if (this._resetHour != null) {
                properties["ResetHour"] = this._resetHour;
            }
            return properties;
        }

        public LimitModelMasterRef Ref(
                string namespaceName
        ) {
            return new LimitModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrLimitModelId() {
            return new GetAttr(
                "Item.LimitModelId"
            );
        }
    }
}
