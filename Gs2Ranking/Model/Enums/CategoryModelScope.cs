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


namespace Gs2Cdk.Gs2Ranking.Model.Enums
{
    
    public enum CategoryModelScope {
        Global,
        Scoped
    }

    public static class CategoryModelScopeExt
    {
        public static string Str(this CategoryModelScope self) {
            switch (self) {
                case CategoryModelScope.Global:
                    return "global";
                case CategoryModelScope.Scoped:
                    return "scoped";
            }
            return "unknown";
        }

        public static CategoryModelScope New(string value) {
            switch (value) {
                case "global":
                    return CategoryModelScope.Global;
                case "scoped":
                    return CategoryModelScope.Scoped;
            }
            return CategoryModelScope.Global;
        }
    }
}
