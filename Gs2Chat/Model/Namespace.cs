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

using Gs2Cdk.Core.Model;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Chat.Ref;
using Gs2Cdk.Gs2Chat.Model;
using Gs2Cdk.Gs2Chat.Model.Options;

namespace Gs2Cdk.Gs2Chat.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        private string name;
        private string description;
        private bool? allowCreateRoom;
        private ScriptSetting postMessageScript;
        private ScriptSetting createRoomScript;
        private ScriptSetting deleteRoomScript;
        private ScriptSetting subscribeRoomScript;
        private ScriptSetting unsubscribeRoomScript;
        private NotificationSetting postNotification;
        private LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Chat_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.allowCreateRoom = options?.allowCreateRoom;
            this.postMessageScript = options?.postMessageScript;
            this.createRoomScript = options?.createRoomScript;
            this.deleteRoomScript = options?.deleteRoomScript;
            this.subscribeRoomScript = options?.subscribeRoomScript;
            this.unsubscribeRoomScript = options?.unsubscribeRoomScript;
            this.postNotification = options?.postNotification;
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
            return "GS2::Chat::Namespace";
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
            if (this.allowCreateRoom != null) {
                properties["AllowCreateRoom"] = this.allowCreateRoom;
            }
            if (this.postMessageScript != null) {
                properties["PostMessageScript"] = this.postMessageScript?.Properties(
                );
            }
            if (this.createRoomScript != null) {
                properties["CreateRoomScript"] = this.createRoomScript?.Properties(
                );
            }
            if (this.deleteRoomScript != null) {
                properties["DeleteRoomScript"] = this.deleteRoomScript?.Properties(
                );
            }
            if (this.subscribeRoomScript != null) {
                properties["SubscribeRoomScript"] = this.subscribeRoomScript?.Properties(
                );
            }
            if (this.unsubscribeRoomScript != null) {
                properties["UnsubscribeRoomScript"] = this.unsubscribeRoomScript?.Properties(
                );
            }
            if (this.postNotification != null) {
                properties["PostNotification"] = this.postNotification?.Properties(
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
                null,
                null,
                "Item.NamespaceId"
            ));
        }
    }
}
