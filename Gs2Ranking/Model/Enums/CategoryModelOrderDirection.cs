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
    
    public enum CategoryModelOrderDirection {
        Asc,
        Desc
    }

    public static class CategoryModelOrderDirectionExt
    {
        public static string Str(this CategoryModelOrderDirection self) {
            switch (self) {
                case CategoryModelOrderDirection.Asc:
                    return "asc";
                case CategoryModelOrderDirection.Desc:
                    return "desc";
            }
            return "unknown";
        }

        public static CategoryModelOrderDirection New(string value) {
            switch (value) {
                case "asc":
                    return CategoryModelOrderDirection.Asc;
                case "desc":
                    return CategoryModelOrderDirection.Desc;
            }
            return CategoryModelOrderDirection.Asc;
        }
    }
}
