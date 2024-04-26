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
    public class StaminaModelRef {
        private string namespaceName;
        private string staminaName;

        public StaminaModelRef(
            string namespaceName,
            string staminaName
        ){
            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
        }

        public RecoverStaminaByUserId RecoverStamina(
            int recoverValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new RecoverStaminaByUserId(
                this.namespaceName,
                this.staminaName,
                recoverValue,
                timeOffsetToken,
                userId
            ));
        }

        public RaiseMaxValueByUserId RaiseMaxValue(
            int raiseValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new RaiseMaxValueByUserId(
                this.namespaceName,
                this.staminaName,
                raiseValue,
                timeOffsetToken,
                userId
            ));
        }

        public SetMaxValueByUserId SetMaxValue(
            int maxValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetMaxValueByUserId(
                this.namespaceName,
                this.staminaName,
                maxValue,
                timeOffsetToken,
                userId
            ));
        }

        public SetRecoverIntervalByUserId SetRecoverInterval(
            int recoverIntervalMinutes,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetRecoverIntervalByUserId(
                this.namespaceName,
                this.staminaName,
                recoverIntervalMinutes,
                timeOffsetToken,
                userId
            ));
        }

        public SetRecoverValueByUserId SetRecoverValue(
            int recoverValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetRecoverValueByUserId(
                this.namespaceName,
                this.staminaName,
                recoverValue,
                timeOffsetToken,
                userId
            ));
        }

        public DecreaseMaxValueByUserId DecreaseMaxValue(
            int decreaseValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new DecreaseMaxValueByUserId(
                this.namespaceName,
                this.staminaName,
                decreaseValue,
                timeOffsetToken,
                userId
            ));
        }

        public ConsumeStaminaByUserId ConsumeStamina(
            int consumeValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ConsumeStaminaByUserId(
                this.namespaceName,
                this.staminaName,
                consumeValue,
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
                    "stamina",
                    this.namespaceName,
                    "model",
                    this.staminaName
                }
            )).Str(
            );
        }
    }
}
