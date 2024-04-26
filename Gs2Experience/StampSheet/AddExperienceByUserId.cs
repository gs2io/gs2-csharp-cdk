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
using Gs2Cdk.Gs2Experience.Model;

namespace Gs2Cdk.Gs2Experience.StampSheet
{
    public class AddExperienceByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string experienceName;
        private string propertyId;
        private long? experienceValue;
        private string? experienceValueString;
        private bool? truncateExperienceWhenRankUp;
        private string? truncateExperienceWhenRankUpString;
        private string timeOffsetToken;


        public AddExperienceByUserId(
            string namespaceName,
            string experienceName,
            string propertyId,
            long? experienceValue = null,
            bool? truncateExperienceWhenRankUp = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.propertyId = propertyId;
            this.experienceValue = experienceValue;
            this.truncateExperienceWhenRankUp = truncateExperienceWhenRankUp;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public AddExperienceByUserId(
            string namespaceName,
            string experienceName,
            string propertyId,
            string experienceValue = null,
            string truncateExperienceWhenRankUp = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.propertyId = propertyId;
            this.experienceValueString = experienceValue;
            this.truncateExperienceWhenRankUpString = truncateExperienceWhenRankUp;
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
            if (this.experienceName != null) {
                properties["experienceName"] = this.experienceName;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.experienceValueString != null) {
                properties["experienceValue"] = this.experienceValueString;
            } else {
                if (this.experienceValue != null) {
                    properties["experienceValue"] = this.experienceValue;
                }
            }
            if (this.truncateExperienceWhenRankUpString != null) {
                properties["truncateExperienceWhenRankUp"] = this.truncateExperienceWhenRankUpString;
            } else {
                if (this.truncateExperienceWhenRankUp != null) {
                    properties["truncateExperienceWhenRankUp"] = this.truncateExperienceWhenRankUp;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static AddExperienceByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AddExperienceByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["experienceName"],
                    (string)properties["propertyId"],
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("experienceValue", out var experienceValue) ? experienceValue switch {
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
                        return properties.TryGetValue("truncateExperienceWhenRankUp", out var truncateExperienceWhenRankUp) ? truncateExperienceWhenRankUp switch {
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
                return new AddExperienceByUserId(
                    properties["namespaceName"].ToString(),
                    properties["experienceName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("experienceValue", out var experienceValue) ? experienceValue.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("truncateExperienceWhenRankUp", out var truncateExperienceWhenRankUp) ? truncateExperienceWhenRankUp.ToString() : null;
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
            return "Gs2Experience:AddExperienceByUserId";
        }

        public static string StaticAction() {
            return "Gs2Experience:AddExperienceByUserId";
        }
    }
}
