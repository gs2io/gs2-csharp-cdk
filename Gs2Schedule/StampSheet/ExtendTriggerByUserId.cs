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

namespace Gs2Cdk.Gs2Schedule.StampSheet
{
    public class ExtendTriggerByUserId : AcquireAction {
        private string namespaceName;
        private string triggerName;
        private string userId;
        private int extendSeconds;
        private string extendSecondsString;
        private string timeOffsetToken;


        public ExtendTriggerByUserId(
            string namespaceName,
            string triggerName,
            int extendSeconds,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.extendSeconds = extendSeconds;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public ExtendTriggerByUserId(
            string namespaceName,
            string triggerName,
            string extendSeconds,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.triggerName = triggerName;
            this.extendSecondsString = extendSeconds;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.triggerName != null) {
                properties["triggerName"] = this.triggerName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.extendSecondsString != null) {
                properties["extendSeconds"] = this.extendSecondsString;
            } else {
                if (this.extendSeconds != null) {
                    properties["extendSeconds"] = this.extendSeconds;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static ExtendTriggerByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new ExtendTriggerByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["triggerName"],
                    new Func<int>(() =>
                    {
                        return properties["extendSeconds"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
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
                return new ExtendTriggerByUserId(
                    properties["namespaceName"].ToString(),
                    properties["triggerName"].ToString(),
                    properties["extendSeconds"].ToString(),
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
            return "Gs2Schedule:ExtendTriggerByUserId";
        }

        public static string StaticAction() {
            return "Gs2Schedule:ExtendTriggerByUserId";
        }
    }
}
