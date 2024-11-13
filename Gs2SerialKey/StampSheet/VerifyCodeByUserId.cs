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
using Gs2Cdk.Gs2SerialKey.Model;
using Gs2Cdk.Gs2SerialKey.StampSheet.Enums;

namespace Gs2Cdk.Gs2SerialKey.StampSheet
{
    public class VerifyCodeByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string code;
        private VerifyCodeByUserIdVerifyType? verifyType;
        private string campaignModelName;
        private string timeOffsetToken;


        public VerifyCodeByUserId(
            string namespaceName,
            string code,
            VerifyCodeByUserIdVerifyType verifyType,
            string campaignModelName = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.code = code;
            this.verifyType = verifyType;
            this.campaignModelName = campaignModelName;
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
            if (this.code != null) {
                properties["code"] = this.code;
            }
            if (this.campaignModelName != null) {
                properties["campaignModelName"] = this.campaignModelName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyCodeByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCodeByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["code"],
                    new Func<VerifyCodeByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCodeByUserIdVerifyType e => e,
                            string s => VerifyCodeByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCodeByUserIdVerifyType.Active
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("campaignModelName", out var campaignModelName) ? campaignModelName as string : null;
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
                return new VerifyCodeByUserId(
                    properties["namespaceName"].ToString(),
                    properties["code"].ToString(),
                    new Func<VerifyCodeByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCodeByUserIdVerifyType e => e,
                            string s => VerifyCodeByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCodeByUserIdVerifyType.Active
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("campaignModelName", out var campaignModelName) ? campaignModelName.ToString() : null;
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
            return "Gs2SerialKey:VerifyCodeByUserId";
        }

        public static string StaticAction() {
            return "Gs2SerialKey:VerifyCodeByUserId";
        }
    }
}
