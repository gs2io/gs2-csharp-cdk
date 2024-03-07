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
using Gs2Cdk.Gs2Idle.Model;

namespace Gs2Cdk.Gs2Idle.StampSheet
{
    public class DecreaseMaximumIdleMinutesByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string categoryName;
        private int? decreaseMinutes;
        private string? decreaseMinutesString;


        public DecreaseMaximumIdleMinutesByUserId(
            string namespaceName,
            string categoryName,
            int? decreaseMinutes = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.categoryName = categoryName;
            this.decreaseMinutes = decreaseMinutes;
            this.userId = userId;
        }


        public DecreaseMaximumIdleMinutesByUserId(
            string namespaceName,
            string categoryName,
            string decreaseMinutes = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.categoryName = categoryName;
            this.decreaseMinutesString = decreaseMinutes;
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
            if (this.categoryName != null) {
                properties["categoryName"] = this.categoryName;
            }
            if (this.decreaseMinutesString != null) {
                properties["decreaseMinutes"] = this.decreaseMinutesString;
            } else {
                if (this.decreaseMinutes != null) {
                    properties["decreaseMinutes"] = this.decreaseMinutes;
                }
            }

            return properties;
        }

        public static DecreaseMaximumIdleMinutesByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DecreaseMaximumIdleMinutesByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["categoryName"],
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("decreaseMinutes", out var decreaseMinutes) ? decreaseMinutes switch {
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new DecreaseMaximumIdleMinutesByUserId(
                    properties["namespaceName"].ToString(),
                    properties["categoryName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("decreaseMinutes", out var decreaseMinutes) ? decreaseMinutes.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Idle:DecreaseMaximumIdleMinutesByUserId";
        }

        public static string StaticAction() {
            return "Gs2Idle:DecreaseMaximumIdleMinutesByUserId";
        }
    }
}
