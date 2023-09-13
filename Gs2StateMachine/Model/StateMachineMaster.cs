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
using Gs2Cdk.Gs2StateMachine.Ref;
using Gs2Cdk.Gs2StateMachine.Model;
using Gs2Cdk.Gs2StateMachine.Model.Options;

namespace Gs2Cdk.Gs2StateMachine.Model
{
    public class StateMachineMaster : CdkResource {
        private Stack? stack;
        private string namespaceName;
        private string mainStateMachineName;
        private string payload;

        public StateMachineMaster(
            Stack stack,
            string namespaceName,
            string mainStateMachineName,
            string payload,
            StateMachineMasterOptions options = null
        ): base(
            "StateMachine_StateMachineMaster_" + namespaceName
        ){

            this.stack = stack;
            this.namespaceName = namespaceName;
            this.mainStateMachineName = mainStateMachineName;
            this.payload = payload;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "version";
        }

        public override string ResourceType(
        ){
            return "GS2::StateMachine::StateMachineMaster";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (this.mainStateMachineName != null) {
                properties["MainStateMachineName"] = this.mainStateMachineName;
            }
            if (this.payload != null) {
                properties["Payload"] = this.payload;
            }

            return properties;
        }

        public StateMachineMasterRef Ref(
            long version
        ){
            return (new StateMachineMasterRef(
                this.namespaceName,
                version
            ));
        }

        public GetAttr GetAttrStateMachineId(
        ){
            return (new GetAttr(
                this,
                "Item.StateMachineId",
                null
            ));
        }
    }
}
