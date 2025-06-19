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
        public string name;
        public string description;
        public NotificationSetting changeNotification;
        public NotificationSetting joinNotification;
        public NotificationSetting leaveNotification;
        public NotificationSetting changeMemberNotification;
        public NotificationSetting receiveRequestNotification;
        public NotificationSetting removeRequestNotification;
        public ScriptSetting createGuildScript;
        public ScriptSetting updateGuildScript;
        public ScriptSetting joinGuildScript;
        public ScriptSetting leaveGuildScript;
        public ScriptSetting changeRoleScript;
        public ScriptSetting deleteGuildScript;
        public LogSetting logSetting;

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
            this.changeNotification = options?.changeNotification;
            this.joinNotification = options?.joinNotification;
            this.leaveNotification = options?.leaveNotification;
            this.changeMemberNotification = options?.changeMemberNotification;
            this.receiveRequestNotification = options?.receiveRequestNotification;
            this.removeRequestNotification = options?.removeRequestNotification;
            this.createGuildScript = options?.createGuildScript;
            this.updateGuildScript = options?.updateGuildScript;
            this.joinGuildScript = options?.joinGuildScript;
            this.leaveGuildScript = options?.leaveGuildScript;
            this.changeRoleScript = options?.changeRoleScript;
            this.deleteGuildScript = options?.deleteGuildScript;
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
            if (this.changeNotification != null) {
                properties["ChangeNotification"] = this.changeNotification?.Properties(
                );
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
            if (this.createGuildScript != null) {
                properties["CreateGuildScript"] = this.createGuildScript?.Properties(
                );
            }
            if (this.updateGuildScript != null) {
                properties["UpdateGuildScript"] = this.updateGuildScript?.Properties(
                );
            }
            if (this.joinGuildScript != null) {
                properties["JoinGuildScript"] = this.joinGuildScript?.Properties(
                );
            }
            if (this.leaveGuildScript != null) {
                properties["LeaveGuildScript"] = this.leaveGuildScript?.Properties(
                );
            }
            if (this.changeRoleScript != null) {
                properties["ChangeRoleScript"] = this.changeRoleScript?.Properties(
                );
            }
            if (this.deleteGuildScript != null) {
                properties["DeleteGuildScript"] = this.deleteGuildScript?.Properties(
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
