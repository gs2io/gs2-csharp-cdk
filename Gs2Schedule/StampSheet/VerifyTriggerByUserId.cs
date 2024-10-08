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
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.StampSheet.Enums;

namespace Gs2Cdk.Gs2Schedule.StampSheet
{
    public class VerifyTriggerByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string triggerName;
        private VerifyTriggerByUserIdVerifyType? verifyType;
        private int? elapsedMinutes;
        private string elapsedMinutesString;
        private string timeOffsetToken;


        public VerifyTriggerByUserId(
            string namespaceName,
            string triggerName,
            VerifyTriggerByUserIdVerifyType verifyType,
            int? elapsedMinutes = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.verifyType = verifyType;
            this.elapsedMinutes = elapsedMinutes;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyTriggerByUserId(
            string namespaceName,
            string triggerName,
            VerifyTriggerByUserIdVerifyType verifyType,
            string elapsedMinutes = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.verifyType = verifyType;
            this.elapsedMinutesString = elapsedMinutes;
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
            if (this.triggerName != null) {
                properties["triggerName"] = this.triggerName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.elapsedMinutesString != null) {
                properties["elapsedMinutes"] = this.elapsedMinutesString;
            } else {
                if (this.elapsedMinutes != null) {
                    properties["elapsedMinutes"] = this.elapsedMinutes;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyTriggerByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyTriggerByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["triggerName"],
                    new Func<VerifyTriggerByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyTriggerByUserIdVerifyType e => e,
                            string s => VerifyTriggerByUserIdVerifyTypeExt.New(s),
                            _ => VerifyTriggerByUserIdVerifyType.NotTriggerd
                        };
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("elapsedMinutes", out var elapsedMinutes) ? elapsedMinutes switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
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
                return new VerifyTriggerByUserId(
                    properties["namespaceName"].ToString(),
                    properties["triggerName"].ToString(),
                    new Func<VerifyTriggerByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyTriggerByUserIdVerifyType e => e,
                            string s => VerifyTriggerByUserIdVerifyTypeExt.New(s),
                            _ => VerifyTriggerByUserIdVerifyType.NotTriggerd
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("elapsedMinutes", out var elapsedMinutes) ? elapsedMinutes.ToString() : null;
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
            return "Gs2Schedule:VerifyTriggerByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:VerifyTriggerByUserId";
        }
    }
}
