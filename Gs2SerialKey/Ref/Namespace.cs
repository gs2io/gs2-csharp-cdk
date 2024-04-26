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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.StampSheet;

namespace Gs2Cdk.Gs2SerialKey.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public CampaignModelRef CampaignModel(
            string campaignModelName
        ){
            return (new CampaignModelRef(
                this.namespaceName,
                campaignModelName
            ));
        }

        public RevertUseByUserId RevertUse(
            string code,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new RevertUseByUserId(
                this.namespaceName,
                code,
                timeOffsetToken,
                userId
            ));
        }

        public UseByUserId Use(
            string code,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new UseByUserId(
                this.namespaceName,
                code,
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
                    "serialKey",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
