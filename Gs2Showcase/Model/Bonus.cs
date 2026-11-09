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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.Model.Options;

namespace Gs2Cdk.Gs2Showcase.Model
{
    public class Bonus {
        private string routeKey;
        private AcquireAction[] acquireActions;

        public Bonus(
            string routeKey,
            AcquireAction[] acquireActions,
            BonusOptions options = null
        ){
            this.routeKey = routeKey;
            this.acquireActions = acquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.routeKey != null) {
                properties["routeKey"] = this.routeKey;
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static Bonus FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Bonus(
                properties.TryGetValue("routeKey", out var routeKey) ? new Func<string>(() =>
                {
                    return (string) routeKey;
                })() : default,
                properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                {
                    return acquireActions switch {
                        Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ AcquireAction.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as AcquireAction).ToArray(),
                        { } v => new []{ v as AcquireAction },
                        _ => null
                    };
                })() : null,
                new BonusOptions {
                }
            );

            return model;
        }
    }
}
