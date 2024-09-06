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
using Gs2Cdk.Gs2Friend.Ref;
using Gs2Cdk.Gs2Friend.Model;
using Gs2Cdk.Gs2Friend.Model.Options;

namespace Gs2Cdk.Gs2Friend.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public ScriptSetting followScript;
        public ScriptSetting unfollowScript;
        public ScriptSetting sendRequestScript;
        public ScriptSetting cancelRequestScript;
        public ScriptSetting acceptRequestScript;
        public ScriptSetting rejectRequestScript;
        public ScriptSetting deleteFriendScript;
        public ScriptSetting updateProfileScript;
        public NotificationSetting followNotification;
        public NotificationSetting receiveRequestNotification;
        public NotificationSetting cancelRequestNotification;
        public NotificationSetting acceptRequestNotification;
        public NotificationSetting rejectRequestNotification;
        public NotificationSetting deleteFriendNotification;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Friend_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.followScript = options?.followScript;
            this.unfollowScript = options?.unfollowScript;
            this.sendRequestScript = options?.sendRequestScript;
            this.cancelRequestScript = options?.cancelRequestScript;
            this.acceptRequestScript = options?.acceptRequestScript;
            this.rejectRequestScript = options?.rejectRequestScript;
            this.deleteFriendScript = options?.deleteFriendScript;
            this.updateProfileScript = options?.updateProfileScript;
            this.followNotification = options?.followNotification;
            this.receiveRequestNotification = options?.receiveRequestNotification;
            this.cancelRequestNotification = options?.cancelRequestNotification;
            this.acceptRequestNotification = options?.acceptRequestNotification;
            this.rejectRequestNotification = options?.rejectRequestNotification;
            this.deleteFriendNotification = options?.deleteFriendNotification;
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
            return "GS2::Friend::Namespace";
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
            if (this.followScript != null) {
                properties["FollowScript"] = this.followScript?.Properties(
                );
            }
            if (this.unfollowScript != null) {
                properties["UnfollowScript"] = this.unfollowScript?.Properties(
                );
            }
            if (this.sendRequestScript != null) {
                properties["SendRequestScript"] = this.sendRequestScript?.Properties(
                );
            }
            if (this.cancelRequestScript != null) {
                properties["CancelRequestScript"] = this.cancelRequestScript?.Properties(
                );
            }
            if (this.acceptRequestScript != null) {
                properties["AcceptRequestScript"] = this.acceptRequestScript?.Properties(
                );
            }
            if (this.rejectRequestScript != null) {
                properties["RejectRequestScript"] = this.rejectRequestScript?.Properties(
                );
            }
            if (this.deleteFriendScript != null) {
                properties["DeleteFriendScript"] = this.deleteFriendScript?.Properties(
                );
            }
            if (this.updateProfileScript != null) {
                properties["UpdateProfileScript"] = this.updateProfileScript?.Properties(
                );
            }
            if (this.followNotification != null) {
                properties["FollowNotification"] = this.followNotification?.Properties(
                );
            }
            if (this.receiveRequestNotification != null) {
                properties["ReceiveRequestNotification"] = this.receiveRequestNotification?.Properties(
                );
            }
            if (this.cancelRequestNotification != null) {
                properties["CancelRequestNotification"] = this.cancelRequestNotification?.Properties(
                );
            }
            if (this.acceptRequestNotification != null) {
                properties["AcceptRequestNotification"] = this.acceptRequestNotification?.Properties(
                );
            }
            if (this.rejectRequestNotification != null) {
                properties["RejectRequestNotification"] = this.rejectRequestNotification?.Properties(
                );
            }
            if (this.deleteFriendNotification != null) {
                properties["DeleteFriendNotification"] = this.deleteFriendNotification?.Properties(
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
