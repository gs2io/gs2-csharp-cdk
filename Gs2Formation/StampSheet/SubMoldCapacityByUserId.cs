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
using Gs2Cdk.Gs2Formation.Model;

namespace Gs2Cdk.Gs2Formation.StampSheet
{
    public class SubMoldCapacityByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string moldModelName;
        private int capacity;


        public SubMoldCapacityByUserId(
            string namespaceName,
            string moldModelName,
            int capacity,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.capacity = capacity;
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
            if (this.moldModelName != null) {
                properties["moldModelName"] = this.moldModelName;
            }
            if (this.capacity != null) {
                properties["capacity"] = this.capacity;
            }

            return properties;
        }

        public static SubMoldCapacityByUserId FromProperties(Dictionary<string, object> properties) {
            return new SubMoldCapacityByUserId(
                (string)properties["namespaceName"],
                (string)properties["moldModelName"],
                new Func<int>(() =>
                {
                    return properties["capacity"] switch {
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
            return "Gs2Formation:SubMoldCapacityByUserId";
        }

        public static string StaticAction() {
            return "Gs2Formation:SubMoldCapacityByUserId";
        }
    }
}
