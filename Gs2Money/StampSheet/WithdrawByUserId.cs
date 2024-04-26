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
using Gs2Cdk.Gs2Money.Model;

namespace Gs2Cdk.Gs2Money.StampSheet
{
    public class WithdrawByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private int slot;
        private string? slotString;
        private int count;
        private string? countString;
        private bool? paidOnly;
        private string? paidOnlyString;
        private string timeOffsetToken;


        public WithdrawByUserId(
            string namespaceName,
            int slot,
            int count,
            bool? paidOnly = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slot = slot;
            this.count = count;
            this.paidOnly = paidOnly;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public WithdrawByUserId(
            string namespaceName,
            string slot,
            string count,
            string paidOnly = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slotString = slot;
            this.countString = count;
            this.paidOnlyString = paidOnly;
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
            if (this.slotString != null) {
                properties["slot"] = this.slotString;
            } else {
                if (this.slot != null) {
                    properties["slot"] = this.slot;
                }
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }
            if (this.paidOnlyString != null) {
                properties["paidOnly"] = this.paidOnlyString;
            } else {
                if (this.paidOnly != null) {
                    properties["paidOnly"] = this.paidOnly;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static WithdrawByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new WithdrawByUserId(
                    (string)properties["namespaceName"],
                    new Func<int>(() =>
                    {
                        return properties["slot"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        };
                    })(),
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
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("paidOnly", out var paidOnly) ? paidOnly switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
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
                return new WithdrawByUserId(
                    properties["namespaceName"].ToString(),
                    properties["slot"].ToString(),
                    properties["count"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("paidOnly", out var paidOnly) ? paidOnly.ToString() : null;
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
            return "Gs2Money:WithdrawByUserId";
        }

        public static string StaticAction() {
            return "Gs2Money:WithdrawByUserId";
        }
    }
}
