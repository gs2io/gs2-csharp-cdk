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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Buff.Model;
using Gs2Cdk.Gs2Buff.Model.Enums;
using Gs2Cdk.Gs2Buff.Model.Options;

namespace Gs2Cdk.Gs2Buff.Model
{
    public class BuffTargetAction {
        private BuffTargetActionTargetActionName targetActionName;
        private string targetFieldName;
        private BuffTargetGrn[] conditionGrns;
        private float rate;

        public BuffTargetAction(
            BuffTargetActionTargetActionName targetActionName,
            string targetFieldName,
            BuffTargetGrn[] conditionGrns,
            float rate,
            BuffTargetActionOptions options = null
        ){
            this.targetActionName = targetActionName;
            this.targetFieldName = targetFieldName;
            this.conditionGrns = conditionGrns;
            this.rate = rate;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.targetActionName != null) {
                properties["targetActionName"] = this.targetActionName.Str(
                );
            }
            if (this.targetFieldName != null) {
                properties["targetFieldName"] = this.targetFieldName;
            }
            if (this.conditionGrns != null) {
                properties["conditionGrns"] = this.conditionGrns.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.rate != null) {
                properties["rate"] = this.rate;
            }

            return properties;
        }

        public static BuffTargetAction FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BuffTargetAction(
                new Func<BuffTargetActionTargetActionName>(() =>
                {
                    return properties["targetActionName"] switch {
                        BuffTargetActionTargetActionName e => e,
                        string s => BuffTargetActionTargetActionNameExt.New(s),
                        _ => BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId
                    };
                })(),
                (string)properties["targetFieldName"],
                new Func<BuffTargetGrn[]>(() =>
                {
                    return properties["conditionGrns"] switch {
                        Dictionary<string, object>[] v => v.Select(BuffTargetGrn.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ BuffTargetGrn.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(BuffTargetGrn.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as BuffTargetGrn).ToArray(),
                        { } v => new []{ v as BuffTargetGrn },
                        _ => null
                    };
                })(),
                new Func<float>(() =>
                {
                    return properties["rate"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new BuffTargetActionOptions {
                }
            );

            return model;
        }
    }
}
