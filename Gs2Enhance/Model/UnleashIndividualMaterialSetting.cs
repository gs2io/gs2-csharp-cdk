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
using Gs2Cdk.Gs2Enhance.Model.Enums;
using Gs2Cdk.Gs2Enhance.Model.Options;

namespace Gs2Cdk.Gs2Enhance.Model
{
    public class UnleashIndividualMaterialSetting {
        private UnleashIndividualMaterialSettingMatchType? matchType;
        private UnleashIndividualMaterialSettingGradeCondition? gradeCondition;
        private int count;
        private string countString;
        private long? gradeValue;
        private string gradeValueString;

        public UnleashIndividualMaterialSetting(
            UnleashIndividualMaterialSettingMatchType matchType,
            UnleashIndividualMaterialSettingGradeCondition gradeCondition,
            int count,
            UnleashIndividualMaterialSettingOptions options = null
        ){
            this.matchType = matchType;
            this.gradeCondition = gradeCondition;
            this.count = count;
            this.gradeValue = options?.gradeValue;
        }

        public static UnleashIndividualMaterialSetting GradeConditionIsAny(
            UnleashIndividualMaterialSettingMatchType matchType,
            int count,
            UnleashIndividualMaterialSettingGradeConditionIsAnyOptions options = null
        ){
            return (new UnleashIndividualMaterialSetting(
                matchType,
                UnleashIndividualMaterialSettingGradeCondition.Any,
                count,
                new UnleashIndividualMaterialSettingOptions {
                }
            ));
        }

        public static UnleashIndividualMaterialSetting GradeConditionIsSameAsTarget(
            UnleashIndividualMaterialSettingMatchType matchType,
            int count,
            UnleashIndividualMaterialSettingGradeConditionIsSameAsTargetOptions options = null
        ){
            return (new UnleashIndividualMaterialSetting(
                matchType,
                UnleashIndividualMaterialSettingGradeCondition.SameAsTarget,
                count,
                new UnleashIndividualMaterialSettingOptions {
                }
            ));
        }

        public static UnleashIndividualMaterialSetting GradeConditionIsEqual(
            UnleashIndividualMaterialSettingMatchType matchType,
            int count,
            long? gradeValue,
            UnleashIndividualMaterialSettingGradeConditionIsEqualOptions options = null
        ){
            return (new UnleashIndividualMaterialSetting(
                matchType,
                UnleashIndividualMaterialSettingGradeCondition.Equal,
                count,
                new UnleashIndividualMaterialSettingOptions {
                    gradeValue = gradeValue,
                }
            ));
        }


        public UnleashIndividualMaterialSetting(
            UnleashIndividualMaterialSettingMatchType matchType,
            UnleashIndividualMaterialSettingGradeCondition gradeCondition,
            string count,
            UnleashIndividualMaterialSettingOptions options = null
        ){
            this.matchType = matchType;
            this.gradeCondition = gradeCondition;
            this.countString = count;
            this.gradeValue = options?.gradeValue;
            this.gradeValueString = options?.gradeValueString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.matchType != null) {
                properties["matchType"] = this.matchType.Value.Str(
                );
            }
            if (this.gradeCondition != null) {
                properties["gradeCondition"] = this.gradeCondition.Value.Str(
                );
            }
            if (this.gradeValueString != null) {
                properties["gradeValue"] = this.gradeValueString;
            } else {
                if (this.gradeValue != null) {
                    properties["gradeValue"] = this.gradeValue;
                }
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }

            return properties;
        }

        public static UnleashIndividualMaterialSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UnleashIndividualMaterialSetting(
                properties.TryGetValue("matchType", out var matchType) ? new Func<UnleashIndividualMaterialSettingMatchType>(() =>
                {
                    return matchType switch {
                        UnleashIndividualMaterialSettingMatchType e => e,
                        string s => UnleashIndividualMaterialSettingMatchTypeExt.New(s),
                        _ => UnleashIndividualMaterialSettingMatchType.SameItem
                    };
                })() : default,
                properties.TryGetValue("gradeCondition", out var gradeCondition) ? new Func<UnleashIndividualMaterialSettingGradeCondition>(() =>
                {
                    return gradeCondition switch {
                        UnleashIndividualMaterialSettingGradeCondition e => e,
                        string s => UnleashIndividualMaterialSettingGradeConditionExt.New(s),
                        _ => UnleashIndividualMaterialSettingGradeCondition.Any
                    };
                })() : default,
                properties.TryGetValue("count", out var count) ? new Func<int>(() =>
                {
                    return count switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new UnleashIndividualMaterialSettingOptions {
                    gradeValue = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("gradeValue", out var gradeValue) ? gradeValue switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
