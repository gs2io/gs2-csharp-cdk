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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Ranking2.Model;
using Gs2Cdk.Gs2Ranking2.StampSheet;
using Gs2Cdk.Gs2Ranking2.StampSheet.Enums;

namespace Gs2Cdk.Gs2Ranking2.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public GlobalRankingModelRef GlobalRankingModel(
            string rankingName
        ){
            return (new GlobalRankingModelRef(
                this.namespaceName,
                rankingName
            ));
        }

        public SubscribeRankingModelRef SubscribeRankingModel(
            string rankingName
        ){
            return (new SubscribeRankingModelRef(
                this.namespaceName,
                rankingName
            ));
        }

        public ClusterRankingModelRef ClusterRankingModel(
            string rankingName
        ){
            return (new ClusterRankingModelRef(
                this.namespaceName,
                rankingName
            ));
        }

        public CreateGlobalRankingReceivedRewardByUserId CreateGlobalRankingReceivedReward(
            string rankingName,
            long? season = null,
            string userId = "#{userId}"
        ){
            return (new CreateGlobalRankingReceivedRewardByUserId(
                this.namespaceName,
                rankingName,
                season,
                userId
            ));
        }

        public CreateClusterRankingReceivedRewardByUserId CreateClusterRankingReceivedReward(
            string rankingName,
            string clusterName,
            long? season = null,
            string userId = "#{userId}"
        ){
            return (new CreateClusterRankingReceivedRewardByUserId(
                this.namespaceName,
                rankingName,
                clusterName,
                season,
                userId
            ));
        }

        public VerifyGlobalRankingScoreByUserId VerifyGlobalRankingScore(
            string rankingName,
            VerifyGlobalRankingScoreByUserIdVerifyType verifyType,
            long score,
            long? season = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string userId = "#{userId}"
        ){
            return (new VerifyGlobalRankingScoreByUserId(
                this.namespaceName,
                rankingName,
                verifyType,
                score,
                season,
                multiplyValueSpecifyingQuantity,
                userId
            ));
        }

        public VerifyClusterRankingScoreByUserId VerifyClusterRankingScore(
            string rankingName,
            string clusterName,
            VerifyClusterRankingScoreByUserIdVerifyType verifyType,
            long score,
            long? season = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string userId = "#{userId}"
        ){
            return (new VerifyClusterRankingScoreByUserId(
                this.namespaceName,
                rankingName,
                clusterName,
                verifyType,
                score,
                season,
                multiplyValueSpecifyingQuantity,
                userId
            ));
        }

        public VerifySubscribeRankingScoreByUserId VerifySubscribeRankingScore(
            string rankingName,
            VerifySubscribeRankingScoreByUserIdVerifyType verifyType,
            long score,
            long? season = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string userId = "#{userId}"
        ){
            return (new VerifySubscribeRankingScoreByUserId(
                this.namespaceName,
                rankingName,
                verifyType,
                score,
                season,
                multiplyValueSpecifyingQuantity,
                userId
            ));
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
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
