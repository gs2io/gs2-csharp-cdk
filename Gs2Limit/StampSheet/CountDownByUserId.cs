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
using Gs2Cdk.Gs2Limit.Model;

namespace Gs2Cdk.Gs2Limit.StampSheet
{
    public class CountDownByUserId : AcquireAction {
        private string namespaceName;
        private string limitName;
        private string counterName;
        private string userId;
        private int? countDownValue;
        private string? countDownValueString;
        private string timeOffsetToken;


        public CountDownByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            int? countDownValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.countDownValue = countDownValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public CountDownByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            string countDownValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.countDownValueString = countDownValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.limitName != null) {
                properties["limitName"] = this.limitName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.countDownValueString != null) {
                properties["countDownValue"] = this.countDownValueString;
            } else {
                if (this.countDownValue != null) {
                    properties["countDownValue"] = this.countDownValue;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static CountDownByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new CountDownByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["limitName"],
                    (string)properties["counterName"],
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("countDownValue", out var countDownValue) ? countDownValue switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
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
                return new CountDownByUserId(
                    properties["namespaceName"].ToString(),
                    properties["limitName"].ToString(),
                    properties["counterName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("countDownValue", out var countDownValue) ? countDownValue.ToString() : null;
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
            return "Gs2Limit:CountDownByUserId";
        }

        public static string StaticAction() {
            return "Gs2Limit:CountDownByUserId";
        }
    }
}
