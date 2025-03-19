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
    public class VerifyRankByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string experienceName;
        private VerifyRankByUserIdVerifyType? verifyType;
        private string propertyId;
        private long? rankValue;
        private string rankValueString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyRankByUserId(
            string namespaceName,
            string experienceName,
            VerifyRankByUserIdVerifyType verifyType,
            string propertyId,
            long? rankValue = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.rankValue = rankValue;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyRankByUserId(
            string namespaceName,
            string experienceName,
            VerifyRankByUserIdVerifyType verifyType,
            string propertyId,
            string rankValue = null,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.rankValueString = rankValue;
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
            if (this.rankValueString != null) {
                properties["rankValue"] = this.rankValueString;
            } else {
                if (this.rankValue != null) {
                    properties["rankValue"] = this.rankValue;
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

        public static VerifyRankByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyRankByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["experienceName"],
                    new Func<VerifyRankByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRankByUserIdVerifyType e => e,
                            string s => VerifyRankByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRankByUserIdVerifyType.Less
                        };
                    })(),
                    (string)properties["propertyId"],
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("rankValue", out var rankValue) ? rankValue switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        } : null;
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
                return new VerifyRankByUserId(
                    properties["namespaceName"].ToString(),
                    properties["experienceName"].ToString(),
                    new Func<VerifyRankByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRankByUserIdVerifyType e => e,
                            string s => VerifyRankByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRankByUserIdVerifyType.Less
                        };
                    })(),
                    properties["propertyId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("rankValue", out var rankValue) ? rankValue.ToString() : null;
                    })(),
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
            return "Gs2Experience:VerifyRankByUserId";
        }

        public static string StaticAction() {
            return "Gs2Experience:VerifyRankByUserId";
        }
    }
}
