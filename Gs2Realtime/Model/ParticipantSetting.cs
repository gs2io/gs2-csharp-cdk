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
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Model.Options;

namespace Gs2Cdk.Gs2Realtime.Model
{
    public class ParticipantSetting {
        private string userId;
        private string scriptId;

        public ParticipantSetting(
            string userId,
            string scriptId,
            ParticipantSettingOptions options = null
        ){
            this.userId = userId;
            this.scriptId = scriptId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.scriptId != null) {
                properties["scriptId"] = this.scriptId;
            }

            return properties;
        }

        public static ParticipantSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ParticipantSetting(
                properties.TryGetValue("userId", out var userId) ? new Func<string>(() =>
                {
                    return (string) userId;
                })() : default,
                properties.TryGetValue("scriptId", out var scriptId) ? new Func<string>(() =>
                {
                    return (string) scriptId;
                })() : default,
                new ParticipantSettingOptions {
                }
            );

            return model;
        }
    }
}
