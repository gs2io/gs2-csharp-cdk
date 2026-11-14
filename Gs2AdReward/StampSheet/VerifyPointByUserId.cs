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
using Gs2Cdk.Gs2AdReward.Model;
using Gs2Cdk.Gs2AdReward.StampSheet.Enums;

namespace Gs2Cdk.Gs2AdReward.StampSheet
{
    public class VerifyPointByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private VerifyPointByUserIdVerifyType? verifyType;
        private long point;
        private string pointString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public VerifyPointByUserId(
            string namespaceName,
            VerifyPointByUserIdVerifyType verifyType,
            long point,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.verifyType = verifyType;
            this.point = point;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyPointByUserId(
            string namespaceName,
            VerifyPointByUserIdVerifyType verifyType,
            string point,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.verifyType = verifyType;
            this.pointString = point;
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
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.pointString != null) {
                properties["point"] = this.pointString;
            } else {
                if (this.point != null) {
                    properties["point"] = this.point;
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

        public static VerifyPointByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyPointByUserId(
                    (string)properties["namespaceName"],
                    new Func<VerifyPointByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyPointByUserIdVerifyType e => e,
                            string s => VerifyPointByUserIdVerifyTypeExt.New(s),
                            _ => VerifyPointByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<long>(() =>
                    {
                        return properties["point"] switch {
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
                return new VerifyPointByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<VerifyPointByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyPointByUserIdVerifyType e => e,
                            string s => VerifyPointByUserIdVerifyTypeExt.New(s),
                            _ => VerifyPointByUserIdVerifyType.Less
                        };
                    })(),
                    properties["point"].ToString(),
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
            return "Gs2AdReward:VerifyPointByUserId";
        }

        public static string StaticAction() {
            return "Gs2AdReward:VerifyPointByUserId";
        }
    }
}
