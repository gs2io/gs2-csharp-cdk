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
using Gs2Cdk.Gs2Lottery.Ref;
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Model.Options;

namespace Gs2Cdk.Gs2Lottery.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public TransactionSetting transactionSetting;
        public string lotteryTriggerScriptId;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Lottery_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.lotteryTriggerScriptId = options?.lotteryTriggerScriptId;
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
            return "GS2::Lottery::Namespace";
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
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.lotteryTriggerScriptId != null) {
                properties["LotteryTriggerScriptId"] = this.lotteryTriggerScriptId;
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
            LotteryModel[] lotteryModels,
            PrizeTable[] prizeTables
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                lotteryModels,
                prizeTables
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
                new Func<LotteryModel[]>(() =>
                {
                    return properties["lotteryModels"] switch {
                        LotteryModel[] v => v,
                        List<LotteryModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(LotteryModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(LotteryModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<PrizeTable[]>(() =>
                {
                    return properties["prizeTables"] switch {
                        PrizeTable[] v => v,
                        List<PrizeTable> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(PrizeTable.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(PrizeTable.FromProperties).ToArray(),
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
