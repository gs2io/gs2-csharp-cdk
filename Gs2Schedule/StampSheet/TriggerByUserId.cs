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
        private int? ttl;
        private string ttlString;
        private string eventId;
        private string timeOffsetToken;


        public TriggerByUserId(
            string namespaceName,
            string triggerName,
            TriggerByUserIdTriggerStrategy triggerStrategy,
            int? ttl = null,
            string eventId = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.triggerStrategy = triggerStrategy;
            this.ttl = ttl;
            this.eventId = eventId;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public TriggerByUserId(
            string namespaceName,
            string triggerName,
            TriggerByUserIdTriggerStrategy triggerStrategy,
            string ttl = null,
            string eventId = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.triggerStrategy = triggerStrategy;
            this.ttlString = ttl;
            this.eventId = eventId;
            this.timeOffsetToken = timeOffsetToken;
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
                properties["triggerStrategy"] = this.triggerStrategy.Value.Str(
                );
            }
            if (this.ttlString != null) {
                properties["ttl"] = this.ttlString;
            } else {
                if (this.ttl != null) {
                    properties["ttl"] = this.ttl;
                }
            }
            if (this.eventId != null) {
                properties["eventId"] = this.eventId;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static TriggerByUserId FromProperties(Dictionary<string, object> properties) {
            try {
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
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("ttl", out var ttl) ? ttl switch {
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
                        return properties.TryGetValue("eventId", out var eventId) ? eventId as string : null;
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
                return new TriggerByUserId(
                    properties["namespaceName"].ToString(),
                    properties["triggerName"].ToString(),
                    new Func<TriggerByUserIdTriggerStrategy>(() =>
                    {
                        return properties["triggerStrategy"] switch {
                            TriggerByUserIdTriggerStrategy e => e,
                            string s => TriggerByUserIdTriggerStrategyExt.New(s),
                            _ => TriggerByUserIdTriggerStrategy.Renew
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("ttl", out var ttl) ? ttl.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("eventId", out var eventId) ? eventId.ToString() : null;
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
            return "Gs2Schedule:TriggerByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:TriggerByUserId";
        }
    }
}
