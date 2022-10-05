/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.StampSheet;


namespace Gs2Cdk.Gs2Exchange.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public RateModelMasterRef RateModelMaster(
                string rateName
        ) {
            return new RateModelMasterRef(
                this._namespaceName,
                rateName
            );
        }

        public CurrentRateMasterRef CurrentRateMaster(
        ) {
            return new CurrentRateMasterRef(
                this._namespaceName
            );
        }

        public RateModelRef RateModel(
                string rateName
        ) {
            return new RateModelRef(
                this._namespaceName,
                rateName
            );
        }

        public CreateAwaitByUserId CreateAwait(
                string rateName,
                int? count,
                string userId = "#{userId}"
        ) {
            return new CreateAwaitByUserId(
                namespaceName: this._namespaceName,
                userId: userId,
                rateName: rateName,
                count: count
            );
        }

        public string Grn() {
            return new Join(
                ":",
                new string[] {
                    "grn",
                    "gs2",
                    GetAttr.Region().ToString(),
                    GetAttr.OwnerId().ToString(),
                    "exchange",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
