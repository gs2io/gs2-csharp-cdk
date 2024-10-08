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
using Gs2Cdk.Gs2Matchmaking.Ref;
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Enums;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public NamespaceCreateGatheringTriggerType? createGatheringTriggerType;
        public NamespaceCompleteMatchmakingTriggerType? completeMatchmakingTriggerType;
        public string description;
        public bool? enableRating;
        public NamespaceEnableDisconnectDetection? enableDisconnectDetection;
        public int? disconnectDetectionTimeoutSeconds;
        public string createGatheringTriggerRealtimeNamespaceId;
        public string createGatheringTriggerScriptId;
        public string completeMatchmakingTriggerRealtimeNamespaceId;
        public string completeMatchmakingTriggerScriptId;
        public NamespaceEnableCollaborateSeasonRating? enableCollaborateSeasonRating;
        public string collaborateSeasonRatingNamespaceId;
        public int? collaborateSeasonRatingTtl;
        public ScriptSetting changeRatingScript;
        public NotificationSetting joinNotification;
        public NotificationSetting leaveNotification;
        public NotificationSetting completeNotification;
        public NotificationSetting changeRatingNotification;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceCreateGatheringTriggerType createGatheringTriggerType,
            NamespaceCompleteMatchmakingTriggerType completeMatchmakingTriggerType,
            NamespaceOptions options = null
        ): base(
            "Matchmaking_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.createGatheringTriggerType = createGatheringTriggerType;
            this.completeMatchmakingTriggerType = completeMatchmakingTriggerType;
            this.description = options?.description;
            this.enableRating = options?.enableRating;
            this.enableDisconnectDetection = options?.enableDisconnectDetection;
            this.disconnectDetectionTimeoutSeconds = options?.disconnectDetectionTimeoutSeconds;
            this.createGatheringTriggerRealtimeNamespaceId = options?.createGatheringTriggerRealtimeNamespaceId;
            this.createGatheringTriggerScriptId = options?.createGatheringTriggerScriptId;
            this.completeMatchmakingTriggerRealtimeNamespaceId = options?.completeMatchmakingTriggerRealtimeNamespaceId;
            this.completeMatchmakingTriggerScriptId = options?.completeMatchmakingTriggerScriptId;
            this.enableCollaborateSeasonRating = options?.enableCollaborateSeasonRating;
            this.collaborateSeasonRatingNamespaceId = options?.collaborateSeasonRatingNamespaceId;
            this.collaborateSeasonRatingTtl = options?.collaborateSeasonRatingTtl;
            this.changeRatingScript = options?.changeRatingScript;
            this.joinNotification = options?.joinNotification;
            this.leaveNotification = options?.leaveNotification;
            this.completeNotification = options?.completeNotification;
            this.changeRatingNotification = options?.changeRatingNotification;
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
            return "GS2::Matchmaking::Namespace";
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
            if (this.enableRating != null) {
                properties["EnableRating"] = this.enableRating;
            }
            if (this.enableDisconnectDetection != null) {
                properties["EnableDisconnectDetection"] = this.enableDisconnectDetection.Value.Str(
                );
            }
            if (this.disconnectDetectionTimeoutSeconds != null) {
                properties["DisconnectDetectionTimeoutSeconds"] = this.disconnectDetectionTimeoutSeconds;
            }
            if (this.createGatheringTriggerType != null) {
                properties["CreateGatheringTriggerType"] = this.createGatheringTriggerType.Value.Str(
                );
            }
            if (this.createGatheringTriggerRealtimeNamespaceId != null) {
                properties["CreateGatheringTriggerRealtimeNamespaceId"] = this.createGatheringTriggerRealtimeNamespaceId;
            }
            if (this.createGatheringTriggerScriptId != null) {
                properties["CreateGatheringTriggerScriptId"] = this.createGatheringTriggerScriptId;
            }
            if (this.completeMatchmakingTriggerType != null) {
                properties["CompleteMatchmakingTriggerType"] = this.completeMatchmakingTriggerType.Value.Str(
                );
            }
            if (this.completeMatchmakingTriggerRealtimeNamespaceId != null) {
                properties["CompleteMatchmakingTriggerRealtimeNamespaceId"] = this.completeMatchmakingTriggerRealtimeNamespaceId;
            }
            if (this.completeMatchmakingTriggerScriptId != null) {
                properties["CompleteMatchmakingTriggerScriptId"] = this.completeMatchmakingTriggerScriptId;
            }
            if (this.enableCollaborateSeasonRating != null) {
                properties["EnableCollaborateSeasonRating"] = this.enableCollaborateSeasonRating.Value.Str(
                );
            }
            if (this.collaborateSeasonRatingNamespaceId != null) {
                properties["CollaborateSeasonRatingNamespaceId"] = this.collaborateSeasonRatingNamespaceId;
            }
            if (this.collaborateSeasonRatingTtl != null) {
                properties["CollaborateSeasonRatingTtl"] = this.collaborateSeasonRatingTtl;
            }
            if (this.changeRatingScript != null) {
                properties["ChangeRatingScript"] = this.changeRatingScript?.Properties(
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
            if (this.completeNotification != null) {
                properties["CompleteNotification"] = this.completeNotification?.Properties(
                );
            }
            if (this.changeRatingNotification != null) {
                properties["ChangeRatingNotification"] = this.changeRatingNotification?.Properties(
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
            RatingModel[] ratingModels,
            SeasonModel[] seasonModels
        ){
            (new CurrentMasterData(
                this.stack,
                this.name,
                ratingModels,
                seasonModels
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
                new Func<RatingModel[]>(() =>
                {
                    return properties["ratingModels"] switch {
                        RatingModel[] v => v,
                        List<RatingModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(RatingModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(RatingModel.FromProperties).ToArray(),
                        _ => null,
                    };
                })(),
                new Func<SeasonModel[]>(() =>
                {
                    return properties["seasonModels"] switch {
                        SeasonModel[] v => v,
                        List<SeasonModel> v => v.ToArray(),
                        Dictionary<string, object>[] v => v.Select(SeasonModel.FromProperties).ToArray(),
                        List<Dictionary<string, object>> v => v.Select(SeasonModel.FromProperties).ToArray(),
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
