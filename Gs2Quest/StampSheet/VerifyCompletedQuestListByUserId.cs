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
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.StampSheet.Enums;

namespace Gs2Cdk.Gs2Quest.StampSheet
{
    public class VerifyCompletedQuestListByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string questGroupName;
        private string questName;
        private VerifyCompletedQuestListByUserIdVerifyType? verifyType;
        private string timeOffsetToken;


        public VerifyCompletedQuestListByUserId(
            string namespaceName,
            string questGroupName,
            string questName,
            VerifyCompletedQuestListByUserIdVerifyType verifyType,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.questGroupName = questGroupName;
            this.questName = questName;
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
            if (this.questGroupName != null) {
                properties["questGroupName"] = this.questGroupName;
            }
            if (this.questName != null) {
                properties["questName"] = this.questName;
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

        public static VerifyCompletedQuestListByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCompletedQuestListByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["questGroupName"],
                    (string)properties["questName"],
                    new Func<VerifyCompletedQuestListByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCompletedQuestListByUserIdVerifyType e => e,
                            string s => VerifyCompletedQuestListByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCompletedQuestListByUserIdVerifyType.Completed
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
                return new VerifyCompletedQuestListByUserId(
                    properties["namespaceName"].ToString(),
                    properties["questGroupName"].ToString(),
                    properties["questName"].ToString(),
                    new Func<VerifyCompletedQuestListByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCompletedQuestListByUserIdVerifyType e => e,
                            string s => VerifyCompletedQuestListByUserIdVerifyTypeExt.New(s),
                            _ => VerifyCompletedQuestListByUserIdVerifyType.Completed
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
            return "Gs2Quest:VerifyCompletedQuestListByUserId";
        }

        public static string StaticAction() {
            return "Gs2Quest:VerifyCompletedQuestListByUserId";
        }
    }
}
