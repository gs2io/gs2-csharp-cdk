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
 *
 * deny overwrite
 */
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Money2.Model;

namespace Gs2Cdk.Gs2Money2.Ref
{
    public class DailyTransactionHistoryRef {
        private string namespaceName;
        private int year;
        private int month;
        private int day;
        private string currency;

        public DailyTransactionHistoryRef(
            string namespaceName,
            int year,
            int month,
            int day,
            string currency
        ){
            this.namespaceName = namespaceName;
            this.year = year;
            this.month = month;
            this.day = day;
            this.currency = currency;
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "money2",
                    this.namespaceName,
                    "transaction",
                    "history",
                    "daily",
                    ""+this.year,
                    ""+this.month,
                    ""+this.day,
                    "currency",
                    this.currency
                }
            )).Str(
            );
        }
    }
}
