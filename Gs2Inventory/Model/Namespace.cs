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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Inventory.Ref;
using Gs2Cdk.Gs2Inventory.Model;
using Gs2Cdk.Gs2Inventory.Model.Options;

namespace Gs2Cdk.Gs2Inventory.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public ScriptSetting acquireScript;
        public ScriptSetting overflowScript;
        public ScriptSetting consumeScript;
        public ScriptSetting simpleItemAcquireScript;
        public ScriptSetting simpleItemConsumeScript;
        public ScriptSetting bigItemAcquireScript;
        public ScriptSetting bigItemConsumeScript;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Inventory_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.acquireScript = options?.acquireScript;
            this.overflowScript = options?.overflowScript;
            this.consumeScript = options?.consumeScript;
            this.simpleItemAcquireScript = options?.simpleItemAcquireScript;
            this.simpleItemConsumeScript = options?.simpleItemConsumeScript;
            this.bigItemAcquireScript = options?.bigItemAcquireScript;
            this.bigItemConsumeScript = options?.bigItemConsumeScript;
            this.logSetting = options?.logSetting;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::Inventory::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.acquireScript != null) {
                properties["AcquireScript"] = this.acquireScript?.Properties(
                );
            }
            if (this.overflowScript != null) {
                properties["OverflowScript"] = this.overflowScript?.Properties(
                );
            }
            if (this.consumeScript != null) {
                properties["ConsumeScript"] = this.consumeScript?.Properties(
                );
            }
            if (this.simpleItemAcquireScript != null) {
                properties["SimpleItemAcquireScript"] = this.simpleItemAcquireScript?.Properties(
                );
            }
            if (this.simpleItemConsumeScript != null) {
                properties["SimpleItemConsumeScript"] = this.simpleItemConsumeScript?.Properties(
                );
            }
            if (this.bigItemAcquireScript != null) {
                properties["BigItemAcquireScript"] = this.bigItemAcquireScript?.Properties(
                );
            }
            if (this.bigItemConsumeScript != null) {
                properties["BigItemConsumeScript"] = this.bigItemConsumeScript?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["LogSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public NamespaceRef Ref(
        ){
            return (new NamespaceRef(
                this.name
            ));
        }

        public GetAttr GetAttrNamespaceId(
        ){
            return (new GetAttr(
                this,
                "Item.NamespaceId",
                null
            ));
        }

        public Namespace MasterData(
            InventoryModel[] inventoryModels,
            SimpleInventoryModel[] simpleInventoryModels,
            BigInventoryModel[] bigInventoryModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                inventoryModels,
                simpleInventoryModels,
                bigInventoryModels
            )).AddDependsOn(
                this
            );
            return this;
        }

        public Namespace MasterData(
            Dictionary<string, object> properties
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                new Func<InventoryModel[]>(() =>
                {
                    return properties["inventoryModels"] switch {
                        InventoryModel[] v => v,
                        List<InventoryModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(InventoryModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(InventoryModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<SimpleInventoryModel[]>(() =>
                {
                    return properties["simpleInventoryModels"] switch {
                        SimpleInventoryModel[] v => v,
                        List<SimpleInventoryModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(SimpleInventoryModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(SimpleInventoryModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<BigInventoryModel[]>(() =>
                {
                    return properties["bigInventoryModels"] switch {
                        BigInventoryModel[] v => v,
                        List<BigInventoryModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(BigInventoryModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(BigInventoryModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })()
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
