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
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.Model.Options;

namespace Gs2Cdk.Gs2Enchant.Model
{
    public class RarityParameterValue {
        private string name;
        private string resourceName;
        private long resourceValue;
        private string resourceValueString;

        public RarityParameterValue(
            string name,
            string resourceName,
            long resourceValue,
            RarityParameterValueOptions options = null
        ){
            this.name = name;
            this.resourceName = resourceName;
            this.resourceValue = resourceValue;
        }


        public RarityParameterValue(
            string name,
            string resourceName,
            string resourceValue,
            RarityParameterValueOptions options = null
        ){
            this.name = name;
            this.resourceName = resourceName;
            this.resourceValueString = resourceValue;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.resourceName != null) {
                properties["resourceName"] = this.resourceName;
            }
            if (this.resourceValueString != null) {
                properties["resourceValue"] = this.resourceValueString;
            } else {
                if (this.resourceValue != null) {
                    properties["resourceValue"] = this.resourceValue;
                }
            }

            return properties;
        }

        public static RarityParameterValue FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RarityParameterValue(
                (string)properties["name"],
                (string)properties["resourceName"],
                new Func<long>(() =>
                {
                    return properties["resourceValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new RarityParameterValueOptions {
                }
            );

            return model;
        }
    }
}
