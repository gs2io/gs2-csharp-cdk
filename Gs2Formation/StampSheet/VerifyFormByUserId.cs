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
using Gs2Cdk.Gs2Formation.Model;
using Gs2Cdk.Gs2Formation.StampSheet.Enums;

namespace Gs2Cdk.Gs2Formation.StampSheet
{
    public class VerifyFormByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private string moldModelName;
        private int index;
        private string indexString;
        private string propertyIdRegex;
        private VerifyFormByUserIdVerifyType? verifyType;
        private int count;
        private string countString;
        private string slotName;
        private VerifyFormByUserIdCountType? countType;
        private string timeOffsetToken;


        public VerifyFormByUserId(
            string namespaceName,
            string moldModelName,
            int index,
            string propertyIdRegex,
            VerifyFormByUserIdVerifyType verifyType,
            int count,
            string slotName = null,
            VerifyFormByUserIdCountType? countType = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.index = index;
            this.propertyIdRegex = propertyIdRegex;
            this.verifyType = verifyType;
            this.count = count;
            this.slotName = slotName;
            this.countType = countType;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public VerifyFormByUserId(
            string namespaceName,
            string moldModelName,
            string index,
            string propertyIdRegex,
            VerifyFormByUserIdVerifyType verifyType,
            string count,
            string slotName = null,
            VerifyFormByUserIdCountType? countType = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.indexString = index;
            this.propertyIdRegex = propertyIdRegex;
            this.verifyType = verifyType;
            this.countString = count;
            this.slotName = slotName;
            this.countType = countType;
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
            if (this.moldModelName != null) {
                properties["moldModelName"] = this.moldModelName;
            }
            if (this.indexString != null) {
                properties["index"] = this.indexString;
            } else {
                if (this.index != null) {
                    properties["index"] = this.index;
                }
            }
            if (this.slotName != null) {
                properties["slotName"] = this.slotName;
            }
            if (this.propertyIdRegex != null) {
                properties["propertyIdRegex"] = this.propertyIdRegex;
            }
            if (this.countType != null) {
                properties["countType"] = this.countType.Value.Str(
                );
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static VerifyFormByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyFormByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["moldModelName"],
                    new Func<int>(() =>
                    {
                        return properties["index"] switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        };
                    })(),
                    (string)properties["propertyIdRegex"],
                    new Func<VerifyFormByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFormByUserIdVerifyType e => e,
                            string s => VerifyFormByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFormByUserIdVerifyType.Less
                        };
                    })(),
                    new Func<int>(() =>
                    {
                        return properties["count"] switch {
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
                        return properties.TryGetValue("slotName", out var slotName) ? slotName as string : null;
                    })(),
                    new Func<VerifyFormByUserIdCountType?>(() =>
                    {
                        return properties.TryGetValue("countType", out var countType) ? countType switch {
                            VerifyFormByUserIdCountType e => e,
                            string s => VerifyFormByUserIdCountTypeExt.New(s),
                            _ => VerifyFormByUserIdCountType.Match
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
                return new VerifyFormByUserId(
                    properties["namespaceName"].ToString(),
                    properties["moldModelName"].ToString(),
                    properties["index"].ToString(),
                    properties["propertyIdRegex"].ToString(),
                    new Func<VerifyFormByUserIdVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyFormByUserIdVerifyType e => e,
                            string s => VerifyFormByUserIdVerifyTypeExt.New(s),
                            _ => VerifyFormByUserIdVerifyType.Less
                        };
                    })(),
                    properties["count"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("slotName", out var slotName) ? slotName.ToString() : null;
                    })(),
                    new Func<VerifyFormByUserIdCountType?>(() =>
                    {
                        return properties.TryGetValue("countType", out var countType) ? countType switch {
                            VerifyFormByUserIdCountType e => e,
                            string s => VerifyFormByUserIdCountTypeExt.New(s),
                            _ => VerifyFormByUserIdCountType.Match
                        } : null;
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
            return "Gs2Formation:VerifyFormByUserId";
        }

        public static string StaticAction() {
            return "Gs2Formation:VerifyFormByUserId";
        }
    }
}
