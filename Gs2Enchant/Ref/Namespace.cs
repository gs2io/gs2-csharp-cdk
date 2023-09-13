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
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.StampSheet;

namespace Gs2Cdk.Gs2Enchant.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public BalanceParameterModelRef BalanceParameterModel(
            string parameterName
        ){
            return (new BalanceParameterModelRef(
                this.namespaceName,
                parameterName
            ));
        }

        public RarityParameterModelRef RarityParameterModel(
            string parameterName
        ){
            return (new RarityParameterModelRef(
                this.namespaceName,
                parameterName
            ));
        }

        public ReDrawBalanceParameterStatusByUserId ReDrawBalanceParameterStatus(
            string parameterName,
            string propertyId,
            string[] fixedParameterNames = null,
            string userId = "#{userId}"
        ){
            return (new ReDrawBalanceParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                fixedParameterNames,
                userId
            ));
        }

        public SetBalanceParameterStatusByUserId SetBalanceParameterStatus(
            string parameterName,
            string propertyId,
            BalanceParameterValue[] parameterValues,
            string userId = "#{userId}"
        ){
            return (new SetBalanceParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                parameterValues,
                userId
            ));
        }

        public ReDrawRarityParameterStatusByUserId ReDrawRarityParameterStatus(
            string parameterName,
            string propertyId,
            string[] fixedParameterNames = null,
            string userId = "#{userId}"
        ){
            return (new ReDrawRarityParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                fixedParameterNames,
                userId
            ));
        }

        public AddRarityParameterStatusByUserId AddRarityParameterStatus(
            string parameterName,
            string propertyId,
            int? count,
            string userId = "#{userId}"
        ){
            return (new AddRarityParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                count,
                userId
            ));
        }

        public SetRarityParameterStatusByUserId SetRarityParameterStatus(
            string parameterName,
            string propertyId,
            RarityParameterValue[] parameterValues = null,
            string userId = "#{userId}"
        ){
            return (new SetRarityParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                parameterValues,
                userId
            ));
        }

        public VerifyRarityParameterStatusByUserId VerifyRarityParameterStatus(
            string parameterName,
            string propertyId,
            string verifyType,
            string parameterValueName,
            int? parameterCount,
            string userId = "#{userId}"
        ){
            return (new VerifyRarityParameterStatusByUserId(
                namespaceName,
                parameterName,
                propertyId,
                verifyType,
                parameterValueName,
                parameterCount,
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
                    "enchant",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
