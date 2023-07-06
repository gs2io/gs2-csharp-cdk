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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.StampSheet;

namespace Gs2Cdk.Gs2Formation.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public MoldModelRef MoldModel(
            string moldName
        ){
            return (new MoldModelRef(
                this.namespaceName,
                moldName
            ));
        }

        public AddMoldCapacityByUserId AddMoldCapacity(
            string moldName,
            int? capacity,
            string userId = "#{userId}"
        ){
            return (new AddMoldCapacityByUserId(
                this.namespaceName,
                moldName,
                capacity,
                userId
            ));
        }

        public SetMoldCapacityByUserId SetMoldCapacity(
            string moldName,
            int? capacity,
            string userId = "#{userId}"
        ){
            return (new SetMoldCapacityByUserId(
                this.namespaceName,
                moldName,
                capacity,
                userId
            ));
        }

        public AcquireActionsToFormProperties AcquireActionsToFormProperties(
            string moldName,
            int? index,
            AcquireAction acquireAction,
            AcquireActionConfig[] config = null,
            string userId = "#{userId}"
        ){
            return (new AcquireActionsToFormProperties(
                this.namespaceName,
                moldName,
                index,
                acquireAction,
                config,
                userId
            ));
        }

        public AcquireActionsToPropertyFormProperties AcquireActionsToPropertyFormProperties(
            string formModelName,
            string propertyId,
            AcquireAction acquireAction,
            AcquireActionConfig[] config = null,
            string userId = "#{userId}"
        ){
            return (new AcquireActionsToPropertyFormProperties(
                this.namespaceName,
                formModelName,
                propertyId,
                acquireAction,
                config,
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
                    "formation",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
