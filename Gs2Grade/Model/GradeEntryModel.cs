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
    public class GradeEntryModel {
        private long rankCapValue;
        private string rankCapValueString;
        private string propertyIdRegex;
        private string gradeUpPropertyIdRegex;
        private string metadata;

        public GradeEntryModel(
            long rankCapValue,
            string propertyIdRegex,
            string gradeUpPropertyIdRegex,
            GradeEntryModelOptions options = null
        ){
            this.rankCapValue = rankCapValue;
            this.propertyIdRegex = propertyIdRegex;
            this.gradeUpPropertyIdRegex = gradeUpPropertyIdRegex;
            this.metadata = options?.metadata;
        }


        public GradeEntryModel(
            string rankCapValue,
            string propertyIdRegex,
            string gradeUpPropertyIdRegex,
            GradeEntryModelOptions options = null
        ){
            this.rankCapValueString = rankCapValue;
            this.propertyIdRegex = propertyIdRegex;
            this.gradeUpPropertyIdRegex = gradeUpPropertyIdRegex;
            this.metadata = options?.metadata;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.rankCapValueString != null) {
                properties["rankCapValue"] = this.rankCapValueString;
            } else {
                if (this.rankCapValue != null) {
                    properties["rankCapValue"] = this.rankCapValue;
                }
            }
            if (this.propertyIdRegex != null) {
                properties["propertyIdRegex"] = this.propertyIdRegex;
            }
            if (this.gradeUpPropertyIdRegex != null) {
                properties["gradeUpPropertyIdRegex"] = this.gradeUpPropertyIdRegex;
            }

            return properties;
        }

        public static GradeEntryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GradeEntryModel(
                new Func<long>(() =>
                {
                    return properties["rankCapValue"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["propertyIdRegex"],
                (string)properties["gradeUpPropertyIdRegex"],
                new GradeEntryModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null
                }
            );

            return model;
        }
    }
}
