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
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly string _serverType;
        private readonly string _serverSpec;
        private readonly NotificationSetting _createNotification;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                string serverType,
                string serverSpec,
                string description = null,
                NotificationSetting createNotification = null,
                LogSetting logSetting = null
        ): base("Realtime_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._serverType = serverType;
            this._serverSpec = serverSpec;
            this._createNotification = createNotification;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Realtime::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._serverType != null) {
                properties["ServerType"] = this._serverType.ToString();
            }
            if (this._serverSpec != null) {
                properties["ServerSpec"] = this._serverSpec.ToString();
            }
            if (this._createNotification != null) {
                properties["CreateNotification"] = this._createNotification.Properties();
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
