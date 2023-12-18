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
using Gs2Cdk.Gs2Quest.Model;

namespace Gs2Cdk.Gs2Quest.StampSheet
{
    public class CreateProgressByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string questModelId;
        private bool? force;
        private Config[] config;


        public CreateProgressByUserId(
            string namespaceName,
            string questModelId,
            bool? force = null,
            Config[] config = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.questModelId = questModelId;
            this.force = force;
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
            if (this.questModelId != null) {
                properties["questModelId"] = this.questModelId;
            }
            if (this.force != null) {
                properties["force"] = this.force;
            }
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static CreateProgressByUserId FromProperties(Dictionary<string, object> properties) {
            return new CreateProgressByUserId(
                (string)properties["namespaceName"],
                (string)properties["questModelId"],
                new Func<bool?>(() =>
                {
                    return properties.TryGetValue("force", out var force) ? force switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
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
        }

        public override string Action() {
            return "Gs2Quest:CreateProgressByUserId";
        }

        public static string StaticAction() {
            return "Gs2Quest:CreateProgressByUserId";
        }
    }
}
