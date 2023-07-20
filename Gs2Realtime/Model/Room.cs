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
using Gs2Cdk.Gs2Realtime.Ref;
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Model.Options;

namespace Gs2Cdk.Gs2Realtime.Model
{
    public class Room : CdkResource {
        private Stack? stack;
        private string ownerId;
        private string namespaceName;
        private string name;
        private string ipAddress;
        private int? port;
        private string encryptionKey;

        public Room(
            Stack stack,
            string ownerId,
            string namespaceName,
            string name,
            RoomOptions options = null
        ): base(
            "Realtime_Room_" + name
        ){

            this.stack = stack;
            this.ownerId = ownerId;
            this.namespaceName = namespaceName;
            this.name = name;
            this.ipAddress = options?.ipAddress;
            this.port = options?.port;
            this.encryptionKey = options?.encryptionKey;
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
            return "GS2::Realtime::Room";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.ownerId != null) {
                properties["OwnerId"] = this.ownerId;
            }
            if (this.namespaceName != null) {
                properties["NamespaceName"] = this.namespaceName;
            }
            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.ipAddress != null) {
                properties["IpAddress"] = this.ipAddress;
            }
            if (this.port != null) {
                properties["Port"] = this.port;
            }
            if (this.encryptionKey != null) {
                properties["EncryptionKey"] = this.encryptionKey;
            }

            return properties;
        }

        public RoomRef Ref(
        ){
            return (new RoomRef(
                this.namespaceName,
                this.name
            ));
        }

        public GetAttr GetAttrRoomId(
        ){
            return (new GetAttr(
                this,
                "Item.RoomId",
                null
            ));
        }
    }
}
