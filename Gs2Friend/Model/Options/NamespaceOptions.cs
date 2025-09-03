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
using Gs2Cdk.Gs2Friend.Model;

namespace Gs2Cdk.Gs2Friend.Model.Options
{
    public class NamespaceOptions {
        public string description;
        public TransactionSetting transactionSetting;
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
    }
}

