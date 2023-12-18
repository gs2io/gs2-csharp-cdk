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
    public class DepositByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private int slot;
        private float price;
        private int count;


        public DepositByUserId(
            string namespaceName,
            int slot,
            float price,
            int count,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.slot = slot;
            this.price = price;
            this.count = count;
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
            if (this.price != null) {
                properties["price"] = this.price;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }

            return properties;
        }

        public static DepositByUserId FromProperties(Dictionary<string, object> properties) {
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
                new Func<float>(() =>
                {
                    return properties["price"] switch {
                        long v => (float)v,
                        int v => (float)v,
                        float v => (float)v,
                        double v => (float)v,
                        string v => float.Parse(v),
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
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Money:DepositByUserId";
        }

        public static string StaticAction() {
            return "Gs2Money:DepositByUserId";
        }
    }
}
