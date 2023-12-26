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
using Gs2Cdk.Gs2Grade.Model;
using Gs2Cdk.Gs2Grade.Model.Options;

namespace Gs2Cdk.Gs2Grade.Model
{
    public class DefaultGradeModel {
        private string propertyIdRegex;
        private long defaultGradeValue;

        public DefaultGradeModel(
            string propertyIdRegex,
            long defaultGradeValue,
            DefaultGradeModelOptions options = null
        ){
            this.propertyIdRegex = propertyIdRegex;
            this.defaultGradeValue = defaultGradeValue;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.propertyIdRegex != null) {
                properties["propertyIdRegex"] = this.propertyIdRegex;
            }
            if (this.defaultGradeValue != null) {
                properties["defaultGradeValue"] = this.defaultGradeValue;
            }

            return properties;
        }

        public static DefaultGradeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DefaultGradeModel(
                (string)properties["propertyIdRegex"],
                new Func<long>(() =>
                {
                    return properties["defaultGradeValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new DefaultGradeModelOptions {
                }
            );

            return model;
        }
    }
}
