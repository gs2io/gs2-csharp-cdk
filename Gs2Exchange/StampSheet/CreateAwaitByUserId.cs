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
using Gs2Cdk.Gs2Exchange.Model;

namespace Gs2Cdk.Gs2Exchange.StampSheet
{
    public class CreateAwaitByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string rateName;
        private int? count;
        private string? countString;
        private Config[] config;


        public CreateAwaitByUserId(
            string namespaceName,
            string rateName,
            int? count = null,
            Config[] config = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rateName = rateName;
            this.count = count;
            this.config = config;
            this.userId = userId;
        }


        public CreateAwaitByUserId(
            string namespaceName,
            string rateName,
            string count = null,
            Config[] config = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rateName = rateName;
            this.countString = count;
            this.config = config;
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
            if (this.rateName != null) {
                properties["rateName"] = this.rateName;
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

            return properties;
        }

        public static CreateAwaitByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new CreateAwaitByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["rateName"],
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        } : null;
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new CreateAwaitByUserId(
                    properties["namespaceName"].ToString(),
                    properties["rateName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count.ToString() : null;
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Exchange:CreateAwaitByUserId";
        }

        public static string StaticAction() {
            return "Gs2Exchange:CreateAwaitByUserId";
        }
    }
}
