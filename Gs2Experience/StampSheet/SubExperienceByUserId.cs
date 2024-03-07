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
    public class SubExperienceByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string experienceName;
        private string propertyId;
        private long? experienceValue;
        private string? experienceValueString;


        public SubExperienceByUserId(
            string namespaceName,
            string experienceName,
            string propertyId,
            long? experienceValue = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.propertyId = propertyId;
            this.experienceValue = experienceValue;
            this.userId = userId;
        }


        public SubExperienceByUserId(
            string namespaceName,
            string experienceName,
            string propertyId,
            string experienceValue = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.experienceName = experienceName;
            this.propertyId = propertyId;
            this.experienceValueString = experienceValue;
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

            return properties;
        }

        public static SubExperienceByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SubExperienceByUserId(
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
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new SubExperienceByUserId(
                    properties["namespaceName"].ToString(),
                    properties["experienceName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("experienceValue", out var experienceValue) ? experienceValue.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Experience:SubExperienceByUserId";
        }

        public static string StaticAction() {
            return "Gs2Experience:SubExperienceByUserId";
        }
    }
}
