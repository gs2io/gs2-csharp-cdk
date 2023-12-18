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
        private int count;
        private bool? paidOnly;


        public WithdrawByUserId(
            string namespaceName,
            int slot,
            int count,
            bool? paidOnly = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slot = slot;
            this.count = count;
            this.paidOnly = paidOnly;
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
            if (this.slot != null) {
                properties["slot"] = this.slot;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }
            if (this.paidOnly != null) {
                properties["paidOnly"] = this.paidOnly;
            }

            return properties;
        }

        public static WithdrawByUserId FromProperties(Dictionary<string, object> properties) {
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
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Money:WithdrawByUserId";
        }

        public static string StaticAction() {
            return "Gs2Money:WithdrawByUserId";
        }
    }
}
