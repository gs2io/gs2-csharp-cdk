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
    public class VerifyCompleteByUserId : ConsumeAction {
        private string namespaceName;
        private string missionGroupName;
        private string userId;
        private VerifyCompleteByUserIdVerifyType? verifyType;
        private string missionTaskName;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyCompleteByUserId(
            string namespaceName,
            string missionGroupName,
            VerifyCompleteByUserIdVerifyType verifyType,
            string missionTaskName,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.missionGroupName = missionGroupName;
            this.verifyType = verifyType;
            this.missionTaskName = missionTaskName;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyCompleteByUserId(
            string namespaceName,
            string missionGroupName,
            VerifyCompleteByUserIdVerifyType verifyType,
            string missionTaskName,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.missionGroupName = missionGroupName;
            this.verifyType = verifyType;
            this.missionTaskName = missionTaskName;
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
            if (this.missionGroupName != null) {
                properties["missionGroupName"] = this.missionGroupName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.missionTaskName != null) {
                properties["missionTaskName"] = this.missionTaskName;
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

        public static VerifyCompleteByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCompleteByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["missionGroupName"],
                    new Func<VerifyCompleteByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCompleteByUserIdVerifyType e => e,
                            string s => VerifyCompleteByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCompleteByUserIdVerifyType.Completed
                        };
                    })(),
                    (string)properties["missionTaskName"],
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
                return new VerifyCompleteByUserId(
                    properties["namespaceName"].ToString(),
                    properties["missionGroupName"].ToString(),
                    new Func<VerifyCompleteByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCompleteByUserIdVerifyType e => e,
                            string s => VerifyCompleteByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCompleteByUserIdVerifyType.Completed
                        };
                    })(),
                    properties["missionTaskName"].ToString(),
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
            return "Gs2Mission:VerifyCompleteByUserId";
        }

        public static string StaticAction() {
            return "Gs2Mission:VerifyCompleteByUserId";
        }
    }
}
