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
    public class SetMaxValueByUserId : AcquireAction {
        private string namespaceName;
        private string staminaName;
        private string userId;
        private int maxValue;
        private string maxValueString;
        private string timeOffsetToken;


        public SetMaxValueByUserId(
            string namespaceName,
            string staminaName,
            int maxValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.maxValue = maxValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public SetMaxValueByUserId(
            string namespaceName,
            string staminaName,
            string maxValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.maxValueString = maxValue;
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
            if (this.maxValueString != null) {
                properties["maxValue"] = this.maxValueString;
            } else {
                if (this.maxValue != null) {
                    properties["maxValue"] = this.maxValue;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SetMaxValueByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetMaxValueByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["staminaName"],
                    new Func<int>(() =>
                    {
                        return properties["maxValue"] switch {
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
                return new SetMaxValueByUserId(
                    properties["namespaceName"].ToString(),
                    properties["staminaName"].ToString(),
                    properties["maxValue"].ToString(),
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
            return "Gs2Stamina:SetMaxValueByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:SetMaxValueByUserId";
        }
    }
}
