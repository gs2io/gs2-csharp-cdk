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
    public class SetRecoverIntervalByUserId : AcquireAction {
        private string namespaceName;
        private string staminaName;
        private string userId;
        private int recoverIntervalMinutes;
        private string? recoverIntervalMinutesString;
        private string timeOffsetToken;


        public SetRecoverIntervalByUserId(
            string namespaceName,
            string staminaName,
            int recoverIntervalMinutes,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.recoverIntervalMinutes = recoverIntervalMinutes;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public SetRecoverIntervalByUserId(
            string namespaceName,
            string staminaName,
            string recoverIntervalMinutes,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.staminaName = staminaName;
            this.recoverIntervalMinutesString = recoverIntervalMinutes;
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
            if (this.recoverIntervalMinutesString != null) {
                properties["recoverIntervalMinutes"] = this.recoverIntervalMinutesString;
            } else {
                if (this.recoverIntervalMinutes != null) {
                    properties["recoverIntervalMinutes"] = this.recoverIntervalMinutes;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SetRecoverIntervalByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetRecoverIntervalByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["staminaName"],
                    new Func<int>(() =>
                    {
                        return properties["recoverIntervalMinutes"] switch {
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
                return new SetRecoverIntervalByUserId(
                    properties["namespaceName"].ToString(),
                    properties["staminaName"].ToString(),
                    properties["recoverIntervalMinutes"].ToString(),
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
            return "Gs2Stamina:SetRecoverIntervalByUserId";
        }

        public static string StaticAction() {
            return "Gs2Stamina:SetRecoverIntervalByUserId";
        }
    }
}
