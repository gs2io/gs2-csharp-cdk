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
using Gs2Cdk.Gs2Inbox.Model;

namespace Gs2Cdk.Gs2Inbox.StampSheet
{
    public class SendMessageByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string metadata;
        private AcquireAction[] readAcquireActions;
        private long? expiresAt;
        private string? expiresAtString;
        private TimeSpan_ expiresTimeSpan;
        private string timeOffsetToken;


        public SendMessageByUserId(
            string namespaceName,
            string metadata,
            AcquireAction[] readAcquireActions = null,
            long? expiresAt = null,
            TimeSpan_ expiresTimeSpan = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.metadata = metadata;
            this.readAcquireActions = readAcquireActions;
            this.expiresAt = expiresAt;
            this.expiresTimeSpan = expiresTimeSpan;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public SendMessageByUserId(
            string namespaceName,
            string metadata,
            AcquireAction[] readAcquireActions = null,
            string expiresAt = null,
            TimeSpan_ expiresTimeSpan = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.metadata = metadata;
            this.readAcquireActions = readAcquireActions;
            this.expiresAtString = expiresAt;
            this.expiresTimeSpan = expiresTimeSpan;
            this.timeOffsetToken = timeOffsetToken;
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
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.readAcquireActions != null) {
                properties["readAcquireActions"] = this.readAcquireActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.expiresAtString != null) {
                properties["expiresAt"] = this.expiresAtString;
            } else {
                if (this.expiresAt != null) {
                    properties["expiresAt"] = this.expiresAt;
                }
            }
            if (this.expiresTimeSpan != null) {
                properties["expiresTimeSpan"] = this.expiresTimeSpan?.Properties(
                );
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SendMessageByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SendMessageByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["metadata"],
                    new Func<AcquireAction[]>(() =>
                    {
                        return properties.TryGetValue("readAcquireActions", out var readAcquireActions) ? readAcquireActions switch {
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ AcquireAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as AcquireAction).ToArray(),
                            { } v => new []{ v as AcquireAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("expiresAt", out var expiresAt) ? expiresAt switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<TimeSpan_>(() =>
                    {
                        return properties.TryGetValue("expiresTimeSpan", out var expiresTimeSpan) ? expiresTimeSpan switch {
                            TimeSpan_ v => v,
                            TimeSpan_[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => TimeSpan_.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? TimeSpan_.FromProperties(v.First()) : null,
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
                return new SendMessageByUserId(
                    properties["namespaceName"].ToString(),
                    properties["metadata"].ToString(),
                    new Func<AcquireAction[]>(() =>
                    {
                        return properties.TryGetValue("readAcquireActions", out var readAcquireActions) ? readAcquireActions switch {
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ AcquireAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as AcquireAction).ToArray(),
                            { } v => new []{ v as AcquireAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("expiresAt", out var expiresAt) ? expiresAt.ToString() : null;
                    })(),
                    new Func<TimeSpan_>(() =>
                    {
                        return properties.TryGetValue("expiresTimeSpan", out var expiresTimeSpan) ? expiresTimeSpan switch {
                            TimeSpan_ v => v,
                            TimeSpan_[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => TimeSpan_.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? TimeSpan_.FromProperties(v.First()) : null,
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
            return "Gs2Inbox:SendMessageByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inbox:SendMessageByUserId";
        }
    }
}
