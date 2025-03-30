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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.StampSheet.Enums;

namespace Gs2Cdk.Gs2Stamina.StampSheet
{
    public class VerifyStaminaRecoverValueByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string staminaName;
        private VerifyStaminaRecoverValueByUserIdVerifyType? verifyType;
        private int value;
        private string valueString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyStaminaRecoverValueByUserId(
            string namespaceName,
            string staminaName,
            VerifyStaminaRecoverValueByUserIdVerifyType verifyType,
            int value,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.verifyType = verifyType;
            this.value = value;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyStaminaRecoverValueByUserId(
            string namespaceName,
            string staminaName,
            VerifyStaminaRecoverValueByUserIdVerifyType verifyType,
            string value,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.verifyType = verifyType;
            this.valueString = value;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.staminaName != null) {
                properties["staminaName"] = this.staminaName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyStaminaRecoverValueByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyStaminaRecoverValueByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["staminaName"],
                    new Func<VerifyStaminaRecoverValueByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyStaminaRecoverValueByUserIdVerifyType e => e,
                            string s => VerifyStaminaRecoverValueByUserIdVerifyTypeExt.New(s),
                            _ => VerifyStaminaRecoverValueByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<int>(() =>
                    {
                        return properties["value"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyStaminaRecoverValueByUserId(
                    properties["namespaceName"].ToString(),
                    properties["staminaName"].ToString(),
                    new Func<VerifyStaminaRecoverValueByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyStaminaRecoverValueByUserIdVerifyType e => e,
                            string s => VerifyStaminaRecoverValueByUserIdVerifyTypeExt.New(s),
                            _ => VerifyStaminaRecoverValueByUserIdVerifyType.Less
                        };
                    })(),
                    properties["value"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Stamina:VerifyStaminaRecoverValueByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:VerifyStaminaRecoverValueByUserId";
        }
    }
}
