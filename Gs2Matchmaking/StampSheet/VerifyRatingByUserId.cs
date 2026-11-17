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
using Gs2Cdk.Gs2Matchmaking.Model;
using Gs2Cdk.Gs2Matchmaking.StampSheet.Enums;

namespace Gs2Cdk.Gs2Matchmaking.StampSheet
{
    public class VerifyRatingByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string ratingName;
        private VerifyRatingByUserIdVerifyType? verifyType;
        private float rateValue;
        private string rateValueString;
        private string timeOffsetToken;


        public VerifyRatingByUserId(
            string namespaceName,
            string ratingName,
            VerifyRatingByUserIdVerifyType verifyType,
            float rateValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.ratingName = ratingName;
            this.verifyType = verifyType;
            this.rateValue = rateValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyRatingByUserId(
            string namespaceName,
            string ratingName,
            VerifyRatingByUserIdVerifyType verifyType,
            string rateValue,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.ratingName = ratingName;
            this.verifyType = verifyType;
            this.rateValueString = rateValue;
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
            if (this.ratingName != null) {
                properties["ratingName"] = this.ratingName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.rateValueString != null) {
                properties["rateValue"] = this.rateValueString;
            } else {
                if (this.rateValue != null) {
                    properties["rateValue"] = this.rateValue;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyRatingByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyRatingByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["ratingName"],
                    new Func<VerifyRatingByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRatingByUserIdVerifyType e => e,
                            string s => VerifyRatingByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRatingByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<float>(() =>
                    {
                        return properties["rateValue"] switch {
                            long v => (float)v,
                            int v => (float)v,
                            float v => (float)v,
                            double v => (float)v,
                            string v => float.Parse(v),
                            _ => 0
                        };
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
                return new VerifyRatingByUserId(
                    properties["namespaceName"].ToString(),
                    properties["ratingName"].ToString(),
                    new Func<VerifyRatingByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyRatingByUserIdVerifyType e => e,
                            string s => VerifyRatingByUserIdVerifyTypeExt.New(s),
                            _ => VerifyRatingByUserIdVerifyType.Less
                        };
                    })(),
                    properties["rateValue"].ToString(),
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
            return "Gs2Matchmaking:VerifyRatingByUserId";
        }

        public static string StaticAction() {
            return "Gs2Matchmaking:VerifyRatingByUserId";
        }
    }
}
