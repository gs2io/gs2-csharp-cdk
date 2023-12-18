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
using Gs2Cdk.Gs2Script.Model;
using Gs2Cdk.Gs2Script.Model.Options;

namespace Gs2Cdk.Gs2Script.Model
{
    public class Transaction {
        private ConsumeAction[] consumeActions;
        private AcquireAction[] acquireActions;

        public Transaction(
            TransactionOptions options = null
        ){
            this.consumeActions = options?.consumeActions;
            this.acquireActions = options?.acquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.consumeActions != null) {
                properties["consumeActions"] = this.consumeActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static Transaction FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Transaction(
                new TransactionOptions {
                    consumeActions = properties.TryGetValue("consumeActions", out var consumeActions) ? new Func<ConsumeAction[]>(() =>
                    {
                        return consumeActions switch {
                            ConsumeAction[] v => v,
                            List<ConsumeAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    acquireActions = properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return acquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
