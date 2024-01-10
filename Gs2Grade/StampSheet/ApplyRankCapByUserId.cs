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
using Gs2Cdk.Gs2Grade.Model;

namespace Gs2Cdk.Gs2Grade.StampSheet
{
    public class ApplyRankCapByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string gradeName;
        private string propertyId;


        public ApplyRankCapByUserId(
            string namespaceName,
            string gradeName,
            string propertyId,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.gradeName = gradeName;
            this.propertyId = propertyId;
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
            if (this.gradeName != null) {
                properties["gradeName"] = this.gradeName;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }

            return properties;
        }

        public static ApplyRankCapByUserId FromProperties(Dictionary<string, object> properties) {
            return new ApplyRankCapByUserId(
                (string)properties["namespaceName"],
                (string)properties["gradeName"],
                (string)properties["propertyId"],
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Grade:ApplyRankCapByUserId";
        }

        public static string StaticAction() {
            return "Gs2Grade:ApplyRankCapByUserId";
        }
    }
}