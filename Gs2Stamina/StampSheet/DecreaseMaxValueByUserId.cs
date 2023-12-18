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
    public class DecreaseMaxValueByUserId : ConsumeAction {
        private string namespaceName;
        private string staminaName;
        private string userId;
        private int decreaseValue;


        public DecreaseMaxValueByUserId(
            string namespaceName,
            string staminaName,
            int decreaseValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.decreaseValue = decreaseValue;
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
            if (this.decreaseValue != null) {
                properties["decreaseValue"] = this.decreaseValue;
            }

            return properties;
        }

        public static DecreaseMaxValueByUserId FromProperties(Dictionary<string, object> properties) {
            return new DecreaseMaxValueByUserId(
                (string)properties["namespaceName"],
                (string)properties["staminaName"],
                new Func<int>(() =>
                {
                    return properties["decreaseValue"] switch {
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
        }

        public override string Action() {
            return "Gs2Stamina:DecreaseMaxValueByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:DecreaseMaxValueByUserId";
        }
    }
}
