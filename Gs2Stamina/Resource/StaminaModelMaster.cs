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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.Ref;

namespace Gs2Cdk.Gs2Stamina.Resource
{
    public class StaminaModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly int? _recoverIntervalMinutes;
        private readonly int? _recoverValue;
        private readonly int? _initialCapacity;
        private readonly bool? _isOverflow;
        private readonly int? _maxCapacity;
        private readonly string _maxStaminaTableName;
        private readonly string _recoverIntervalTableName;
        private readonly string _recoverValueTableName;

        public StaminaModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                int? recoverIntervalMinutes,
                int? recoverValue,
                int? initialCapacity,
                bool? isOverflow,
                int? maxCapacity,
                string description = null,
                string metadata = null,
                string maxStaminaTableName = null,
                string recoverIntervalTableName = null,
                string recoverValueTableName = null
        ): base("Stamina_StaminaModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._recoverIntervalMinutes = recoverIntervalMinutes;
            this._recoverValue = recoverValue;
            this._initialCapacity = initialCapacity;
            this._isOverflow = isOverflow;
            this._maxCapacity = maxCapacity;
            this._maxStaminaTableName = maxStaminaTableName;
            this._recoverIntervalTableName = recoverIntervalTableName;
            this._recoverValueTableName = recoverValueTableName;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Stamina::StaminaModelMaster";
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
            if (this._recoverIntervalMinutes != null) {
                properties["RecoverIntervalMinutes"] = this._recoverIntervalMinutes;
            }
            if (this._recoverValue != null) {
                properties["RecoverValue"] = this._recoverValue;
            }
            if (this._initialCapacity != null) {
                properties["InitialCapacity"] = this._initialCapacity;
            }
            if (this._isOverflow != null) {
                properties["IsOverflow"] = this._isOverflow;
            }
            if (this._maxCapacity != null) {
                properties["MaxCapacity"] = this._maxCapacity;
            }
            if (this._maxStaminaTableName != null) {
                properties["MaxStaminaTableName"] = this._maxStaminaTableName;
            }
            if (this._recoverIntervalTableName != null) {
                properties["RecoverIntervalTableName"] = this._recoverIntervalTableName;
            }
            if (this._recoverValueTableName != null) {
                properties["RecoverValueTableName"] = this._recoverValueTableName;
            }
            return properties;
        }

        public StaminaModelMasterRef Ref(
                string namespaceName
        ) {
            return new StaminaModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrStaminaModelId() {
            return new GetAttr(
                "Item.StaminaModelId"
            );
        }
    }
}
