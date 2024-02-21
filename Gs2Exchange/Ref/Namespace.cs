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
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.StampSheet;

namespace Gs2Cdk.Gs2Exchange.Ref
{
    public class NamespaceRef {
        private string namespaceName;

        public NamespaceRef(
            string namespaceName
        ){
            this.namespaceName = namespaceName;
        }

        public RateModelRef RateModel(
            string rateName
        ){
            return (new RateModelRef(
                this.namespaceName,
                rateName
            ));
        }

        public IncrementalRateModelRef IncrementalRateModel(
            string rateName
        ){
            return (new IncrementalRateModelRef(
                this.namespaceName,
                rateName
            ));
        }

        public ExchangeByUserId Exchange(
            string rateName,
            int count,
            Config[] config = null,
            string userId = "#{userId}"
        ){
            return (new ExchangeByUserId(
                this.namespaceName,
                rateName,
                count,
                config,
                userId
            ));
        }

        public IncrementalExchangeByUserId IncrementalExchange(
            string rateName,
            int count,
            Config[] config = null,
            string userId = "#{userId}"
        ){
            return (new IncrementalExchangeByUserId(
                this.namespaceName,
                rateName,
                count,
                config,
                userId
            ));
        }

        public UnlockIncrementalExchangeByUserId UnlockIncrementalExchange(
            string rateName,
            string lockTransactionId,
            string userId = "#{userId}"
        ){
            return (new UnlockIncrementalExchangeByUserId(
                this.namespaceName,
                rateName,
                lockTransactionId,
                userId
            ));
        }

        public CreateAwaitByUserId CreateAwait(
            string rateName,
            int? count = null,
            Config[] config = null,
            string userId = "#{userId}"
        ){
            return (new CreateAwaitByUserId(
                this.namespaceName,
                rateName,
                count,
                config,
                userId
            ));
        }

        public DeleteAwaitByUserId DeleteAwait(
            string awaitName = null,
            string userId = "#{userId}"
        ){
            return (new DeleteAwaitByUserId(
                this.namespaceName,
                awaitName,
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
                    "exchange",
                    this.namespaceName
                }
            )).Str(
            );
        }
    }
}
