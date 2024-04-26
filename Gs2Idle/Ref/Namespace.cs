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
using Gs2Cdk.Gs2Idle.Model;
using Gs2Cdk.Gs2Idle.StampSheet;

namespace Gs2Cdk.Gs2Idle.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public CategoryModelRef CategoryModel(
            string categoryName
        ){
            return (new CategoryModelRef(
                this.namespaceName,
                categoryName
            ));
        }

        public IncreaseMaximumIdleMinutesByUserId IncreaseMaximumIdleMinutes(
            string categoryName,
            int? increaseMinutes = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new IncreaseMaximumIdleMinutesByUserId(
                this.namespaceName,
                categoryName,
                increaseMinutes,
                timeOffsetToken,
                userId
            ));
        }

        public SetMaximumIdleMinutesByUserId SetMaximumIdleMinutes(
            string categoryName,
            int? maximumIdleMinutes = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new SetMaximumIdleMinutesByUserId(
                this.namespaceName,
                categoryName,
                maximumIdleMinutes,
                timeOffsetToken,
                userId
            ));
        }

        public DecreaseMaximumIdleMinutesByUserId DecreaseMaximumIdleMinutes(
            string categoryName,
            int? decreaseMinutes = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){
            return (new DecreaseMaximumIdleMinutesByUserId(
                this.namespaceName,
                categoryName,
                decreaseMinutes,
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
                    "idle",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
