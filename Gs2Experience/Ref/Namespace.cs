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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.StampSheet;
using Gs2Cdk.Gs2Experience.StampSheet.Enums;

namespace Gs2Cdk.Gs2Experience.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public ExperienceModelRef ExperienceModel(
            string experienceName
        ){
            return (new ExperienceModelRef(
                this.namespaceName,
                experienceName
            ));
        }

        public AddExperienceByUserId AddExperience(
            string experienceName,
            string propertyId,
            long? experienceValue = null,
            bool? truncateExperienceWhenRankUp = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AddExperienceByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                experienceValue,
                truncateExperienceWhenRankUp,
                timeOffsetToken,
                userId
            ));
        }

        public SetExperienceByUserId SetExperience(
            string experienceName,
            string propertyId,
            long? experienceValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetExperienceByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                experienceValue,
                timeOffsetToken,
                userId
            ));
        }

        public AddRankCapByUserId AddRankCap(
            string experienceName,
            string propertyId,
            long rankCapValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AddRankCapByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rankCapValue,
                timeOffsetToken,
                userId
            ));
        }

        public SetRankCapByUserId SetRankCap(
            string experienceName,
            string propertyId,
            long rankCapValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetRankCapByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rankCapValue,
                timeOffsetToken,
                userId
            ));
        }

        public MultiplyAcquireActionsByUserId MultiplyAcquireActions(
            string experienceName,
            string propertyId,
            string rateName,
            AcquireAction[] acquireActions = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new MultiplyAcquireActionsByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rateName,
                acquireActions,
                timeOffsetToken,
                userId
            ));
        }

        public SubExperienceByUserId SubExperience(
            string experienceName,
            string propertyId,
            long? experienceValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SubExperienceByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                experienceValue,
                timeOffsetToken,
                userId
            ));
        }

        public SubRankCapByUserId SubRankCap(
            string experienceName,
            string propertyId,
            long rankCapValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SubRankCapByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rankCapValue,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyRankByUserId VerifyRank(
            string experienceName,
            VerifyRankByUserIdVerifyType verifyType,
            string propertyId,
            long? rankValue = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyRankByUserId(
                this.namespaceName,
                experienceName,
                verifyType,
                propertyId,
                rankValue,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyRankCapByUserId VerifyRankCap(
            string experienceName,
            VerifyRankCapByUserIdVerifyType verifyType,
            string propertyId,
            long rankCapValue,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyRankCapByUserId(
                this.namespaceName,
                experienceName,
                verifyType,
                propertyId,
                rankCapValue,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
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
                    "experience",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
