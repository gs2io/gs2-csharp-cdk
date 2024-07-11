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
    public class RandomUsed {
        private long category;
        private string categoryString;
        private long used;
        private string usedString;

        public RandomUsed(
            long category,
            long used,
            RandomUsedOptions options = null
        ){
            this.category = category;
            this.used = used;
        }


        public RandomUsed(
            string category,
            string used,
            RandomUsedOptions options = null
        ){
            this.categoryString = category;
            this.usedString = used;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.categoryString != null) {
                properties["category"] = this.categoryString;
            } else {
                if (this.category != null) {
                    properties["category"] = this.category;
                }
            }
            if (this.usedString != null) {
                properties["used"] = this.usedString;
            } else {
                if (this.used != null) {
                    properties["used"] = this.used;
                }
            }

            return properties;
        }

        public static RandomUsed FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RandomUsed(
                new Func<long>(() =>
                {
                    return properties["category"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<long>(() =>
                {
                    return properties["used"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new RandomUsedOptions {
                }
            );

            return model;
        }
    }
}
