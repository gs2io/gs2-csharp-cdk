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
using Gs2Cdk.Gs2Exchange.Model;

namespace Gs2Cdk.Gs2Exchange.StampSheet
{
    public class UnlockIncrementalExchangeByUserId : AcquireAction {
        private string namespaceName;
        private string rateName;
        private string userId;
        private string lockTransactionId;


        public UnlockIncrementalExchangeByUserId(
            string namespaceName,
            string rateName,
            string lockTransactionId,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.rateName = rateName;
            this.lockTransactionId = lockTransactionId;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.rateName != null) {
                properties["rateName"] = this.rateName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.lockTransactionId != null) {
                properties["lockTransactionId"] = this.lockTransactionId;
            }

            return properties;
        }

        public static UnlockIncrementalExchangeByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new UnlockIncrementalExchangeByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["rateName"],
                    (string)properties["lockTransactionId"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new UnlockIncrementalExchangeByUserId(
                    properties["namespaceName"].ToString(),
                    properties["rateName"].ToString(),
                    properties["lockTransactionId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Exchange:UnlockIncrementalExchangeByUserId";
        }

        public static string StaticAction() {
            return "Gs2Exchange:UnlockIncrementalExchangeByUserId";
        }
    }
}
