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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.Model.Options;

namespace Gs2Cdk.Gs2Stamina.Model
{
    public class StaminaModel {
        private string name;
        private int recoverIntervalMinutes;
        private string recoverIntervalMinutesString;
        private int? recoverValue;
        private string recoverValueString;
        private int initialCapacity;
        private string initialCapacityString;
        private bool isOverflow;
        private string isOverflowString;
        private string metadata;
        private int? maxCapacity;
        private string maxCapacityString;
        private MaxStaminaTable maxStaminaTable;
        private RecoverIntervalTable recoverIntervalTable;
        private RecoverValueTable recoverValueTable;

        public StaminaModel(
            string name,
            int recoverIntervalMinutes,
            int? recoverValue,
            int initialCapacity,
            bool isOverflow,
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


        public StaminaModel(
            string name,
            string recoverIntervalMinutes,
            string recoverValue,
            string initialCapacity,
            string isOverflow,
            StaminaModelOptions options = null
        ){
            this.name = name;
            this.recoverIntervalMinutesString = recoverIntervalMinutes;
            this.recoverValueString = recoverValue;
            this.initialCapacityString = initialCapacity;
            this.isOverflowString = isOverflow;
            this.metadata = options?.metadata;
            this.maxCapacity = options?.maxCapacity;
            this.maxCapacityString = options?.maxCapacityString;
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
            if (this.recoverIntervalMinutesString != null) {
                properties["recoverIntervalMinutes"] = this.recoverIntervalMinutesString;
            } else {
                if (this.recoverIntervalMinutes != null) {
                    properties["recoverIntervalMinutes"] = this.recoverIntervalMinutes;
                }
            }
            if (this.recoverValueString != null) {
                properties["recoverValue"] = this.recoverValueString;
            } else {
                if (this.recoverValue != null) {
                    properties["recoverValue"] = this.recoverValue;
                }
            }
            if (this.initialCapacityString != null) {
                properties["initialCapacity"] = this.initialCapacityString;
            } else {
                if (this.initialCapacity != null) {
                    properties["initialCapacity"] = this.initialCapacity;
                }
            }
            if (this.isOverflowString != null) {
                properties["isOverflow"] = this.isOverflowString;
            } else {
                if (this.isOverflow != null) {
                    properties["isOverflow"] = this.isOverflow;
                }
            }
            if (this.maxCapacityString != null) {
                properties["maxCapacity"] = this.maxCapacityString;
            } else {
                if (this.maxCapacity != null) {
                    properties["maxCapacity"] = this.maxCapacity;
                }
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

        public static StaminaModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new StaminaModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("recoverIntervalMinutes", out var recoverIntervalMinutes) ? new Func<int>(() =>
                {
                    return recoverIntervalMinutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("recoverValue", out var recoverValue) ? new Func<int?>(() =>
                {
                    return recoverValue switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("initialCapacity", out var initialCapacity) ? new Func<int>(() =>
                {
                    return initialCapacity switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("isOverflow", out var isOverflow) ? new Func<bool>(() =>
                {
                    return isOverflow switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new StaminaModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    maxCapacity = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("maxCapacity", out var maxCapacity) ? maxCapacity switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    maxStaminaTable = properties.TryGetValue("maxStaminaTable", out var maxStaminaTable) ? new Func<MaxStaminaTable>(() =>
                    {
                        return maxStaminaTable switch {
                            MaxStaminaTable v => v,
                            Dictionary<string, object> v => MaxStaminaTable.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    recoverIntervalTable = properties.TryGetValue("recoverIntervalTable", out var recoverIntervalTable) ? new Func<RecoverIntervalTable>(() =>
                    {
                        return recoverIntervalTable switch {
                            RecoverIntervalTable v => v,
                            Dictionary<string, object> v => RecoverIntervalTable.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    recoverValueTable = properties.TryGetValue("recoverValueTable", out var recoverValueTable) ? new Func<RecoverValueTable>(() =>
                    {
                        return recoverValueTable switch {
                            RecoverValueTable v => v,
                            Dictionary<string, object> v => RecoverValueTable.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
