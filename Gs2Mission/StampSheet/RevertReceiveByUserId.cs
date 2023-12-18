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
using Gs2Cdk.Gs2Mission.Model;

namespace Gs2Cdk.Gs2Mission.StampSheet
{
    public class RevertReceiveByUserId : AcquireAction {
        private string namespaceName;
        private string missionGroupName;
        private string missionTaskName;
        private string userId;


        public RevertReceiveByUserId(
            string namespaceName,
            string missionGroupName,
            string missionTaskName,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.missionGroupName = missionGroupName;
            this.missionTaskName = missionTaskName;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.missionGroupName != null) {
                properties["missionGroupName"] = this.missionGroupName;
            }
            if (this.missionTaskName != null) {
                properties["missionTaskName"] = this.missionTaskName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }

            return properties;
        }

        public static RevertReceiveByUserId FromProperties(Dictionary<string, object> properties) {
            return new RevertReceiveByUserId(
                (string)properties["namespaceName"],
                (string)properties["missionGroupName"],
                (string)properties["missionTaskName"],
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Mission:RevertReceiveByUserId";
        }

        public static string StaticAction() {
            return "Gs2Mission:RevertReceiveByUserId";
        }
    }
}
