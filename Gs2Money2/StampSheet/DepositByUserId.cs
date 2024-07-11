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
using Gs2Cdk.Gs2Money2.Model;

namespace Gs2Cdk.Gs2Money2.StampSheet
{
    public class DepositByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private int slot;
        private string slotString;
        private DepositTransaction[] depositTransactions;
        private string timeOffsetToken;


        public DepositByUserId(
            string namespaceName,
            int slot,
            DepositTransaction[] depositTransactions,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slot = slot;
            this.depositTransactions = depositTransactions;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public DepositByUserId(
            string namespaceName,
            string slot,
            DepositTransaction[] depositTransactions,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slotString = slot;
            this.depositTransactions = depositTransactions;
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
            if (this.depositTransactions != null) {
                properties["depositTransactions"] = this.depositTransactions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static DepositByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DepositByUserId(
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
                    new Func<DepositTransaction[]>(() =>
                    {
                        return properties["depositTransactions"] switch {
                            Dictionary<string, object>[] v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ DepositTransaction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as DepositTransaction).ToArray(),
                            { } v => new []{ v as DepositTransaction },
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
                return new DepositByUserId(
                    properties["namespaceName"].ToString(),
                    properties["slot"].ToString(),
                    new Func<DepositTransaction[]>(() =>
                    {
                        return properties["depositTransactions"] switch {
                            Dictionary<string, object>[] v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ DepositTransaction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(DepositTransaction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as DepositTransaction).ToArray(),
                            { } v => new []{ v as DepositTransaction },
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
            return "Gs2Money2:DepositByUserId";
        }

        public static string StaticAction() {
            return "Gs2Money2:DepositByUserId";
        }
    }
}
