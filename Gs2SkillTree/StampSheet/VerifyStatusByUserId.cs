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
using Gs2Cdk.Gs2SkillTree.Model;
using Gs2Cdk.Gs2SkillTree.StampSheet.Enums;

namespace Gs2Cdk.Gs2SkillTree.StampSheet
{
    public class VerifyStatusByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string propertyId;
        private string nodeModelName;
        private VerifyStatusByUserIdVerifyType? verifyType;
        private string timeOffsetToken;


        public VerifyStatusByUserId(
            string namespaceName,
            string propertyId,
            string nodeModelName,
            VerifyStatusByUserIdVerifyType verifyType,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.propertyId = propertyId;
            this.nodeModelName = nodeModelName;
            this.verifyType = verifyType;
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
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.nodeModelName != null) {
                properties["nodeModelName"] = this.nodeModelName;
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

        public static VerifyStatusByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyStatusByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["propertyId"],
                    (string)properties["nodeModelName"],
                    new Func<VerifyStatusByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyStatusByUserIdVerifyType e => e,
                            string s => VerifyStatusByUserIdVerifyTypeExt.New(s),
                            _ => VerifyStatusByUserIdVerifyType.Released
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
                return new VerifyStatusByUserId(
                    properties["namespaceName"].ToString(),
                    properties["propertyId"].ToString(),
                    properties["nodeModelName"].ToString(),
                    new Func<VerifyStatusByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyStatusByUserIdVerifyType e => e,
                            string s => VerifyStatusByUserIdVerifyTypeExt.New(s),
                            _ => VerifyStatusByUserIdVerifyType.Released
                        };
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
            return "Gs2SkillTree:VerifyStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2SkillTree:VerifyStatusByUserId";
        }
    }
}
