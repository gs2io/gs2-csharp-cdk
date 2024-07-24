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
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Model.Enums;
using Gs2Cdk.Gs2Exchange.Model.Options;

namespace Gs2Cdk.Gs2Exchange.Model
{
    public class IncrementalRateModel {
        private string name;
        private ConsumeAction consumeAction;
        private IncrementalRateModelCalculateType? calculateType;
        private string exchangeCountId;
        private int? maximumExchangeCount;
        private string maximumExchangeCountString;
        private string metadata;
        private long? baseValue;
        private string baseValueString;
        private long? coefficientValue;
        private string coefficientValueString;
        private string calculateScriptId;
        private AcquireAction[] acquireActions;

        public IncrementalRateModel(
            string name,
            ConsumeAction consumeAction,
            IncrementalRateModelCalculateType calculateType,
            string exchangeCountId,
            int? maximumExchangeCount,
            IncrementalRateModelOptions options = null
        ){
            this.name = name;
            this.consumeAction = consumeAction;
            this.calculateType = calculateType;
            this.exchangeCountId = exchangeCountId;
            this.maximumExchangeCount = maximumExchangeCount;
            this.metadata = options?.metadata;
            this.baseValue = options?.baseValue;
            this.coefficientValue = options?.coefficientValue;
            this.calculateScriptId = options?.calculateScriptId;
            this.acquireActions = options?.acquireActions;
        }

        public static IncrementalRateModel CalculateTypeIsLinear(
            string name,
            ConsumeAction consumeAction,
            string exchangeCountId,
            int? maximumExchangeCount,
            long? baseValue,
            long? coefficientValue,
            IncrementalRateModelCalculateTypeIsLinearOptions options = null
        ){
            return (new IncrementalRateModel(
                name,
                consumeAction,
                IncrementalRateModelCalculateType.Linear,
                exchangeCountId,
                maximumExchangeCount,
                new IncrementalRateModelOptions {
                    baseValue = baseValue,
                    coefficientValue = coefficientValue,
                    metadata = options?.metadata,
                    acquireActions = options?.acquireActions,
                }
            ));
        }

        public static IncrementalRateModel CalculateTypeIsPower(
            string name,
            ConsumeAction consumeAction,
            string exchangeCountId,
            int? maximumExchangeCount,
            long? coefficientValue,
            IncrementalRateModelCalculateTypeIsPowerOptions options = null
        ){
            return (new IncrementalRateModel(
                name,
                consumeAction,
                IncrementalRateModelCalculateType.Power,
                exchangeCountId,
                maximumExchangeCount,
                new IncrementalRateModelOptions {
                    coefficientValue = coefficientValue,
                    metadata = options?.metadata,
                    acquireActions = options?.acquireActions,
                }
            ));
        }

        public static IncrementalRateModel CalculateTypeIsGs2Script(
            string name,
            ConsumeAction consumeAction,
            string exchangeCountId,
            int? maximumExchangeCount,
            string calculateScriptId,
            IncrementalRateModelCalculateTypeIsGs2ScriptOptions options = null
        ){
            return (new IncrementalRateModel(
                name,
                consumeAction,
                IncrementalRateModelCalculateType.Gs2Script,
                exchangeCountId,
                maximumExchangeCount,
                new IncrementalRateModelOptions {
                    calculateScriptId = calculateScriptId,
                    metadata = options?.metadata,
                    acquireActions = options?.acquireActions,
                }
            ));
        }


        public IncrementalRateModel(
            string name,
            ConsumeAction consumeAction,
            IncrementalRateModelCalculateType calculateType,
            string exchangeCountId,
            string maximumExchangeCount,
            IncrementalRateModelOptions options = null
        ){
            this.name = name;
            this.consumeAction = consumeAction;
            this.calculateType = calculateType;
            this.exchangeCountId = exchangeCountId;
            this.maximumExchangeCountString = maximumExchangeCount;
            this.metadata = options?.metadata;
            this.baseValue = options?.baseValue;
            this.baseValueString = options?.baseValueString;
            this.coefficientValue = options?.coefficientValue;
            this.coefficientValueString = options?.coefficientValueString;
            this.calculateScriptId = options?.calculateScriptId;
            this.acquireActions = options?.acquireActions;
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
            if (this.consumeAction != null) {
                properties["consumeAction"] = this.consumeAction?.Properties(
                );
            }
            if (this.calculateType != null) {
                properties["calculateType"] = this.calculateType.Value.Str(
                );
            }
            if (this.baseValueString != null) {
                properties["baseValue"] = this.baseValueString;
            } else {
                if (this.baseValue != null) {
                    properties["baseValue"] = this.baseValue;
                }
            }
            if (this.coefficientValueString != null) {
                properties["coefficientValue"] = this.coefficientValueString;
            } else {
                if (this.coefficientValue != null) {
                    properties["coefficientValue"] = this.coefficientValue;
                }
            }
            if (this.calculateScriptId != null) {
                properties["calculateScriptId"] = this.calculateScriptId;
            }
            if (this.exchangeCountId != null) {
                properties["exchangeCountId"] = this.exchangeCountId;
            }
            if (this.maximumExchangeCountString != null) {
                properties["maximumExchangeCount"] = this.maximumExchangeCountString;
            } else {
                if (this.maximumExchangeCount != null) {
                    properties["maximumExchangeCount"] = this.maximumExchangeCount;
                }
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static IncrementalRateModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new IncrementalRateModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("consumeAction", out var consumeAction) ? new Func<ConsumeAction>(() =>
                {
                    return consumeAction switch {
                        ConsumeAction v => v,
                        ConsumeAction[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => ConsumeAction.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? ConsumeAction.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("calculateType", out var calculateType) ? new Func<IncrementalRateModelCalculateType>(() =>
                {
                    return calculateType switch {
                        IncrementalRateModelCalculateType e => e,
                        string s => IncrementalRateModelCalculateTypeExt.New(s),
                        _ => IncrementalRateModelCalculateType.Linear
                    };
                })() : default,
                properties.TryGetValue("exchangeCountId", out var exchangeCountId) ? new Func<string>(() =>
                {
                    return (string) exchangeCountId;
                })() : default,
                properties.TryGetValue("maximumExchangeCount", out var maximumExchangeCount) ? new Func<int?>(() =>
                {
                    return maximumExchangeCount switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new IncrementalRateModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    baseValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("baseValue", out var baseValue) ? baseValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    coefficientValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("coefficientValue", out var coefficientValue) ? coefficientValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    calculateScriptId = properties.TryGetValue("calculateScriptId", out var calculateScriptId) ? (string)calculateScriptId : null,
                    acquireActions = properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return acquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
