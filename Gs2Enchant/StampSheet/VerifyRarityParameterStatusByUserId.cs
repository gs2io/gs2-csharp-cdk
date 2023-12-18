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
using Gs2Cdk.Gs2Enchant.Model;
using Gs2Cdk.Gs2Enchant.Model.Enums;

namespace Gs2Cdk.Gs2Enchant.StampSheet
{
    public class VerifyRarityParameterStatusByUserId : ConsumeAction {
        private string namespaceName;
        private string parameterName;
        private string userId;
        private string propertyId;
        private RarityParameterStatusVerifyType? verifyType;
        private string parameterValueName;
        private int? parameterCount;


        public VerifyRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            RarityParameterStatusVerifyType verifyType,
            string parameterValueName = null,
            int? parameterCount = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.verifyType = verifyType;
            this.parameterValueName = parameterValueName;
            this.parameterCount = parameterCount;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.parameterName != null) {
                properties["parameterName"] = this.parameterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.parameterValueName != null) {
                properties["parameterValueName"] = this.parameterValueName;
            }
            if (this.parameterCount != null) {
                properties["parameterCount"] = this.parameterCount;
            }

            return properties;
        }

        public static VerifyRarityParameterStatusByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyRarityParameterStatusByUserId(
                (string)properties["namespaceName"],
                (string)properties["parameterName"],
                (string)properties["propertyId"],
                new Func<RarityParameterStatusVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        RarityParameterStatusVerifyType e => e,
                        string s => RarityParameterStatusVerifyTypeExt.New(s),
                        _ => RarityParameterStatusVerifyType.Havent
                    };
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("parameterValueName", out var parameterValueName) ? parameterValueName as string : null;
                })(),
                new Func<int?>(() =>
                {
                    return properties.TryGetValue("parameterCount", out var parameterCount) ? parameterCount switch {
                        long v => (int)v,
                        int v => (int)v,
                        float v => (int)v,
                        double v => (int)v,
                        string v => int.Parse(v),
                        _ => 0
                    } : null;
                })(),
                new Func<string>(() =>
                {
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Enchant:VerifyRarityParameterStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enchant:VerifyRarityParameterStatusByUserId";
        }
    }
}
