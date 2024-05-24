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
using Gs2Cdk.Gs2Guild.Ref;
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.Model.Options;

namespace Gs2Cdk.Gs2Guild.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        private string name;
        private string description;
        private NotificationSetting joinNotification;
        private NotificationSetting leaveNotification;
        private NotificationSetting changeMemberNotification;
        private NotificationSetting receiveRequestNotification;
        private NotificationSetting removeRequestNotification;
        private LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Guild_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.joinNotification = options?.joinNotification;
            this.leaveNotification = options?.leaveNotification;
            this.changeMemberNotification = options?.changeMemberNotification;
            this.receiveRequestNotification = options?.receiveRequestNotification;
            this.removeRequestNotification = options?.removeRequestNotification;
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
            return "GS2::Guild::Namespace";
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
            if (this.joinNotification != null) {
                properties["JoinNotification"] = this.joinNotification?.Properties(
                );
            }
            if (this.leaveNotification != null) {
                properties["LeaveNotification"] = this.leaveNotification?.Properties(
                );
            }
            if (this.changeMemberNotification != null) {
                properties["ChangeMemberNotification"] = this.changeMemberNotification?.Properties(
                );
            }
            if (this.receiveRequestNotification != null) {
                properties["ReceiveRequestNotification"] = this.receiveRequestNotification?.Properties(
                );
            }
            if (this.removeRequestNotification != null) {
                properties["RemoveRequestNotification"] = this.removeRequestNotification?.Properties(
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

        public Namespace MasterData(
            GuildModel[] guildModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                guildModels
            )).AddDependsOn(
                this
            );
            return this;
        }

        public Namespace MasterData(
            Dictionary<string, object> properties
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                new Func<GuildModel[]>(() =>
                {
                    return properties["guildModels"] switch {
                        GuildModel[] v => v,
                        List<GuildModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(GuildModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(GuildModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })()
            )).AddDependsOn(
                this
            );
            return this;
        }
    }
}
