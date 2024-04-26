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
    public class VerifyGradeUpMaterialByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string gradeName;
        private VerifyGradeUpMaterialByUserIdVerifyType? verifyType;
        private string propertyId;
        private string materialPropertyId;
        private string timeOffsetToken;


        public VerifyGradeUpMaterialByUserId(
            string namespaceName,
            string gradeName,
            VerifyGradeUpMaterialByUserIdVerifyType verifyType,
            string propertyId,
            string materialPropertyId,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.gradeName = gradeName;
            this.verifyType = verifyType;
            this.propertyId = propertyId;
            this.materialPropertyId = materialPropertyId;
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
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.materialPropertyId != null) {
                properties["materialPropertyId"] = this.materialPropertyId;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyGradeUpMaterialByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyGradeUpMaterialByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["gradeName"],
                    new Func<VerifyGradeUpMaterialByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyGradeUpMaterialByUserIdVerifyType e => e,
                            string s => VerifyGradeUpMaterialByUserIdVerifyTypeExt.New(s),
                            _ => VerifyGradeUpMaterialByUserIdVerifyType.Match
                        };
                    })(),
                    (string)properties["propertyId"],
                    (string)properties["materialPropertyId"],
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
                return new VerifyGradeUpMaterialByUserId(
                    properties["namespaceName"].ToString(),
                    properties["gradeName"].ToString(),
                    new Func<VerifyGradeUpMaterialByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyGradeUpMaterialByUserIdVerifyType e => e,
                            string s => VerifyGradeUpMaterialByUserIdVerifyTypeExt.New(s),
                            _ => VerifyGradeUpMaterialByUserIdVerifyType.Match
                        };
                    })(),
                    properties["propertyId"].ToString(),
                    properties["materialPropertyId"].ToString(),
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
            return "Gs2Grade:VerifyGradeUpMaterialByUserId";
        }

        public static string StaticAction() {
            return "Gs2Grade:VerifyGradeUpMaterialByUserId";
        }
    }
}
