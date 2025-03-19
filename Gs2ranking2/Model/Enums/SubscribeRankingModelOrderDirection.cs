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


namespace Gs2Cdk.Gs2Ranking2.Model.Enums
{
    
    public enum SubscribeRankingModelOrderDirection {
        Asc,
        Desc
    }

    public static class SubscribeRankingModelOrderDirectionExt
    {
        public static string Str(this SubscribeRankingModelOrderDirection self) {
            switch (self) {
                case SubscribeRankingModelOrderDirection.Asc:
                    return "asc";
                case SubscribeRankingModelOrderDirection.Desc:
                    return "desc";
            }
            return "unknown";
        }

        public static SubscribeRankingModelOrderDirection New(string value) {
            switch (value) {
                case "asc":
                    return SubscribeRankingModelOrderDirection.Asc;
                case "desc":
                    return SubscribeRankingModelOrderDirection.Desc;
            }
            return SubscribeRankingModelOrderDirection.Asc;
        }
    }
}
