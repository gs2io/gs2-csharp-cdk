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
using Gs2Cdk.Gs2Friend.Model;
using Gs2Cdk.Gs2Friend.Ref;

namespace Gs2Cdk.Gs2Friend.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly ScriptSetting _followScript;
        private readonly ScriptSetting _unfollowScript;
        private readonly ScriptSetting _sendRequestScript;
        private readonly ScriptSetting _cancelRequestScript;
        private readonly ScriptSetting _acceptRequestScript;
        private readonly ScriptSetting _rejectRequestScript;
        private readonly ScriptSetting _deleteFriendScript;
        private readonly ScriptSetting _updateProfileScript;
        private readonly NotificationSetting _followNotification;
        private readonly NotificationSetting _receiveRequestNotification;
        private readonly NotificationSetting _acceptRequestNotification;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string description = null,
                ScriptSetting followScript = null,
                ScriptSetting unfollowScript = null,
                ScriptSetting sendRequestScript = null,
                ScriptSetting cancelRequestScript = null,
                ScriptSetting acceptRequestScript = null,
                ScriptSetting rejectRequestScript = null,
                ScriptSetting deleteFriendScript = null,
                ScriptSetting updateProfileScript = null,
                NotificationSetting followNotification = null,
                NotificationSetting receiveRequestNotification = null,
                NotificationSetting acceptRequestNotification = null,
                LogSetting logSetting = null
        ): base("Friend_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._followScript = followScript;
            this._unfollowScript = unfollowScript;
            this._sendRequestScript = sendRequestScript;
            this._cancelRequestScript = cancelRequestScript;
            this._acceptRequestScript = acceptRequestScript;
            this._rejectRequestScript = rejectRequestScript;
            this._deleteFriendScript = deleteFriendScript;
            this._updateProfileScript = updateProfileScript;
            this._followNotification = followNotification;
            this._receiveRequestNotification = receiveRequestNotification;
            this._acceptRequestNotification = acceptRequestNotification;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Friend::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._followScript != null) {
                properties["FollowScript"] = this._followScript.Properties();
            }
            if (this._unfollowScript != null) {
                properties["UnfollowScript"] = this._unfollowScript.Properties();
            }
            if (this._sendRequestScript != null) {
                properties["SendRequestScript"] = this._sendRequestScript.Properties();
            }
            if (this._cancelRequestScript != null) {
                properties["CancelRequestScript"] = this._cancelRequestScript.Properties();
            }
            if (this._acceptRequestScript != null) {
                properties["AcceptRequestScript"] = this._acceptRequestScript.Properties();
            }
            if (this._rejectRequestScript != null) {
                properties["RejectRequestScript"] = this._rejectRequestScript.Properties();
            }
            if (this._deleteFriendScript != null) {
                properties["DeleteFriendScript"] = this._deleteFriendScript.Properties();
            }
            if (this._updateProfileScript != null) {
                properties["UpdateProfileScript"] = this._updateProfileScript.Properties();
            }
            if (this._followNotification != null) {
                properties["FollowNotification"] = this._followNotification.Properties();
            }
            if (this._receiveRequestNotification != null) {
                properties["ReceiveRequestNotification"] = this._receiveRequestNotification.Properties();
            }
            if (this._acceptRequestNotification != null) {
                properties["AcceptRequestNotification"] = this._acceptRequestNotification.Properties();
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
