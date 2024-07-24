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
using Gs2Cdk.Gs2Mission.Model;
using Gs2Cdk.Gs2Mission.StampSheet.Enums;

namespace Gs2Cdk.Gs2Mission.StampSheet
{
    public class VerifyCounterValueByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string counterName;
        private VerifyCounterValueByUserIdVerifyType? verifyType;
        private VerifyCounterValueByUserIdResetType? resetType;
        private long? value;
        private string valueString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyCounterValueByUserId(
            string namespaceName,
            string counterName,
            VerifyCounterValueByUserIdVerifyType verifyType,
            VerifyCounterValueByUserIdResetType resetType,
            long? value = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.counterName = counterName;
            this.verifyType = verifyType;
            this.resetType = resetType;
            this.value = value;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyCounterValueByUserId(
            string namespaceName,
            string counterName,
            VerifyCounterValueByUserIdVerifyType verifyType,
            VerifyCounterValueByUserIdResetType resetType,
            string value = null,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.counterName = counterName;
            this.verifyType = verifyType;
            this.resetType = resetType;
            this.valueString = value;
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
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.resetType != null) {
                properties["resetType"] = this.resetType.Value.Str(
                );
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
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

        public static VerifyCounterValueByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCounterValueByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["counterName"],
                    new Func<VerifyCounterValueByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCounterValueByUserIdVerifyType e => e,
                            string s => VerifyCounterValueByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCounterValueByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<VerifyCounterValueByUserIdResetType>(() =>
                    {
                        return properties["resetType"] switch {
                            VerifyCounterValueByUserIdResetType e => e,
                            string s => VerifyCounterValueByUserIdResetTypeExt.New(s),
                            _ => VerifyCounterValueByUserIdResetType.NotReset
                        };
                    })(),
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("value", out var value) ? value switch {
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
                return new VerifyCounterValueByUserId(
                    properties["namespaceName"].ToString(),
                    properties["counterName"].ToString(),
                    new Func<VerifyCounterValueByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCounterValueByUserIdVerifyType e => e,
                            string s => VerifyCounterValueByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCounterValueByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<VerifyCounterValueByUserIdResetType>(() =>
                    {
                        return properties["resetType"] switch {
                            VerifyCounterValueByUserIdResetType e => e,
                            string s => VerifyCounterValueByUserIdResetTypeExt.New(s),
                            _ => VerifyCounterValueByUserIdResetType.NotReset
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("value", out var value) ? value.ToString() : null;
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
            return "Gs2Mission:VerifyCounterValueByUserId";
        }

        public static string StaticAction() {
            return "Gs2Mission:VerifyCounterValueByUserId";
        }
    }
}
