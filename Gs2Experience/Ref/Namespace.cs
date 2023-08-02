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
            long? experienceValue,
            string userId = "#{userId}"
        ){
            return (new AddExperienceByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                experienceValue,
                userId
            ));
        }

        public AddRankCapByUserId AddRankCap(
            string experienceName,
            string propertyId,
            long? rankCapValue,
            string userId = "#{userId}"
        ){
            return (new AddRankCapByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rankCapValue,
                userId
            ));
        }

        public SetRankCapByUserId SetRankCap(
            string experienceName,
            string propertyId,
            long? rankCapValue,
            string userId = "#{userId}"
        ){
            return (new SetRankCapByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rankCapValue,
                userId
            ));
        }

        public MultiplyAcquireActionsByUserId MultiplyAcquireActions(
            string experienceName,
            string propertyId,
            string rateName,
            AcquireAction[] acquireActions = null,
            string userId = "#{userId}"
        ){
            return (new MultiplyAcquireActionsByUserId(
                this.namespaceName,
                experienceName,
                propertyId,
                rateName,
                acquireActions,
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
