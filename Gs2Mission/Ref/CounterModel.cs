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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.StampSheet;

namespace Gs2Cdk.Gs2Mission.Ref
{
    public class CounterModelRef {
        private string namespaceName;
        private string counterName;

        public CounterModelRef(
            string namespaceName,
            string counterName
        ){
            this.namespaceName = namespaceName;
            this.counterName = counterName;
        }

        public IncreaseCounterByUserId IncreaseCounter(
            long? value,
            string userId = "#{userId}"
        ){
            return (new IncreaseCounterByUserId(
                this.namespaceName,
                this.counterName,
                value,
                userId
            ));
        }

        public DecreaseCounterByUserId DecreaseCounter(
            long? value,
            string userId = "#{userId}"
        ){
            return (new DecreaseCounterByUserId(
                this.namespaceName,
                this.counterName,
                value,
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
                    "mission",
                    this.namespaceName,
                    "counter",
                    this.counterName
                }
            )).Str(
            );
        }
    }
}
