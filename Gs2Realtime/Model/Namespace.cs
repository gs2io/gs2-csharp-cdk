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
using Gs2Cdk.Gs2Realtime.Ref;
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Model.Enums;
using Gs2Cdk.Gs2Realtime.Model.Options;

namespace Gs2Cdk.Gs2Realtime.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public NamespaceServerType? serverType;
        public NamespaceServerSpec? serverSpec;
        public string description;
        public NotificationSetting createNotification;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceServerType serverType,
            NamespaceServerSpec serverSpec,
            NamespaceOptions options = null
        ): base(
            "Realtime_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.serverType = serverType;
            this.serverSpec = serverSpec;
            this.description = options?.description;
            this.createNotification = options?.createNotification;
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
            return "GS2::Realtime::Namespace";
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
            if (this.serverType != null) {
                properties["ServerType"] = this.serverType.Value.Str(
                );
            }
            if (this.serverSpec != null) {
                properties["ServerSpec"] = this.serverSpec.Value.Str(
                );
            }
            if (this.createNotification != null) {
                properties["CreateNotification"] = this.createNotification?.Properties(
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
    }
}
