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
using Gs2Cdk.Gs2SerialKey.Model;

namespace Gs2Cdk.Gs2SerialKey.StampSheet
{
    public class RevertUseByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string code;


        public RevertUseByUserId(
            string namespaceName,
            string code,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.code = code;
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
            if (this.code != null) {
                properties["code"] = this.code;
            }

            return properties;
        }

        public static RevertUseByUserId FromProperties(Dictionary<string, object> properties) {
            return new RevertUseByUserId(
                (string)properties["namespaceName"],
                (string)properties["code"],
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2SerialKey:RevertUseByUserId";
        }

        public static string StaticAction() {
            return "Gs2SerialKey:RevertUseByUserId";
        }
    }
}
