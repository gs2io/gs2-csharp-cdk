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
    public class LotteryModelRef {
        private readonly string _namespaceName;
        private readonly string _lotteryName;

        public LotteryModelRef(
                string namespaceName,
                string lotteryName
        ) {
            this._namespaceName = namespaceName;
            this._lotteryName = lotteryName;
        }

        public DrawByUserId Draw(
                int? count,
                Config[] config = null,
                string userId = "#{userId}"
        ) {
            return new DrawByUserId(
                this._namespaceName,
                this._lotteryName,
                userId,
                count,
                config
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
                    this._namespaceName,
                    "lotteryModel",
                    this._lotteryName
                }
            ).ToString();
        }
    }
}
