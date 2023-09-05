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
using Gs2Cdk.Gs2LoginReward.Model;
using Gs2Cdk.Gs2LoginReward.StampSheet;

namespace Gs2Cdk.Gs2LoginReward.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public BonusModelRef BonusModel(
            string bonusModelName
        ){
            return (new BonusModelRef(
                this.namespaceName,
                bonusModelName
            ));
        }

        public DeleteReceiveStatusByUserId DeleteReceiveStatus(
            string bonusModelName,
            string userId = "#{userId}"
        ){
            return (new DeleteReceiveStatusByUserId(
                this.namespaceName,
                bonusModelName,
                userId
            ));
        }

        public UnmarkReceivedByUserId UnmarkReceived(
            string bonusModelName,
            int? stepNumber,
            string userId = "#{userId}"
        ){
            return (new UnmarkReceivedByUserId(
                this.namespaceName,
                bonusModelName,
                stepNumber,
                userId
            ));
        }

        public MarkReceivedByUserId MarkReceived(
            string bonusModelName,
            int? stepNumber,
            string userId = "#{userId}"
        ){
            return (new MarkReceivedByUserId(
                this.namespaceName,
                bonusModelName,
                stepNumber,
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
                    "loginReward",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
