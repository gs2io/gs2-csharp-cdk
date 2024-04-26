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
using Gs2Cdk.Gs2Grade.Model;
using Gs2Cdk.Gs2Grade.StampSheet;
using Gs2Cdk.Gs2Grade.StampSheet.Enums;

namespace Gs2Cdk.Gs2Grade.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public GradeModelRef GradeModel(
            string gradeName
        ){
            return (new GradeModelRef(
                this.namespaceName,
                gradeName
            ));
        }

        public AddGradeByUserId AddGrade(
            string gradeName,
            string propertyId,
            long? gradeValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new AddGradeByUserId(
                this.namespaceName,
                gradeName,
                propertyId,
                gradeValue,
                timeOffsetToken,
                userId
            ));
        }

        public ApplyRankCapByUserId ApplyRankCap(
            string gradeName,
            string propertyId,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new ApplyRankCapByUserId(
                this.namespaceName,
                gradeName,
                propertyId,
                timeOffsetToken,
                userId
            ));
        }

        public MultiplyAcquireActionsByUserId MultiplyAcquireActions(
            string gradeName,
            string propertyId,
            string rateName,
            AcquireAction[] acquireActions = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new MultiplyAcquireActionsByUserId(
                this.namespaceName,
                gradeName,
                propertyId,
                rateName,
                acquireActions,
                timeOffsetToken,
                userId
            ));
        }

        public SubGradeByUserId SubGrade(
            string gradeName,
            string propertyId,
            long? gradeValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SubGradeByUserId(
                this.namespaceName,
                gradeName,
                propertyId,
                gradeValue,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyGradeByUserId VerifyGrade(
            string gradeName,
            VerifyGradeByUserIdVerifyType verifyType,
            string propertyId,
            long? gradeValue = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyGradeByUserId(
                this.namespaceName,
                gradeName,
                verifyType,
                propertyId,
                gradeValue,
                multiplyValueSpecifyingQuantity,
                timeOffsetToken,
                userId
            ));
        }

        public VerifyGradeUpMaterialByUserId VerifyGradeUpMaterial(
            string gradeName,
            VerifyGradeUpMaterialByUserIdVerifyType verifyType,
            string propertyId,
            string materialPropertyId,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new VerifyGradeUpMaterialByUserId(
                this.namespaceName,
                gradeName,
                verifyType,
                propertyId,
                materialPropertyId,
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
                    "grade",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
