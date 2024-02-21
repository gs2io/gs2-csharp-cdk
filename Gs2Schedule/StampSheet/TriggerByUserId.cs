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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.StampSheet.Enums;

namespace Gs2Cdk.Gs2Schedule.StampSheet
{
    public class TriggerByUserId : AcquireAction {
        private string namespaceName;
        private string triggerName;
        private string userId;
        private TriggerByUserIdTriggerStrategy? triggerStrategy;
        private int ttl;


        public TriggerByUserId(
            string namespaceName,
            string triggerName,
            TriggerByUserIdTriggerStrategy triggerStrategy,
            int ttl,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.triggerStrategy = triggerStrategy;
            this.ttl = ttl;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.triggerName != null) {
                properties["triggerName"] = this.triggerName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.triggerStrategy != null) {
                properties["triggerStrategy"] = this.triggerStrategy?.Str(
                );
            }
            if (this.ttl != null) {
                properties["ttl"] = this.ttl;
            }

            return properties;
        }

        public static TriggerByUserId FromProperties(Dictionary<string, object> properties) {
            return new TriggerByUserId(
                (string)properties["namespaceName"],
                (string)properties["triggerName"],
                new Func<TriggerByUserIdTriggerStrategy>(() =>
                {
                    return properties["triggerStrategy"] switch {
                        TriggerByUserIdTriggerStrategy e => e,
                        string s => TriggerByUserIdTriggerStrategyExt.New(s),
                        _ => TriggerByUserIdTriggerStrategy.Renew
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["ttl"] switch {
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
        }

        public override string Action() {
            return "Gs2Schedule:TriggerByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:TriggerByUserId";
        }
    }
}
