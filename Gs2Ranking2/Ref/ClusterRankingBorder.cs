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
 *
 * deny overwrite
 */
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Ranking2.Model;

namespace Gs2Cdk.Gs2Ranking2.Ref
{
    public class ClusterRankingBorderRef {
        private string namespaceName;
        private string rankingName;
        private string clusterName;
        private long season;

        public ClusterRankingBorderRef(
            string namespaceName,
            string rankingName,
            string clusterName,
            long season
        ){
            this.namespaceName = namespaceName;
            this.rankingName = rankingName;
            this.clusterName = clusterName;
            this.season = season;
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "ranking2",
                    this.namespaceName,
                    "cluster",
                    this.rankingName,
                    "ranking",
                    "cluster",
                    this.clusterName,
                    this.season.ToString(),
                    "border"
                }
            )).Str(
            );
        }
    }
}
