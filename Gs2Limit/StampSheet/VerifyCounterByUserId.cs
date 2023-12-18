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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.Model.Enums;

namespace Gs2Cdk.Gs2Limit.StampSheet
{
    public class VerifyCounterByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string limitName;
        private string counterName;
        private CounterVerifyType? verifyType;
        private int? count;


        public VerifyCounterByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            CounterVerifyType verifyType,
            int? count = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.verifyType = verifyType;
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
            if (this.limitName != null) {
                properties["limitName"] = this.limitName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.count != null) {
                properties["count"] = this.count;
            }

            return properties;
        }

        public static VerifyCounterByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyCounterByUserId(
                (string)properties["namespaceName"],
                (string)properties["limitName"],
                (string)properties["counterName"],
                new Func<CounterVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        CounterVerifyType e => e,
                        string s => CounterVerifyTypeExt.New(s),
                        _ => CounterVerifyType.Less
                    };
                })(),
                new Func<int?>(() =>
                {
                    return properties.TryGetValue("count", out var count) ? count switch {
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
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Limit:VerifyCounterByUserId";
        }

        public static string StaticAction() {
            return "Gs2Limit:VerifyCounterByUserId";
        }
    }
}
