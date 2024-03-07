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
using Gs2Cdk.Gs2LoginReward.Model;

namespace Gs2Cdk.Gs2LoginReward.StampSheet
{
    public class MarkReceivedByUserId : ConsumeAction {
        private string namespaceName;
        private string bonusModelName;
        private string userId;
        private int stepNumber;
        private string? stepNumberString;


        public MarkReceivedByUserId(
            string namespaceName,
            string bonusModelName,
            int stepNumber,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.bonusModelName = bonusModelName;
            this.stepNumber = stepNumber;
            this.userId = userId;
        }


        public MarkReceivedByUserId(
            string namespaceName,
            string bonusModelName,
            string stepNumber,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.bonusModelName = bonusModelName;
            this.stepNumberString = stepNumber;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.bonusModelName != null) {
                properties["bonusModelName"] = this.bonusModelName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.stepNumberString != null) {
                properties["stepNumber"] = this.stepNumberString;
            } else {
                if (this.stepNumber != null) {
                    properties["stepNumber"] = this.stepNumber;
                }
            }

            return properties;
        }

        public static MarkReceivedByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new MarkReceivedByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["bonusModelName"],
                    new Func<int>(() =>
                    {
                        return properties["stepNumber"] switch {
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
                return new MarkReceivedByUserId(
                    properties["namespaceName"].ToString(),
                    properties["bonusModelName"].ToString(),
                    properties["stepNumber"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2LoginReward:MarkReceivedByUserId";
        }

        public static string StaticAction() {
            return "Gs2LoginReward:MarkReceivedByUserId";
        }
    }
}
