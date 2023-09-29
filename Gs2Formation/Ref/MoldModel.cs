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
    public class MoldModelRef {
        private string namespaceName;
        private string moldModelName;

        public MoldModelRef(
            string namespaceName,
            string moldModelName
        ){
            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
        }

        public FormModelRef FormModel(
        ){
            return (new FormModelRef(
                this.namespaceName,
                this.moldModelName
            ));
        }

        public AddMoldCapacityByUserId AddMoldCapacity(
            int capacity,
            string userId = "#{userId}"
        ){
            return (new AddMoldCapacityByUserId(
                namespaceName,
                moldModelName,
                capacity,
                userId
            ));
        }

        public SetMoldCapacityByUserId SetMoldCapacity(
            int capacity,
            string userId = "#{userId}"
        ){
            return (new SetMoldCapacityByUserId(
                namespaceName,
                moldModelName,
                capacity,
                userId
            ));
        }

        public AcquireActionsToFormProperties AcquireActionsToFormProperties(
            int index,
            AcquireAction acquireAction,
            AcquireActionConfig[] config = null,
            string userId = "#{userId}"
        ){
            return (new AcquireActionsToFormProperties(
                namespaceName,
                moldModelName,
                index,
                acquireAction,
                config,
                userId
            ));
        }

        public SubMoldCapacityByUserId SubMoldCapacity(
            int capacity,
            string userId = "#{userId}"
        ){
            return (new SubMoldCapacityByUserId(
                namespaceName,
                moldModelName,
                capacity,
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
                    this.namespaceName,
                    "model",
                    "mold",
                    this.moldModelName
                }
            )).Str(
            );
        }
    }
}
