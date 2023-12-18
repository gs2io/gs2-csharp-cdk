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
    public class CreateProgressByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string rateName;
        private string targetItemSetId;
        private Material[] materials;
        private bool? force;


        public CreateProgressByUserId(
            string namespaceName,
            string rateName,
            string targetItemSetId,
            Material[] materials = null,
            bool? force = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rateName = rateName;
            this.targetItemSetId = targetItemSetId;
            this.materials = materials;
            this.force = force;
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
            if (this.targetItemSetId != null) {
                properties["targetItemSetId"] = this.targetItemSetId;
            }
            if (this.materials != null) {
                properties["materials"] = this.materials.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.force != null) {
                properties["force"] = this.force;
            }

            return properties;
        }

        public static CreateProgressByUserId FromProperties(Dictionary<string, object> properties) {
            return new CreateProgressByUserId(
                (string)properties["namespaceName"],
                (string)properties["rateName"],
                (string)properties["targetItemSetId"],
                new Func<Material[]>(() =>
                {
                    return properties.TryGetValue("materials", out var materials) ? materials switch {
                        Dictionary<string, object>[] v => v.Select(Material.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ Material.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(Material.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as Material).ToArray(),
                        { } v => new []{ v as Material },
                        _ => null
                    } : null;
                })(),
                new Func<bool?>(() =>
                {
                    return properties.TryGetValue("force", out var force) ? force switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    } : null;
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Enhance:CreateProgressByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enhance:CreateProgressByUserId";
        }
    }
}
