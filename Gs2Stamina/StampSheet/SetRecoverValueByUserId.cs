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
    public class SetRecoverValueByUserId : AcquireAction {
        private string namespaceName;
        private string staminaName;
        private string userId;
        private int recoverValue;
        private string? recoverValueString;


        public SetRecoverValueByUserId(
            string namespaceName,
            string staminaName,
            int recoverValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.recoverValue = recoverValue;
            this.userId = userId;
        }


        public SetRecoverValueByUserId(
            string namespaceName,
            string staminaName,
            string recoverValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.recoverValueString = recoverValue;
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
            if (this.recoverValueString != null) {
                properties["recoverValue"] = this.recoverValueString;
            } else {
                if (this.recoverValue != null) {
                    properties["recoverValue"] = this.recoverValue;
                }
            }

            return properties;
        }

        public static SetRecoverValueByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetRecoverValueByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["staminaName"],
                    new Func<int>(() =>
                    {
                        return properties["recoverValue"] switch {
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new SetRecoverValueByUserId(
                    properties["namespaceName"].ToString(),
                    properties["staminaName"].ToString(),
                    properties["recoverValue"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Stamina:SetRecoverValueByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:SetRecoverValueByUserId";
        }
    }
}
