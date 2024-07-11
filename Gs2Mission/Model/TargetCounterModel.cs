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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.Model.Enums;
using Gs2Cdk.Gs2Mission.Model.Options;

namespace Gs2Cdk.Gs2Mission.Model
{
    public class TargetCounterModel {
        private string counterName;
        private long value;
        private string valueString;
        private TargetCounterModelResetType? resetType;

        public TargetCounterModel(
            string counterName,
            long value,
            TargetCounterModelOptions options = null
        ){
            this.counterName = counterName;
            this.value = value;
            this.resetType = options?.resetType;
        }


        public TargetCounterModel(
            string counterName,
            string value,
            TargetCounterModelOptions options = null
        ){
            this.counterName = counterName;
            this.valueString = value;
            this.resetType = options?.resetType;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }

            return properties;
        }

        public static TargetCounterModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TargetCounterModel(
                (string)properties["counterName"],
                new Func<long>(() =>
                {
                    return properties["value"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new TargetCounterModelOptions {
                    resetType = properties.TryGetValue("resetType", out var resetType) ? TargetCounterModelResetTypeExt.New(resetType as string) : TargetCounterModelResetType.NotReset
                }
            );

            return model;
        }
    }
}
