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
using Gs2Cdk.Gs2Enhance.Model;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class UnleashRateEntryModel {
        private long gradeValue;
        private string gradeValueString;
        private int needCount;
        private string needCountString;

        public UnleashRateEntryModel(
            long gradeValue,
            int needCount,
            UnleashRateEntryModelOptions options = null
        ){
            this.gradeValue = gradeValue;
            this.needCount = needCount;
        }


        public UnleashRateEntryModel(
            string gradeValue,
            string needCount,
            UnleashRateEntryModelOptions options = null
        ){
            this.gradeValueString = gradeValue;
            this.needCountString = needCount;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.gradeValueString != null) {
                properties["gradeValue"] = this.gradeValueString;
            } else {
                if (this.gradeValue != null) {
                    properties["gradeValue"] = this.gradeValue;
                }
            }
            if (this.needCountString != null) {
                properties["needCount"] = this.needCountString;
            } else {
                if (this.needCount != null) {
                    properties["needCount"] = this.needCount;
                }
            }

            return properties;
        }

        public static UnleashRateEntryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashRateEntryModel(
                new Func<long>(() =>
                {
                    return properties["gradeValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["needCount"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new UnleashRateEntryModelOptions {
                }
            );

            return model;
        }
    }
}
