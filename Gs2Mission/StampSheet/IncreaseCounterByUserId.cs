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
using Gs2Cdk.Gs2Mission.Model;

namespace Gs2Cdk.Gs2Mission.StampSheet
{
    public class IncreaseCounterByUserId : AcquireAction {
        private string namespaceName;
        private string counterName;
        private string userId;
        private long value;
        private string? valueString;
        private string timeOffsetToken;


        public IncreaseCounterByUserId(
            string namespaceName,
            string counterName,
            long value,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.counterName = counterName;
            this.value = value;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public IncreaseCounterByUserId(
            string namespaceName,
            string counterName,
            string value,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.counterName = counterName;
            this.valueString = value;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static IncreaseCounterByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new IncreaseCounterByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["counterName"],
                    new Func<long>(() =>
                    {
                        return properties["value"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
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
                return new IncreaseCounterByUserId(
                    properties["namespaceName"].ToString(),
                    properties["counterName"].ToString(),
                    properties["value"].ToString(),
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
            return "Gs2Mission:IncreaseCounterByUserId";
        }

        public static string StaticAction() {
            return "Gs2Mission:IncreaseCounterByUserId";
        }
    }
}
