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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Money.Model;
using Gs2Cdk.Gs2Money.StampSheet;

namespace Gs2Cdk.Gs2Money.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public DepositByUserId Deposit(
            int? slot,
            float? price,
            int? count,
            string userId = "#{userId}"
        ){
            return (new DepositByUserId(
                this.namespaceName,
                slot,
                price,
                count,
                userId
            ));
        }

        public RevertRecordReceipt RevertRecordReceipt(
            string receipt,
            string userId = "#{userId}"
        ){
            return (new RevertRecordReceipt(
                this.namespaceName,
                receipt,
                userId
            ));
        }

        public WithdrawByUserId Withdraw(
            int? slot,
            int? count,
            bool? paidOnly,
            string userId = "#{userId}"
        ){
            return (new WithdrawByUserId(
                this.namespaceName,
                slot,
                count,
                paidOnly,
                userId
            ));
        }

        public RecordReceipt RecordReceipt(
            string contentsId,
            string receipt,
            string userId = "#{userId}"
        ){
            return (new RecordReceipt(
                this.namespaceName,
                contentsId,
                receipt,
                userId
            ));
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
                    "money",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
