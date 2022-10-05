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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.StampSheet;


namespace Gs2Cdk.Gs2Stamina.Ref
{
    public class StaminaModelRef {
        private readonly string _namespaceName;
        private readonly string _staminaName;

        public StaminaModelRef(
                string namespaceName,
                string staminaName
        ) {
            this._namespaceName = namespaceName;
            this._staminaName = staminaName;
        }

        public RecoverStaminaByUserId RecoverStamina(
                int? recoverValue,
                string userId = "#{userId}"
        ) {
            return new RecoverStaminaByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                recoverValue: recoverValue
            );
        }

        public RaiseMaxValueByUserId RaiseMaxValue(
                int? raiseValue,
                string userId = "#{userId}"
        ) {
            return new RaiseMaxValueByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                raiseValue: raiseValue
            );
        }

        public SetMaxValueByUserId SetMaxValue(
                int? maxValue,
                string userId = "#{userId}"
        ) {
            return new SetMaxValueByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                maxValue: maxValue
            );
        }

        public SetRecoverIntervalByUserId SetRecoverInterval(
                int? recoverIntervalMinutes,
                string userId = "#{userId}"
        ) {
            return new SetRecoverIntervalByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                recoverIntervalMinutes: recoverIntervalMinutes
            );
        }

        public SetRecoverValueByUserId SetRecoverValue(
                int? recoverValue,
                string userId = "#{userId}"
        ) {
            return new SetRecoverValueByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                recoverValue: recoverValue
            );
        }

        public ConsumeStaminaByUserId ConsumeStamina(
                int? consumeValue,
                string userId = "#{userId}"
        ) {
            return new ConsumeStaminaByUserId(
                namespaceName: this._namespaceName,
                staminaName: this._staminaName,
                userId: userId,
                consumeValue: consumeValue
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
                    "stamina",
                    this._namespaceName,
                    "model",
                    this._staminaName
                }
            ).ToString();
        }
    }
}
