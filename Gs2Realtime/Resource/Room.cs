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
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Ref;

namespace Gs2Cdk.Gs2Realtime.Resource
{
    public class Room : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _ownerId;
        private readonly string _namespaceName;
        private readonly string _name;
        private readonly string _ipAddress;
        private readonly int? _port;
        private readonly string _encryptionKey;

        public Room(
                Stack stack,
                string ownerId,
                string namespaceName,
                string name,
                string ipAddress = null,
                int? port = null,
                string encryptionKey = null
        ): base("Realtime_Room_" + name) {
            this._stack = stack;
            this._ownerId = ownerId;
            this._namespaceName = namespaceName;
            this._name = name;
            this._ipAddress = ipAddress;
            this._port = port;
            this._encryptionKey = encryptionKey;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Realtime::Room";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._ownerId != null) {
                properties["OwnerId"] = this._ownerId;
            }
            if (this._namespaceName != null) {
                properties["NamespaceName"] = this._namespaceName;
            }
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._ipAddress != null) {
                properties["IpAddress"] = this._ipAddress;
            }
            if (this._port != null) {
                properties["Port"] = this._port;
            }
            if (this._encryptionKey != null) {
                properties["EncryptionKey"] = this._encryptionKey;
            }
            return properties;
        }

        public RoomRef Ref(
                string namespaceName
        ) {
            return new RoomRef(
                namespaceName,
                this._name
            );
        }

        public GetAttr GetAttrRoomId() {
            return new GetAttr(
                "Item.RoomId"
            );
        }
    }
}
