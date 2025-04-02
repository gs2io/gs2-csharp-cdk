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
using Gs2Cdk.Gs2Mission.Model;

namespace Gs2Cdk.Gs2Mission.StampSheet
{
    public class ResetCounterByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string counterName;
        private ScopedValue[] scopes;
        private string timeOffsetToken;


        public ResetCounterByUserId(
            string namespaceName,
            string counterName,
            ScopedValue[] scopes,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.counterName = counterName;
            this.scopes = scopes;
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
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.scopes != null) {
                properties["scopes"] = this.scopes.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static ResetCounterByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new ResetCounterByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["counterName"],
                    new Func<ScopedValue[]>(() =>
                    {
                        return properties["scopes"] switch {
                            Dictionary<string, object>[] v => v.Select(ScopedValue.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ScopedValue.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ScopedValue.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ScopedValue).ToArray(),
                            { } v => new []{ v as ScopedValue },
                            _ => null
                        };
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
                return new ResetCounterByUserId(
                    properties["namespaceName"].ToString(),
                    properties["counterName"].ToString(),
                    new Func<ScopedValue[]>(() =>
                    {
                        return properties["scopes"] switch {
                            Dictionary<string, object>[] v => v.Select(ScopedValue.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ScopedValue.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ScopedValue.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ScopedValue).ToArray(),
                            { } v => new []{ v as ScopedValue },
                            _ => null
                        };
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
            return "Gs2Mission:ResetCounterByUserId";
        }

        public static string StaticAction() {
            return "Gs2Mission:ResetCounterByUserId";
        }
    }
}
