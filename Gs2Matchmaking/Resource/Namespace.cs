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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Ref;

namespace Gs2Cdk.Gs2Matchmaking.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly bool? _enableRating;
        private readonly string _createGatheringTriggerType;
        private readonly string _createGatheringTriggerRealtimeNamespaceId;
        private readonly string _createGatheringTriggerScriptId;
        private readonly string _completeMatchmakingTriggerType;
        private readonly string _completeMatchmakingTriggerRealtimeNamespaceId;
        private readonly string _completeMatchmakingTriggerScriptId;
        private readonly ScriptSetting _changeRatingScript;
        private readonly NotificationSetting _joinNotification;
        private readonly NotificationSetting _leaveNotification;
        private readonly NotificationSetting _completeNotification;
        private readonly LogSetting _logSetting;

        public Namespace(
                Stack stack,
                string name,
                bool? enableRating,
                string createGatheringTriggerType,
                string createGatheringTriggerRealtimeNamespaceId,
                string createGatheringTriggerScriptId,
                string completeMatchmakingTriggerType,
                string completeMatchmakingTriggerRealtimeNamespaceId,
                string completeMatchmakingTriggerScriptId,
                string description = null,
                ScriptSetting changeRatingScript = null,
                NotificationSetting joinNotification = null,
                NotificationSetting leaveNotification = null,
                NotificationSetting completeNotification = null,
                LogSetting logSetting = null
        ): base("Matchmaking_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._enableRating = enableRating;
            this._createGatheringTriggerType = createGatheringTriggerType;
            this._createGatheringTriggerRealtimeNamespaceId = createGatheringTriggerRealtimeNamespaceId;
            this._createGatheringTriggerScriptId = createGatheringTriggerScriptId;
            this._completeMatchmakingTriggerType = completeMatchmakingTriggerType;
            this._completeMatchmakingTriggerRealtimeNamespaceId = completeMatchmakingTriggerRealtimeNamespaceId;
            this._completeMatchmakingTriggerScriptId = completeMatchmakingTriggerScriptId;
            this._changeRatingScript = changeRatingScript;
            this._joinNotification = joinNotification;
            this._leaveNotification = leaveNotification;
            this._completeNotification = completeNotification;
            this._logSetting = logSetting;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Matchmaking::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._enableRating != null) {
                properties["EnableRating"] = this._enableRating;
            }
            if (this._createGatheringTriggerType != null) {
                properties["CreateGatheringTriggerType"] = this._createGatheringTriggerType.ToString();
            }
            if (this._createGatheringTriggerRealtimeNamespaceId != null) {
                properties["CreateGatheringTriggerRealtimeNamespaceId"] = this._createGatheringTriggerRealtimeNamespaceId;
            }
            if (this._createGatheringTriggerScriptId != null) {
                properties["CreateGatheringTriggerScriptId"] = this._createGatheringTriggerScriptId;
            }
            if (this._completeMatchmakingTriggerType != null) {
                properties["CompleteMatchmakingTriggerType"] = this._completeMatchmakingTriggerType.ToString();
            }
            if (this._completeMatchmakingTriggerRealtimeNamespaceId != null) {
                properties["CompleteMatchmakingTriggerRealtimeNamespaceId"] = this._completeMatchmakingTriggerRealtimeNamespaceId;
            }
            if (this._completeMatchmakingTriggerScriptId != null) {
                properties["CompleteMatchmakingTriggerScriptId"] = this._completeMatchmakingTriggerScriptId;
            }
            if (this._changeRatingScript != null) {
                properties["ChangeRatingScript"] = this._changeRatingScript.Properties();
            }
            if (this._joinNotification != null) {
                properties["JoinNotification"] = this._joinNotification.Properties();
            }
            if (this._leaveNotification != null) {
                properties["LeaveNotification"] = this._leaveNotification.Properties();
            }
            if (this._completeNotification != null) {
                properties["CompleteNotification"] = this._completeNotification.Properties();
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

        public Namespace MasterData(
                RatingModel[] ratingModels
        ) {
            new CurrentMasterData(
                this._stack,
                this._name,
                ratingModels
            ).AddDependsOn(
                this
            );
            return this;
        }
    }
}
