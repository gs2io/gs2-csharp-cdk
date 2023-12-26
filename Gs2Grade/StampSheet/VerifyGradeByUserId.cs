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
using Gs2Cdk.Gs2Grade.StampSheet.Enums;

namespace Gs2Cdk.Gs2Grade.StampSheet
{
    public class VerifyGradeByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string gradeName;
        private VerifyGradeByUserIdVerifyType? verifyType;
        private string propertyId;
        private long? gradeValue;


        public VerifyGradeByUserId(
            string namespaceName,
            string gradeName,
            VerifyGradeByUserIdVerifyType verifyType,
            string propertyId,
            long? gradeValue = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.gradeName = gradeName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.gradeValue = gradeValue;
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
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.gradeValue != null) {
                properties["gradeValue"] = this.gradeValue;
            }

            return properties;
        }

        public static VerifyGradeByUserId FromProperties(Dictionary<string, object> properties) {
            return new VerifyGradeByUserId(
                (string)properties["namespaceName"],
                (string)properties["gradeName"],
                new Func<VerifyGradeByUserIdVerifyType>(() =>
                {
                    return properties["verifyType"] switch {
                        VerifyGradeByUserIdVerifyType e => e,
                        string s => VerifyGradeByUserIdVerifyTypeExt.New(s),
                        _ => VerifyGradeByUserIdVerifyType.Less
                    };
                })(),
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
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Grade:VerifyGradeByUserId";
        }

        public static string StaticAction() {
            return "Gs2Grade:VerifyGradeByUserId";
        }
    }
}
