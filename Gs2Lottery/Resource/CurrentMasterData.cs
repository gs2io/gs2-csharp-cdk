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

namespace Gs2Cdk.Gs2Lottery.Resource
{
    public class CurrentMasterData : CdkResource
    {
        private readonly string _version = "2019-02-21";
        private readonly string _namespaceName;
        private readonly LotteryModel[] _lotteryModels;
        private readonly PrizeTable[] _prizeTables;

        public CurrentMasterData(
                Stack stack,
                string namespaceName,
                LotteryModel[] lotteryModels,
                PrizeTable[] prizeTables
        ): base("Lottery_CurrentLotteryMaster_" + namespaceName) {
            this._namespaceName = namespaceName;
            this._lotteryModels = lotteryModels;
            this._prizeTables = prizeTables;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Lottery::CurrentLotteryMaster";
        }

        public override Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"NamespaceName", this._namespaceName},
                {"Settings", new Dictionary<string, object>() {
                    {"version", this._version},
                    {"lotteryModels", this._lotteryModels.Select(v => v.Properties()).ToArray()},
                    {"prizeTables", this._prizeTables.Select(v => v.Properties()).ToArray()},
                }},
            };
        }
    }
}