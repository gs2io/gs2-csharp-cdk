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


namespace Gs2Cdk.Gs2Enhance.Model.Enums
{
    
    public enum UnleashIndividualMaterialSettingGradeCondition {
        Any,
        SameAsTarget,
        Equal
    }

    public static class UnleashIndividualMaterialSettingGradeConditionExt
    {
        public static string Str(this UnleashIndividualMaterialSettingGradeCondition self) {
            switch (self) {
                case UnleashIndividualMaterialSettingGradeCondition.Any:
                    return "any";
                case UnleashIndividualMaterialSettingGradeCondition.SameAsTarget:
                    return "sameAsTarget";
                case UnleashIndividualMaterialSettingGradeCondition.Equal:
                    return "equal";
            }
            return "unknown";
        }

        public static UnleashIndividualMaterialSettingGradeCondition New(string value) {
            switch (value) {
                case "any":
                    return UnleashIndividualMaterialSettingGradeCondition.Any;
                case "sameAsTarget":
                    return UnleashIndividualMaterialSettingGradeCondition.SameAsTarget;
                case "equal":
                    return UnleashIndividualMaterialSettingGradeCondition.Equal;
            }
            return UnleashIndividualMaterialSettingGradeCondition.Any;
        }
    }
}
