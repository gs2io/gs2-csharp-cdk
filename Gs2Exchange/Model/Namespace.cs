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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Exchange.Ref;
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Model.Options;

namespace Gs2Cdk.Gs2Exchange.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public bool? enableAwaitExchange;
        public bool? enableDirectExchange;
        public TransactionSetting transactionSetting;
        public ScriptSetting exchangeScript;
        public ScriptSetting incrementalExchangeScript;
        public ScriptSetting acquireAwaitScript;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Exchange_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.enableAwaitExchange = options?.enableAwaitExchange;
            this.enableDirectExchange = options?.enableDirectExchange;
            this.transactionSetting = options?.transactionSetting;
            this.exchangeScript = options?.exchangeScript;
            this.incrementalExchangeScript = options?.incrementalExchangeScript;
            this.acquireAwaitScript = options?.acquireAwaitScript;
            this.logSetting = options?.logSetting;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::Exchange::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.enableAwaitExchange != null) {
                properties["EnableAwaitExchange"] = this.enableAwaitExchange;
            }
            if (this.enableDirectExchange != null) {
                properties["EnableDirectExchange"] = this.enableDirectExchange;
            }
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.exchangeScript != null) {
                properties["ExchangeScript"] = this.exchangeScript?.Properties(
                );
            }
            if (this.incrementalExchangeScript != null) {
                properties["IncrementalExchangeScript"] = this.incrementalExchangeScript?.Properties(
                );
            }
            if (this.acquireAwaitScript != null) {
                properties["AcquireAwaitScript"] = this.acquireAwaitScript?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["LogSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public NamespaceRef Ref(
        ){
            return (new NamespaceRef(
                this.name
            ));
        }

        public GetAttr GetAttrNamespaceId(
        ){
            return (new GetAttr(
                this,
                "Item.NamespaceId",
                null
            ));
        }

        public Namespace MasterData(
            RateModel[] rateModels,
            IncrementalRateModel[] incrementalRateModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                rateModels,
                incrementalRateModels
            )).AddDependsOn(
                this
            );
            return this;
        }

        public Namespace MasterData(
            Dictionary<string, object> properties
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                new Func<RateModel[]>(() =>
                {
                    return properties["rateModels"] switch {
                        RateModel[] v => v,
                        List<RateModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(RateModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(RateModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<IncrementalRateModel[]>(() =>
                {
                    return properties["incrementalRateModels"] switch {
                        IncrementalRateModel[] v => v,
                        List<IncrementalRateModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(IncrementalRateModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(IncrementalRateModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })()
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
