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
using Gs2Cdk.Gs2Chat.Model;
using Gs2Cdk.Gs2Chat.Ref;

namespace Gs2Cdk.Gs2Chat.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly bool? _allowCreateRoom;
        private readonly ScriptSetting _postMessageScript;
        private readonly ScriptSetting _createRoomScript;
        private readonly ScriptSetting _deleteRoomScript;
        private readonly ScriptSetting _subscribeRoomScript;
        private readonly ScriptSetting _unsubscribeRoomScript;
        private readonly NotificationSetting _postNotification;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                bool? allowCreateRoom,
                string description = null,
                ScriptSetting postMessageScript = null,
                ScriptSetting createRoomScript = null,
                ScriptSetting deleteRoomScript = null,
                ScriptSetting subscribeRoomScript = null,
                ScriptSetting unsubscribeRoomScript = null,
                NotificationSetting postNotification = null,
                LogSetting logSetting = null
        ): base("Chat_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._allowCreateRoom = allowCreateRoom;
            this._postMessageScript = postMessageScript;
            this._createRoomScript = createRoomScript;
            this._deleteRoomScript = deleteRoomScript;
            this._subscribeRoomScript = subscribeRoomScript;
            this._unsubscribeRoomScript = unsubscribeRoomScript;
            this._postNotification = postNotification;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Chat::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._allowCreateRoom != null) {
                properties["AllowCreateRoom"] = this._allowCreateRoom;
            }
            if (this._postMessageScript != null) {
                properties["PostMessageScript"] = this._postMessageScript.Properties();
            }
            if (this._createRoomScript != null) {
                properties["CreateRoomScript"] = this._createRoomScript.Properties();
            }
            if (this._deleteRoomScript != null) {
                properties["DeleteRoomScript"] = this._deleteRoomScript.Properties();
            }
            if (this._subscribeRoomScript != null) {
                properties["SubscribeRoomScript"] = this._subscribeRoomScript.Properties();
            }
            if (this._unsubscribeRoomScript != null) {
                properties["UnsubscribeRoomScript"] = this._unsubscribeRoomScript.Properties();
            }
            if (this._postNotification != null) {
                properties["PostNotification"] = this._postNotification.Properties();
            }
            if (this._logSetting != null) {
                properties["LogSetting"] = this._logSetting.Properties();
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }
    }
}
