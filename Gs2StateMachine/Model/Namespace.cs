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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2StateMachine.Integration;
using Gs2Cdk.Gs2StateMachine.Ref;
using Gs2Cdk.Gs2StateMachine.Model;
using Gs2Cdk.Gs2StateMachine.Model.Enums;
using Gs2Cdk.Gs2StateMachine.Model.Options;

namespace Gs2Cdk.Gs2StateMachine.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public NamespaceSupportSpeculativeExecution? supportSpeculativeExecution;
        public TransactionSetting transactionSetting;
        public ScriptSetting startScript;
        public ScriptSetting passScript;
        public ScriptSetting errorScript;
        public long? lowestStateMachineVersion;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "StateMachine_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.supportSpeculativeExecution = options?.supportSpeculativeExecution;
            this.transactionSetting = options?.transactionSetting;
            this.startScript = options?.startScript;
            this.passScript = options?.passScript;
            this.errorScript = options?.errorScript;
            this.lowestStateMachineVersion = options?.lowestStateMachineVersion;
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
            return "GS2::StateMachine::Namespace";
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
            if (this.supportSpeculativeExecution != null) {
                properties["SupportSpeculativeExecution"] = this.supportSpeculativeExecution.Value.Str(
                );
            }
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.startScript != null) {
                properties["StartScript"] = this.startScript?.Properties(
                );
            }
            if (this.passScript != null) {
                properties["PassScript"] = this.passScript?.Properties(
                );
            }
            if (this.errorScript != null) {
                properties["ErrorScript"] = this.errorScript?.Properties(
                );
            }
            if (this.lowestStateMachineVersion != null) {
                properties["LowestStateMachineVersion"] = this.lowestStateMachineVersion;
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
        public void StateMachine(Gs2Cdk.Gs2Script.Model.Namespace scriptNamespace, StateMachineDefinition definition)
        {
            definition.AppendScripts(stack, scriptNamespace);
            new StateMachineMaster(
                    stack,
                    name,
                    definition.StateMachineName,
                    definition.Gsl().Replace("{scriptNamespaceName}", scriptNamespace.GetName())
                )
                .AddDependsOn(this);
        }
    }
}
