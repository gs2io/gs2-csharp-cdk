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
    public class LotteryModelMaster : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _description;
        private readonly string _metadata;
        private readonly string _mode;
        private readonly string _method;
        private readonly string _prizeTableName;
        private readonly string _choicePrizeTableScriptId;

        public LotteryModelMaster(
                Stack stack,
                string namespaceName,
                string name,
                string mode,
                string method,
                string prizeTableName,
                string choicePrizeTableScriptId,
                string description = null,
                string metadata = null
        ): base("Lottery_LotteryModelMaster_" + name) {
            this._stack = stack;
            this._namespaceName = namespaceName;
            this._name = name;
            this._description = description;
            this._metadata = metadata;
            this._mode = mode;
            this._method = method;
            this._prizeTableName = prizeTableName;
            this._choicePrizeTableScriptId = choicePrizeTableScriptId;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Lottery::LotteryModelMaster";
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
            if (this._mode != null) {
                properties["Mode"] = this._mode.ToString();
            }
            if (this._method != null) {
                properties["Method"] = this._method.ToString();
            }
            if (this._prizeTableName != null) {
                properties["PrizeTableName"] = this._prizeTableName;
            }
            if (this._choicePrizeTableScriptId != null) {
                properties["ChoicePrizeTableScriptId"] = this._choicePrizeTableScriptId;
            }
            return properties;
        }

        public LotteryModelMasterRef Ref(
                string namespaceName
        ) {
            return new LotteryModelMasterRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrLotteryModelId() {
            return new GetAttr(
                "Item.LotteryModelId"
            );
        }
    }
}
