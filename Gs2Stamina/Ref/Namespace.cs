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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.StampSheet;

namespace Gs2Cdk.Gs2Stamina.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public StaminaModelRef StaminaModel(
            string staminaName
        ){
            return (new StaminaModelRef(
                this.namespaceName,
                staminaName
            ));
        }

        public RecoverStaminaByUserId RecoverStamina(
            string staminaName,
            int? recoverValue,
            string userId = "#{userId}"
        ){
            return (new RecoverStaminaByUserId(
                this.namespaceName,
                staminaName,
                recoverValue,
                userId
            ));
        }

        public RaiseMaxValueByUserId RaiseMaxValue(
            string staminaName,
            int? raiseValue,
            string userId = "#{userId}"
        ){
            return (new RaiseMaxValueByUserId(
                this.namespaceName,
                staminaName,
                raiseValue,
                userId
            ));
        }

        public SetMaxValueByUserId SetMaxValue(
            string staminaName,
            int? maxValue,
            string userId = "#{userId}"
        ){
            return (new SetMaxValueByUserId(
                this.namespaceName,
                staminaName,
                maxValue,
                userId
            ));
        }

        public SetRecoverIntervalByUserId SetRecoverInterval(
            string staminaName,
            int? recoverIntervalMinutes,
            string userId = "#{userId}"
        ){
            return (new SetRecoverIntervalByUserId(
                this.namespaceName,
                staminaName,
                recoverIntervalMinutes,
                userId
            ));
        }

        public SetRecoverValueByUserId SetRecoverValue(
            string staminaName,
            int? recoverValue,
            string userId = "#{userId}"
        ){
            return (new SetRecoverValueByUserId(
                this.namespaceName,
                staminaName,
                recoverValue,
                userId
            ));
        }

        public ConsumeStaminaByUserId ConsumeStamina(
            string staminaName,
            int? consumeValue,
            string userId = "#{userId}"
        ){
            return (new ConsumeStaminaByUserId(
                this.namespaceName,
                staminaName,
                consumeValue,
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
                    "stamina",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
