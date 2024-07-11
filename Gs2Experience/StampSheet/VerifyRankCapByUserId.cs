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
        private string rankCapValueString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyRankCapByUserId(
            string namespaceName,
            string experienceName,
            VerifyRankCapByUserIdVerifyType verifyType,
            string propertyId,
            long rankCapValue,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.rankCapValue = rankCapValue;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyRankCapByUserId(
            string namespaceName,
            string experienceName,
            VerifyRankCapByUserIdVerifyType verifyType,
            string propertyId,
            string rankCapValue,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.rankCapValueString = rankCapValue;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
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
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.rankCapValueString != null) {
                properties["rankCapValue"] = this.rankCapValueString;
            } else {
                if (this.rankCapValue != null) {
                    properties["rankCapValue"] = this.rankCapValue;
                }
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyRankCapByUserId FromProperties(Dictionary<string, object> properties) {
            try {
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
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyRankCapByUserId(
                    properties["namespaceName"].ToString(),
                    properties["experienceName"].ToString(),
                    new Func<VerifyRankCapByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRankCapByUserIdVerifyType e => e,
                            string s => VerifyRankCapByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRankCapByUserIdVerifyType.Less
                        };
                    })(),
                    properties["propertyId"].ToString(),
                    properties["rankCapValue"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Experience:VerifyRankCapByUserId";
        }

        public static string StaticAction() {
            return "Gs2Experience:VerifyRankCapByUserId";
        }
    }
}
