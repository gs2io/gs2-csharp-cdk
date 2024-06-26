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
using Gs2Cdk.Gs2Enhance.Model;

namespace Gs2Cdk.Gs2Enhance.StampSheet
{
    public class DirectEnhanceByUserId : AcquireAction {
        private string namespaceName;
        private string rateName;
        private string userId;
        private string targetItemSetId;
        private Material[] materials;
        private Config[] config;
        private string timeOffsetToken;


        public DirectEnhanceByUserId(
            string namespaceName,
            string rateName,
            string targetItemSetId,
            Material[] materials,
            Config[] config = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rateName = rateName;
            this.targetItemSetId = targetItemSetId;
            this.materials = materials;
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
            if (this.rateName != null) {
                properties["rateName"] = this.rateName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.targetItemSetId != null) {
                properties["targetItemSetId"] = this.targetItemSetId;
            }
            if (this.materials != null) {
                properties["materials"] = this.materials.Select(v => v?.Properties(
                        )).ToList();
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

        public static DirectEnhanceByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DirectEnhanceByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["rateName"],
                    (string)properties["targetItemSetId"],
                    new Func<Material[]>(() =>
                    {
                        return properties["materials"] switch {
                            Dictionary<string, object>[] v => v.Select(Material.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Material.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Material.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Material).ToArray(),
                            { } v => new []{ v as Material },
                            _ => null
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
                return new DirectEnhanceByUserId(
                    properties["namespaceName"].ToString(),
                    properties["rateName"].ToString(),
                    properties["targetItemSetId"].ToString(),
                    new Func<Material[]>(() =>
                    {
                        return properties["materials"] switch {
                            Dictionary<string, object>[] v => v.Select(Material.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Material.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Material.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Material).ToArray(),
                            { } v => new []{ v as Material },
                            _ => null
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
            return "Gs2Enhance:DirectEnhanceByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enhance:DirectEnhanceByUserId";
        }
    }
}
