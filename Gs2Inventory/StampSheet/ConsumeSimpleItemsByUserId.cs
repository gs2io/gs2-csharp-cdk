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
    public class ConsumeSimpleItemsByUserId : ConsumeAction {
        private string namespaceName;
        private string inventoryName;
        private string userId;
        private ConsumeCount[] consumeCounts;


        public ConsumeSimpleItemsByUserId(
            string namespaceName,
            string inventoryName,
            ConsumeCount[] consumeCounts,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.consumeCounts = consumeCounts;
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
            if (this.consumeCounts != null) {
                properties["consumeCounts"] = this.consumeCounts.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static ConsumeSimpleItemsByUserId FromProperties(Dictionary<string, object> properties) {
            return new ConsumeSimpleItemsByUserId(
                (string)properties["namespaceName"],
                (string)properties["inventoryName"],
                new Func<ConsumeCount[]>(() =>
                {
                    return properties["consumeCounts"] switch {
                        Dictionary<string, object>[] v => v.Select(ConsumeCount.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ ConsumeCount.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(ConsumeCount.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as ConsumeCount).ToArray(),
                        { } v => new []{ v as ConsumeCount },
                        _ => null
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Inventory:ConsumeSimpleItemsByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:ConsumeSimpleItemsByUserId";
        }
    }
}
