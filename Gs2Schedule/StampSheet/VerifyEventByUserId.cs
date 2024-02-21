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
using Gs2Cdk.Gs2Schedule.StampSheet.Enums;

namespace Gs2Cdk.Gs2Schedule.StampSheet
{
    public class VerifyEventByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string eventName;
        private VerifyEventByUserIdVerifyType? verifyType;


        public VerifyEventByUserId(
            string namespaceName,
            string eventName,
            VerifyEventByUserIdVerifyType verifyType,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.eventName = eventName;
            this.verifyType = verifyType;
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
            if (this.eventName != null) {
                properties["eventName"] = this.eventName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType?.Str(
                );
            }

            return properties;
        }

        public static VerifyEventByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyEventByUserId(
                (string)properties["namespaceName"],
                (string)properties["eventName"],
                new Func<VerifyEventByUserIdVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        VerifyEventByUserIdVerifyType e => e,
                        string s => VerifyEventByUserIdVerifyTypeExt.New(s),
                        _ => VerifyEventByUserIdVerifyType.InSchedule
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Schedule:VerifyEventByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:VerifyEventByUserId";
        }
    }
}
