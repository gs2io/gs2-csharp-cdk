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
using Gs2Cdk.Gs2Grade.Model;

namespace Gs2Cdk.Gs2Grade.StampSheet
{
    public class AddGradeByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string gradeName;
        private string propertyId;
        private long? gradeValue;
        private string? gradeValueString;
        private string timeOffsetToken;


        public AddGradeByUserId(
            string namespaceName,
            string gradeName,
            string propertyId,
            long? gradeValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.gradeName = gradeName;
            this.propertyId = propertyId;
            this.gradeValue = gradeValue;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public AddGradeByUserId(
            string namespaceName,
            string gradeName,
            string propertyId,
            string gradeValue = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.gradeName = gradeName;
            this.propertyId = propertyId;
            this.gradeValueString = gradeValue;
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
            if (this.gradeName != null) {
                properties["gradeName"] = this.gradeName;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.gradeValueString != null) {
                properties["gradeValue"] = this.gradeValueString;
            } else {
                if (this.gradeValue != null) {
                    properties["gradeValue"] = this.gradeValue;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static AddGradeByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AddGradeByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["gradeName"],
                    (string)properties["propertyId"],
                    new Func<long?>(() =>
                    {
                        return properties.TryGetValue("gradeValue", out var gradeValue) ? gradeValue switch {
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
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new AddGradeByUserId(
                    properties["namespaceName"].ToString(),
                    properties["gradeName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("gradeValue", out var gradeValue) ? gradeValue.ToString() : null;
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
            return "Gs2Grade:AddGradeByUserId";
        }

        public static string StaticAction() {
            return "Gs2Grade:AddGradeByUserId";
        }
    }
}
