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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.StampSheet;


namespace Gs2Cdk.Gs2Formation.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentFormMasterRef CurrentFormMaster(
        ) {
            return new CurrentFormMasterRef(
                this._namespaceName
            );
        }

        public FormModelRef FormModel(
                string formModelName
        ) {
            return new FormModelRef(
                this._namespaceName,
                formModelName
            );
        }

        public MoldModelRef MoldModel(
                string moldName
        ) {
            return new MoldModelRef(
                this._namespaceName,
                moldName
            );
        }

        public FormModelMasterRef FormModelMaster(
                string formModelName
        ) {
            return new FormModelMasterRef(
                this._namespaceName,
                formModelName
            );
        }

        public MoldModelMasterRef MoldModelMaster(
                string moldName
        ) {
            return new MoldModelMasterRef(
                this._namespaceName,
                moldName
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
                    "formation",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
