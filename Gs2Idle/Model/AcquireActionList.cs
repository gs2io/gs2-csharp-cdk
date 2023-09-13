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
using Gs2Cdk.Gs2Idle.Model;
using Gs2Cdk.Gs2Idle.Model.Options;

namespace Gs2Cdk.Gs2Idle.Model
{
    public class AcquireActionList {
        private AcquireAction[] acquireActions;

        public AcquireActionList(
            AcquireActionListOptions options = null
        ){
            this.acquireActions = options?.acquireActions;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static AcquireActionList FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AcquireActionList(
                new AcquireActionListOptions {
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
