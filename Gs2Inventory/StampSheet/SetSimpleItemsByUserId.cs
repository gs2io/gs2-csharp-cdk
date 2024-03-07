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
using Gs2Cdk.Gs2Inventory.Model;

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class SetSimpleItemsByUserId : AcquireAction {
        private string namespaceName;
        private string inventoryName;
        private string userId;
        private HeldCount[] counts;


        public SetSimpleItemsByUserId(
            string namespaceName,
            string inventoryName,
            HeldCount[] counts,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.counts = counts;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.inventoryName != null) {
                properties["inventoryName"] = this.inventoryName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.counts != null) {
                properties["counts"] = this.counts.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static SetSimpleItemsByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetSimpleItemsByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    new Func<HeldCount[]>(() =>
                    {
                        return properties["counts"] switch {
                            Dictionary<string, object>[] v => v.Select(HeldCount.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ HeldCount.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(HeldCount.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as HeldCount).ToArray(),
                            { } v => new []{ v as HeldCount },
                            _ => null
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new SetSimpleItemsByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    new Func<HeldCount[]>(() =>
                    {
                        return properties["counts"] switch {
                            Dictionary<string, object>[] v => v.Select(HeldCount.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ HeldCount.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(HeldCount.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as HeldCount).ToArray(),
                            { } v => new []{ v as HeldCount },
                            _ => null
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Inventory:SetSimpleItemsByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:SetSimpleItemsByUserId";
        }
    }
}
