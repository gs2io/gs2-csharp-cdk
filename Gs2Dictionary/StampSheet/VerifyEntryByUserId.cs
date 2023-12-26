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
using Gs2Cdk.Gs2Dictionary.Model;
using Gs2Cdk.Gs2Dictionary.StampSheet.Enums;

namespace Gs2Cdk.Gs2Dictionary.StampSheet
{
    public class VerifyEntryByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string entryModelName;
        private VerifyEntryByUserIdVerifyType? verifyType;


        public VerifyEntryByUserId(
            string namespaceName,
            string entryModelName,
            VerifyEntryByUserIdVerifyType verifyType,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.entryModelName = entryModelName;
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
            if (this.entryModelName != null) {
                properties["entryModelName"] = this.entryModelName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }

            return properties;
        }

        public static VerifyEntryByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyEntryByUserId(
                (string)properties["namespaceName"],
                (string)properties["entryModelName"],
                new Func<VerifyEntryByUserIdVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        VerifyEntryByUserIdVerifyType e => e,
                        string s => VerifyEntryByUserIdVerifyTypeExt.New(s),
                        _ => VerifyEntryByUserIdVerifyType.Havent
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Dictionary:VerifyEntryByUserId";
        }

        public static string StaticAction() {
            return "Gs2Dictionary:VerifyEntryByUserId";
        }
    }
}
