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
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Ref;

namespace Gs2Cdk.Gs2Lottery.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly TransactionSetting _transactionSetting;
        private readonly string _lotteryTriggerScriptId;
        private readonly string _choicePrizeTableScriptId;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                TransactionSetting transactionSetting,
                string description = null,
                string lotteryTriggerScriptId = null,
                string choicePrizeTableScriptId = null,
                LogSetting logSetting = null
        ): base("Lottery_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._transactionSetting = transactionSetting;
            this._lotteryTriggerScriptId = lotteryTriggerScriptId;
            this._choicePrizeTableScriptId = choicePrizeTableScriptId;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Lottery::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._transactionSetting != null) {
                properties["TransactionSetting"] = this._transactionSetting.Properties();
            }
            if (this._lotteryTriggerScriptId != null) {
                properties["LotteryTriggerScriptId"] = this._lotteryTriggerScriptId;
            }
            if (this._choicePrizeTableScriptId != null) {
                properties["ChoicePrizeTableScriptId"] = this._choicePrizeTableScriptId;
            }
            if (this._logSetting != null) {
                properties["LogSetting"] = this._logSetting.Properties();
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }

        public Namespace MasterData(
                LotteryModel[] lotteryModels,
                PrizeTable[] prizeTables
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                lotteryModels,
                prizeTables
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
