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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.StampSheet.Enums;

namespace Gs2Cdk.Gs2Experience.StampSheet
{
    public class VerifyRankCapByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string experienceName;
        private VerifyRankCapByUserIdVerifyType? verifyType;
        private string propertyId;
        private long rankCapValue;


        public VerifyRankCapByUserId(
            string namespaceName,
            string experienceName,
            VerifyRankCapByUserIdVerifyType verifyType,
            string propertyId,
            long rankCapValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.rankCapValue = rankCapValue;
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
            if (this.experienceName != null) {
                properties["experienceName"] = this.experienceName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.rankCapValue != null) {
                properties["rankCapValue"] = this.rankCapValue;
            }

            return properties;
        }

        public static VerifyRankCapByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyRankCapByUserId(
                (string)properties["namespaceName"],
                (string)properties["experienceName"],
                new Func<VerifyRankCapByUserIdVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        VerifyRankCapByUserIdVerifyType e => e,
                        string s => VerifyRankCapByUserIdVerifyTypeExt.New(s),
                        _ => VerifyRankCapByUserIdVerifyType.Less
                    };
                })(),
                (string)properties["propertyId"],
                new Func<long>(() =>
                {
                    return properties["rankCapValue"] switch {
                        long v => (long)v,
                        int v => (long)v,
                        float v => (long)v,
                        double v => (long)v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Experience:VerifyRankCapByUserId";
        }

        public static string StaticAction() {
            return "Gs2Experience:VerifyRankCapByUserId";
        }
    }
}
