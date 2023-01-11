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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.Model.Options;

namespace Gs2Cdk.Gs2Stamina.Model
{
    public class StaminaModel {
        private string name;
        private int? recoverIntervalMinutes;
        private int? recoverValue;
        private int? initialCapacity;
        private bool? isOverflow;
        private string metadata;
        private int? maxCapacity;
        private MaxStaminaTable maxStaminaTable;
        private RecoverIntervalTable recoverIntervalTable;
        private RecoverValueTable recoverValueTable;

        public StaminaModel(
            string name,
            int? recoverIntervalMinutes,
            int? recoverValue,
            int? initialCapacity,
            bool? isOverflow,
            StaminaModelOptions options = null
        ){
            this.name = name;
            this.recoverIntervalMinutes = recoverIntervalMinutes;
            this.recoverValue = recoverValue;
            this.initialCapacity = initialCapacity;
            this.isOverflow = isOverflow;
            this.metadata = options?.metadata;
            this.maxCapacity = options?.maxCapacity;
            this.maxStaminaTable = options?.maxStaminaTable;
            this.recoverIntervalTable = options?.recoverIntervalTable;
            this.recoverValueTable = options?.recoverValueTable;
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
            if (this.recoverIntervalMinutes != null) {
                properties["recoverIntervalMinutes"] = this.recoverIntervalMinutes;
            }
            if (this.recoverValue != null) {
                properties["recoverValue"] = this.recoverValue;
            }
            if (this.initialCapacity != null) {
                properties["initialCapacity"] = this.initialCapacity;
            }
            if (this.isOverflow != null) {
                properties["isOverflow"] = this.isOverflow;
            }
            if (this.maxCapacity != null) {
                properties["maxCapacity"] = this.maxCapacity;
            }
            if (this.maxStaminaTable != null) {
                properties["maxStaminaTable"] = this.maxStaminaTable?.Properties(
                );
            }
            if (this.recoverIntervalTable != null) {
                properties["recoverIntervalTable"] = this.recoverIntervalTable?.Properties(
                );
            }
            if (this.recoverValueTable != null) {
                properties["recoverValueTable"] = this.recoverValueTable?.Properties(
                );
            }

            return properties;
        }
    }
}
