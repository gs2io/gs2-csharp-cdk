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
using Gs2Cdk.Gs2Ranking.Model;
using Gs2Cdk.Gs2Ranking.Model.Options;

namespace Gs2Cdk.Gs2Ranking.Model
{
    public class FixedTiming {
        private int? hour;
        private int? minute;

        public FixedTiming(
            FixedTimingOptions options = null
        ){
            this.hour = options?.hour;
            this.minute = options?.minute;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.hour != null) {
                properties["hour"] = this.hour;
            }
            if (this.minute != null) {
                properties["minute"] = this.minute;
            }

            return properties;
        }

        public static FixedTiming FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new FixedTiming(
                new FixedTimingOptions {
                    hour = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("hour", out var hour) ? hour switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    minute = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("minute", out var minute) ? minute switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
