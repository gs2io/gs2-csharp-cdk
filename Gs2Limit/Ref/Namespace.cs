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
using Gs2Cdk.Gs2Limit.Model;
using Gs2Cdk.Gs2Limit.StampSheet;

namespace Gs2Cdk.Gs2Limit.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public LimitModelRef LimitModel(
            string limitName
        ){
            return (new LimitModelRef(
                this.namespaceName,
                limitName
            ));
        }

        public CountDownByUserId CountDown(
            string limitName,
            string counterName,
            int? countDownValue,
            string userId = "#{userId}"
        ){
            return (new CountDownByUserId(
                namespaceName,
                limitName,
                counterName,
                countDownValue,
                userId
            ));
        }

        public DeleteCounterByUserId DeleteCounter(
            string limitName,
            string counterName,
            string userId = "#{userId}"
        ){
            return (new DeleteCounterByUserId(
                namespaceName,
                limitName,
                counterName,
                userId
            ));
        }

        public CountUpByUserId CountUp(
            string limitName,
            string counterName,
            int? countUpValue,
            int? maxValue = null,
            string userId = "#{userId}"
        ){
            return (new CountUpByUserId(
                namespaceName,
                limitName,
                counterName,
                countUpValue,
                maxValue,
                userId
            ));
        }

        public VerifyCounterByUserId VerifyCounter(
            string limitName,
            string counterName,
            string verifyType,
            int? count,
            string userId = "#{userId}"
        ){
            return (new VerifyCounterByUserId(
                namespaceName,
                limitName,
                counterName,
                verifyType,
                count,
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
                    "limit",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
