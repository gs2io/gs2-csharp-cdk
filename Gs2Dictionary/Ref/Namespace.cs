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
using Gs2Cdk.Gs2Dictionary.Model;
using Gs2Cdk.Gs2Dictionary.StampSheet;


namespace Gs2Cdk.Gs2Dictionary.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentEntryMasterRef CurrentEntryMaster(
        ) {
            return new CurrentEntryMasterRef(
                this._namespaceName
            );
        }

        public EntryModelRef EntryModel(
                string entryName
        ) {
            return new EntryModelRef(
                this._namespaceName,
                entryName
            );
        }

        public EntryModelMasterRef EntryModelMaster(
                string entryName
        ) {
            return new EntryModelMasterRef(
                this._namespaceName,
                entryName
            );
        }

        public AddEntriesByUserId AddEntries(
                string[] entryModelNames = null,
                string userId = "#{userId}"
        ) {
            return new AddEntriesByUserId(
                namespaceName: this._namespaceName,
                userId: userId,
                entryModelNames: entryModelNames
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
                    "dictionary",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
