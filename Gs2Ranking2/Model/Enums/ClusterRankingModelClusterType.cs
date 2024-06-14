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
    
    public enum ClusterRankingModelClusterType {
        Raw,
        Gs2Guild_guild,
        Gs2Matchmaking_seasonGathering
    }

    public static class ClusterRankingModelClusterTypeExt
    {
        public static string Str(this ClusterRankingModelClusterType self) {
            switch (self) {
                case ClusterRankingModelClusterType.Raw:
                    return "Raw";
                case ClusterRankingModelClusterType.Gs2Guild_guild:
                    return "Gs2Guild::Guild";
                case ClusterRankingModelClusterType.Gs2Matchmaking_seasonGathering:
                    return "Gs2Matchmaking::SeasonGathering";
            }
            return "unknown";
        }

        public static ClusterRankingModelClusterType New(string value) {
            switch (value) {
                case "Raw":
                    return ClusterRankingModelClusterType.Raw;
                case "Gs2Guild::Guild":
                    return ClusterRankingModelClusterType.Gs2Guild_guild;
                case "Gs2Matchmaking::SeasonGathering":
                    return ClusterRankingModelClusterType.Gs2Matchmaking_seasonGathering;
            }
            return ClusterRankingModelClusterType.Raw;
        }
    }
}
