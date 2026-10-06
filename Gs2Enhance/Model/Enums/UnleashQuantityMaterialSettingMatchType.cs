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
    
    public enum UnleashQuantityMaterialSettingMatchType {
        SameGroup,
        Specified
    }

    public static class UnleashQuantityMaterialSettingMatchTypeExt
    {
        public static string Str(this UnleashQuantityMaterialSettingMatchType self) {
            switch (self) {
                case UnleashQuantityMaterialSettingMatchType.SameGroup:
                    return "sameGroup";
                case UnleashQuantityMaterialSettingMatchType.Specified:
                    return "specified";
            }
            return "unknown";
        }

        public static UnleashQuantityMaterialSettingMatchType New(string value) {
            switch (value) {
                case "sameGroup":
                    return UnleashQuantityMaterialSettingMatchType.SameGroup;
                case "specified":
                    return UnleashQuantityMaterialSettingMatchType.Specified;
            }
            return UnleashQuantityMaterialSettingMatchType.SameGroup;
        }
    }
}
