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
using Gs2Cdk.Gs2Formation.Model;

namespace Gs2Cdk.Gs2Formation.StampSheet
{
    public class AcquireActionsToFormProperties : AcquireAction {
        private string namespaceName;
        private string userId;
        private string moldModelName;
        private int index;
        private AcquireAction acquireAction;
        private AcquireActionConfig[] config;


        public AcquireActionsToFormProperties(
            string namespaceName,
            string moldModelName,
            int index,
            AcquireAction acquireAction,
            AcquireActionConfig[] config = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.index = index;
            this.acquireAction = acquireAction;
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
            if (this.moldModelName != null) {
                properties["moldModelName"] = this.moldModelName;
            }
            if (this.index != null) {
                properties["index"] = this.index;
            }
            if (this.acquireAction != null) {
                properties["acquireAction"] = this.acquireAction?.Properties(
                );
            }
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static AcquireActionsToFormProperties FromProperties(Dictionary<string, object> properties) {
            return new AcquireActionsToFormProperties(
                (string)properties["namespaceName"],
                (string)properties["moldModelName"],
                new Func<int>(() =>
                {
                    return properties["index"] switch {
                        long v => (int)v,
                        int v => (int)v,
                        float v => (int)v,
                        double v => (int)v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<AcquireAction>(() =>
                {
                    return properties["acquireAction"] switch {
                        AcquireAction v => v,
                        AcquireAction[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => AcquireAction.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? AcquireAction.FromProperties(v.First()) : null,
                        _ => null
                    };
                })(),
                new Func<AcquireActionConfig[]>(() =>
                {
                    return properties.TryGetValue("config", out var config) ? config switch {
                        Dictionary<string, object>[] v => v.Select(AcquireActionConfig.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ AcquireActionConfig.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(AcquireActionConfig.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as AcquireActionConfig).ToArray(),
                        { } v => new []{ v as AcquireActionConfig },
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
            return "Gs2Formation:AcquireActionsToFormProperties";
        }

        public static string StaticAction() {
            return "Gs2Formation:AcquireActionsToFormProperties";
        }
    }
}
