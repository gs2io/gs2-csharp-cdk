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

    public class StaminaModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly int? _recoverIntervalMinutes;
	    private readonly int? _recoverValue;
	    private readonly int? _initialCapacity;
	    private readonly bool? _isOverflow;
	    private readonly int? _maxCapacity;
	    private readonly MaxStaminaTable _maxStaminaTable;
	    private readonly RecoverIntervalTable _recoverIntervalTable;
	    private readonly RecoverValueTable _recoverValueTable;

        public StaminaModel(
                string name,
                int? recoverIntervalMinutes,
                int? recoverValue,
                int? initialCapacity,
                bool? isOverflow,
                string metadata = null,
                int? maxCapacity = null,
                MaxStaminaTable maxStaminaTable = null,
                RecoverIntervalTable recoverIntervalTable = null,
                RecoverValueTable recoverValueTable = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._recoverIntervalMinutes = recoverIntervalMinutes;
            this._recoverValue = recoverValue;
            this._initialCapacity = initialCapacity;
            this._isOverflow = isOverflow;
            this._maxCapacity = maxCapacity;
            this._maxStaminaTable = maxStaminaTable;
            this._recoverIntervalTable = recoverIntervalTable;
            this._recoverValueTable = recoverValueTable;
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
            if (this._maxStaminaTable != null) {
                properties["MaxStaminaTable"] = this._maxStaminaTable.Properties();
            }
            if (this._recoverIntervalTable != null) {
                properties["RecoverIntervalTable"] = this._recoverIntervalTable.Properties();
            }
            if (this._recoverValueTable != null) {
                properties["RecoverValueTable"] = this._recoverValueTable.Properties();
            }
            return properties;
        }

        public StaminaModelRef Ref(
                string namespaceName
        )
        {
            return new StaminaModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
