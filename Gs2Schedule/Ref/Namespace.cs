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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.StampSheet;

namespace Gs2Cdk.Gs2Schedule.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public TriggerByUserId Trigger(
            string triggerName,
            string triggerStrategy,
            int ttl,
            string userId = "#{userId}"
        ){
            return (new TriggerByUserId(
                namespaceName,
                triggerName,
                triggerStrategy,
                ttl,
                userId
            ));
        }

        public DeleteTriggerByUserId DeleteTrigger(
            string triggerName,
            string userId = "#{userId}"
        ){
            return (new DeleteTriggerByUserId(
                namespaceName,
                triggerName,
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
                    "schedule",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
