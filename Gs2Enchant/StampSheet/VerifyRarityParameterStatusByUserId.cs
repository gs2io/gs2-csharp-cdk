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
using Gs2Cdk.Gs2Enchant.StampSheet.Enums;

namespace Gs2Cdk.Gs2Enchant.StampSheet
{
    public class VerifyRarityParameterStatusByUserId : ConsumeAction {
        private string namespaceName;
        private string parameterName;
        private string userId;
        private string propertyId;
        private VerifyRarityParameterStatusByUserIdVerifyType? verifyType;
        private string parameterValueName;
        private int? parameterCount;
        private string? parameterCountString;
        private bool? multiplyValueSpecifyingQuantity;
        private string? multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            VerifyRarityParameterStatusByUserIdVerifyType verifyType,
            string parameterValueName = null,
            int? parameterCount = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.verifyType = verifyType;
            this.parameterValueName = parameterValueName;
            this.parameterCount = parameterCount;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            VerifyRarityParameterStatusByUserIdVerifyType verifyType,
            string parameterValueName = null,
            string parameterCount = null,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.verifyType = verifyType;
            this.parameterValueName = parameterValueName;
            this.parameterCountString = parameterCount;
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
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.parameterValueName != null) {
                properties["parameterValueName"] = this.parameterValueName;
            }
            if (this.parameterCountString != null) {
                properties["parameterCount"] = this.parameterCountString;
            } else {
                if (this.parameterCount != null) {
                    properties["parameterCount"] = this.parameterCount;
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

        public static VerifyRarityParameterStatusByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyRarityParameterStatusByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["parameterName"],
                    (string)properties["propertyId"],
                    new Func<VerifyRarityParameterStatusByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRarityParameterStatusByUserIdVerifyType e => e,
                            string s => VerifyRarityParameterStatusByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRarityParameterStatusByUserIdVerifyType.Havent
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
                return new VerifyRarityParameterStatusByUserId(
                    properties["namespaceName"].ToString(),
                    properties["parameterName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<VerifyRarityParameterStatusByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRarityParameterStatusByUserIdVerifyType e => e,
                            string s => VerifyRarityParameterStatusByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRarityParameterStatusByUserIdVerifyType.Havent
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("parameterValueName", out var parameterValueName) ? parameterValueName.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("parameterCount", out var parameterCount) ? parameterCount.ToString() : null;
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
            return "Gs2Enchant:VerifyRarityParameterStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enchant:VerifyRarityParameterStatusByUserId";
        }
    }
}
