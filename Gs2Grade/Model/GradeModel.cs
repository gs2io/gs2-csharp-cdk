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
    public class GradeModel {
        private string name;
        private string experienceModelId;
        private GradeEntryModel[] gradeEntries;
        private string metadata;
        private DefaultGradeModel[] defaultGrades;
        private AcquireActionRate[] acquireActionRates;

        public GradeModel(
            string name,
            string experienceModelId,
            GradeEntryModel[] gradeEntries,
            GradeModelOptions options = null
        ){
            this.name = name;
            this.experienceModelId = experienceModelId;
            this.gradeEntries = gradeEntries;
            this.metadata = options?.metadata;
            this.defaultGrades = options?.defaultGrades;
            this.acquireActionRates = options?.acquireActionRates;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.defaultGrades != null) {
                properties["defaultGrades"] = this.defaultGrades.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.experienceModelId != null) {
                properties["experienceModelId"] = this.experienceModelId;
            }
            if (this.gradeEntries != null) {
                properties["gradeEntries"] = this.gradeEntries.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.acquireActionRates != null) {
                properties["acquireActionRates"] = this.acquireActionRates.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static GradeModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GradeModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("experienceModelId", out var experienceModelId) ? new Func<string>(() =>
                {
                    return (string) experienceModelId;
                })() : default,
                properties.TryGetValue("gradeEntries", out var gradeEntries) ? new Func<GradeEntryModel[]>(() =>
                {
                    return gradeEntries switch {
                        Dictionary<string, object>[] v => v.Select(GradeEntryModel.FromProperties).ToArray(),
                        Dictionary<string, object> v => new []{ GradeEntryModel.FromProperties(v) },
                        List<Dictionary<string, object>> v => v.Select(GradeEntryModel.FromProperties).ToArray(),
                        object[] v => v.Select(v2 => v2 as GradeEntryModel).ToArray(),
                        { } v => new []{ v as GradeEntryModel },
                        _ => null
                    };
                })() : null,
                new GradeModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    defaultGrades = properties.TryGetValue("defaultGrades", out var defaultGrades) ? new Func<DefaultGradeModel[]>(() =>
                    {
                        return defaultGrades switch {
                            DefaultGradeModel[] v => v,
                            List<DefaultGradeModel> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(DefaultGradeModel.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(DefaultGradeModel.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    acquireActionRates = properties.TryGetValue("acquireActionRates", out var acquireActionRates) ? new Func<AcquireActionRate[]>(() =>
                    {
                        return acquireActionRates switch {
                            AcquireActionRate[] v => v,
                            List<AcquireActionRate> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireActionRate.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireActionRate.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
