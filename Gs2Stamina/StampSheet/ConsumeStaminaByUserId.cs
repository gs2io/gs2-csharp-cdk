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

namespace Gs2Cdk.Gs2Stamina.StampSheet
{
    public class ConsumeStaminaByUserId : ConsumeAction {
        private string namespaceName;
        private string staminaName;
        private string userId;
        private int consumeValue;
        private string? consumeValueString;
        private string timeOffsetToken;


        public ConsumeStaminaByUserId(
            string namespaceName,
            string staminaName,
            int consumeValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.consumeValue = consumeValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public ConsumeStaminaByUserId(
            string namespaceName,
            string staminaName,
            string consumeValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.consumeValueString = consumeValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.staminaName != null) {
                properties["staminaName"] = this.staminaName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.consumeValueString != null) {
                properties["consumeValue"] = this.consumeValueString;
            } else {
                if (this.consumeValue != null) {
                    properties["consumeValue"] = this.consumeValue;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static ConsumeStaminaByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new ConsumeStaminaByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["staminaName"],
                    new Func<int>(() =>
                    {
                        return properties["consumeValue"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        };
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
                return new ConsumeStaminaByUserId(
                    properties["namespaceName"].ToString(),
                    properties["staminaName"].ToString(),
                    properties["consumeValue"].ToString(),
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
            return "Gs2Stamina:ConsumeStaminaByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:ConsumeStaminaByUserId";
        }
    }
}
