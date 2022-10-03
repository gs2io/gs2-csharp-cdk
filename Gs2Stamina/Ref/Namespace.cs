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
using Gs2Cdk.Gs2Stamina.Model;
using Gs2Cdk.Gs2Stamina.StampSheet;


namespace Gs2Cdk.Gs2Stamina.Ref
{
    public class NamespaceRef {
        private readonly string _namespaceName;

        public NamespaceRef(
                string namespaceName
        ) {
            this._namespaceName = namespaceName;
        }

        public CurrentStaminaMasterRef CurrentStaminaMaster(
        ) {
            return new CurrentStaminaMasterRef(
                this._namespaceName
            );
        }

        public MaxStaminaTableRef MaxStaminaTable(
                string maxStaminaTableName
        ) {
            return new MaxStaminaTableRef(
                this._namespaceName,
                maxStaminaTableName
            );
        }

        public RecoverIntervalTableRef RecoverIntervalTable(
                string recoverIntervalTableName
        ) {
            return new RecoverIntervalTableRef(
                this._namespaceName,
                recoverIntervalTableName
            );
        }

        public RecoverValueTableRef RecoverValueTable(
                string recoverValueTableName
        ) {
            return new RecoverValueTableRef(
                this._namespaceName,
                recoverValueTableName
            );
        }

        public StaminaModelRef StaminaModel(
                string staminaName
        ) {
            return new StaminaModelRef(
                this._namespaceName,
                staminaName
            );
        }

        public RecoverIntervalTableMasterRef RecoverIntervalTableMaster(
                string recoverIntervalTableName
        ) {
            return new RecoverIntervalTableMasterRef(
                this._namespaceName,
                recoverIntervalTableName
            );
        }

        public MaxStaminaTableMasterRef MaxStaminaTableMaster(
                string maxStaminaTableName
        ) {
            return new MaxStaminaTableMasterRef(
                this._namespaceName,
                maxStaminaTableName
            );
        }

        public RecoverValueTableMasterRef RecoverValueTableMaster(
                string recoverValueTableName
        ) {
            return new RecoverValueTableMasterRef(
                this._namespaceName,
                recoverValueTableName
            );
        }

        public StaminaModelMasterRef StaminaModelMaster(
                string staminaName
        ) {
            return new StaminaModelMasterRef(
                this._namespaceName,
                staminaName
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
                    "stamina",
                    this._namespaceName
                }
            ).ToString();
        }
    }
}
