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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.Model.Options;

namespace Gs2Cdk.Gs2Matchmaking.Model
{
    public class SeasonModel {
        private string name;
        private int maximumParticipants;
        private string maximumParticipantsString;
        private string challengePeriodEventId;
        private string metadata;
        private string experienceModelId;

        public SeasonModel(
            string name,
            int maximumParticipants,
            string challengePeriodEventId,
            SeasonModelOptions options = null
        ){
            this.name = name;
            this.maximumParticipants = maximumParticipants;
            this.challengePeriodEventId = challengePeriodEventId;
            this.metadata = options?.metadata;
            this.experienceModelId = options?.experienceModelId;
        }


        public SeasonModel(
            string name,
            string maximumParticipants,
            string challengePeriodEventId,
            SeasonModelOptions options = null
        ){
            this.name = name;
            this.maximumParticipantsString = maximumParticipants;
            this.challengePeriodEventId = challengePeriodEventId;
            this.metadata = options?.metadata;
            this.experienceModelId = options?.experienceModelId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.maximumParticipantsString != null) {
                properties["maximumParticipants"] = this.maximumParticipantsString;
            } else {
                if (this.maximumParticipants != null) {
                    properties["maximumParticipants"] = this.maximumParticipants;
                }
            }
            if (this.experienceModelId != null) {
                properties["experienceModelId"] = this.experienceModelId;
            }
            if (this.challengePeriodEventId != null) {
                properties["challengePeriodEventId"] = this.challengePeriodEventId;
            }

            return properties;
        }

        public static SeasonModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SeasonModel(
                (string)properties["name"],
                new Func<int>(() =>
                {
                    return properties["maximumParticipants"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["challengePeriodEventId"],
                new SeasonModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    experienceModelId = properties.TryGetValue("experienceModelId", out var experienceModelId) ? (string)experienceModelId : null
                }
            );

            return model;
        }
    }
}
