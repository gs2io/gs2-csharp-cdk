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
using Gs2Cdk.Gs2Lottery.Model;

namespace Gs2Cdk.Gs2Lottery.StampSheet
{
    public class DrawByUserId : AcquireAction {
        private string namespaceName;
        private string lotteryName;
        private string userId;
        private int count;
        private string? countString;
        private Config[] config;
        private string timeOffsetToken;


        public DrawByUserId(
            string namespaceName,
            string lotteryName,
            int count,
            Config[] config = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.lotteryName = lotteryName;
            this.count = count;
            this.config = config;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public DrawByUserId(
            string namespaceName,
            string lotteryName,
            string count,
            Config[] config = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.lotteryName = lotteryName;
            this.countString = count;
            this.config = config;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.lotteryName != null) {
                properties["lotteryName"] = this.lotteryName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static DrawByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DrawByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["lotteryName"],
                    new Func<int>(() =>
                    {
                        return properties["count"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<Config[]>(() =>
                    {
                        return properties.TryGetValue("config", out var config) ? config switch {
                            Dictionary<string, object>[] v => v.Select(Config.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Config.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Config.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Config).ToArray(),
                            { } v => new []{ v as Config },
                            _ => null
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
                return new DrawByUserId(
                    properties["namespaceName"].ToString(),
                    properties["lotteryName"].ToString(),
                    properties["count"].ToString(),
                    new Func<Config[]>(() =>
                    {
                        return properties.TryGetValue("config", out var config) ? config switch {
                            Dictionary<string, object>[] v => v.Select(Config.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Config.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Config.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Config).ToArray(),
                            { } v => new []{ v as Config },
                            _ => null
                        } : null;
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
            return "Gs2Lottery:DrawByUserId";
        }

        public static string StaticAction() {
            return "Gs2Lottery:DrawByUserId";
        }
    }
}
