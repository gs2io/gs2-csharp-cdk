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
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Model.Options;

namespace Gs2Cdk.Gs2Lottery.Model
{
    public class BoxItem {
        private string prizeId;
        private int remaining;
        private string remainingString;
        private int initial;
        private string initialString;
        private AcquireAction[] acquireActions;

        public BoxItem(
            string prizeId,
            int remaining,
            int initial,
            BoxItemOptions options = null
        ){
            this.prizeId = prizeId;
            this.remaining = remaining;
            this.initial = initial;
            this.acquireActions = options?.acquireActions;
        }


        public BoxItem(
            string prizeId,
            string remaining,
            string initial,
            BoxItemOptions options = null
        ){
            this.prizeId = prizeId;
            this.remainingString = remaining;
            this.initialString = initial;
            this.acquireActions = options?.acquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.prizeId != null) {
                properties["prizeId"] = this.prizeId;
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.remainingString != null) {
                properties["remaining"] = this.remainingString;
            } else {
                if (this.remaining != null) {
                    properties["remaining"] = this.remaining;
                }
            }
            if (this.initialString != null) {
                properties["initial"] = this.initialString;
            } else {
                if (this.initial != null) {
                    properties["initial"] = this.initial;
                }
            }

            return properties;
        }

        public static BoxItem FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BoxItem(
                properties.TryGetValue("prizeId", out var prizeId) ? new Func<string>(() =>
                {
                    return (string) prizeId;
                })() : default,
                properties.TryGetValue("remaining", out var remaining) ? new Func<int>(() =>
                {
                    return remaining switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("initial", out var initial) ? new Func<int>(() =>
                {
                    return initial switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new BoxItemOptions {
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
