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
using Gs2Cdk.Gs2Schedule.Model;

namespace Gs2Cdk.Gs2Schedule.StampSheet
{
    public class DeleteTriggerByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string triggerName;


        public DeleteTriggerByUserId(
            string namespaceName,
            string triggerName,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.triggerName != null) {
                properties["triggerName"] = this.triggerName;
            }

            return properties;
        }

        public static DeleteTriggerByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DeleteTriggerByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["triggerName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new DeleteTriggerByUserId(
                    properties["namespaceName"].ToString(),
                    properties["triggerName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Schedule:DeleteTriggerByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:DeleteTriggerByUserId";
        }
    }
}
