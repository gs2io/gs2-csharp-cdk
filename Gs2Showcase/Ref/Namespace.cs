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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.StampSheet;

namespace Gs2Cdk.Gs2Showcase.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public DecrementPurchaseCountByUserId DecrementPurchaseCount(
            string showcaseName,
            string displayItemName,
            int count,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new DecrementPurchaseCountByUserId(
                this.namespaceName,
                showcaseName,
                displayItemName,
                count,
                timeOffsetToken,
                userId
            ));
        }

        public ForceReDrawByUserId ForceReDraw(
            string showcaseName,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ForceReDrawByUserId(
                this.namespaceName,
                showcaseName,
                timeOffsetToken,
                userId
            ));
        }

        public IncrementPurchaseCountByUserId IncrementPurchaseCount(
            string showcaseName,
            string displayItemName,
            int count,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new IncrementPurchaseCountByUserId(
                this.namespaceName,
                showcaseName,
                displayItemName,
                count,
                timeOffsetToken,
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
                    "showcase",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
