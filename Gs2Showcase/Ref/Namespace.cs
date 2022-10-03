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
using Gs2Cdk.Gs2Showcase.Model;
using Gs2Cdk.Gs2Showcase.StampSheet;


namespace Gs2Cdk.Gs2Showcase.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentShowcaseMasterRef CurrentShowcaseMaster(
        ) {
            return new CurrentShowcaseMasterRef(
                this._namespaceName
            );
        }

        public DisplayItemRef DisplayItem(
        ) {
            return new DisplayItemRef(
                this._namespaceName
            );
        }

        public SalesItemMasterRef SalesItemMaster(
                string salesItemName
        ) {
            return new SalesItemMasterRef(
                this._namespaceName,
                salesItemName
            );
        }

        public SalesItemGroupMasterRef SalesItemGroupMaster(
                string salesItemGroupName
        ) {
            return new SalesItemGroupMasterRef(
                this._namespaceName,
                salesItemGroupName
            );
        }

        public ShowcaseMasterRef ShowcaseMaster(
                string showcaseName
        ) {
            return new ShowcaseMasterRef(
                this._namespaceName,
                showcaseName
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
                    "showcase",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
