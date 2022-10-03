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
using Gs2Cdk.Gs2Lottery.StampSheet;


namespace Gs2Cdk.Gs2Lottery.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentLotteryMasterRef CurrentLotteryMaster(
        ) {
            return new CurrentLotteryMasterRef(
                this._namespaceName
            );
        }

        public PrizeTableRef PrizeTable(
                string prizeTableName
        ) {
            return new PrizeTableRef(
                this._namespaceName,
                prizeTableName
            );
        }

        public LotteryModelRef LotteryModel(
                string lotteryName
        ) {
            return new LotteryModelRef(
                this._namespaceName,
                lotteryName
            );
        }

        public PrizeTableMasterRef PrizeTableMaster(
                string prizeTableName
        ) {
            return new PrizeTableMasterRef(
                this._namespaceName,
                prizeTableName
            );
        }

        public LotteryModelMasterRef LotteryModelMaster(
                string lotteryName
        ) {
            return new LotteryModelMasterRef(
                this._namespaceName,
                lotteryName
            );
        }

        public string Grn() {
            return new Join(
                ":",
                new string[] {
                    "grn",
                    "gs2",
                    GetAttr.Region().ToString(),
                    GetAttr.OwnerId().ToString(),
                    "lottery",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
