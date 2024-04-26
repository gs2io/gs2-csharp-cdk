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
using Gs2Cdk.Gs2Enchant.Model;

namespace Gs2Cdk.Gs2Enchant.StampSheet
{
    public class SetRarityParameterStatusByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string parameterName;
        private string propertyId;
        private RarityParameterValue[] parameterValues;
        private string timeOffsetToken;


        public SetRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            RarityParameterValue[] parameterValues = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.parameterValues = parameterValues;
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
            if (this.parameterName != null) {
                properties["parameterName"] = this.parameterName;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.parameterValues != null) {
                properties["parameterValues"] = this.parameterValues.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SetRarityParameterStatusByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetRarityParameterStatusByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["parameterName"],
                    (string)properties["propertyId"],
                    new Func<RarityParameterValue[]>(() =>
                    {
                        return properties.TryGetValue("parameterValues", out var parameterValues) ? parameterValues switch {
                            Dictionary<string, object>[] v => v.Select(RarityParameterValue.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ RarityParameterValue.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(RarityParameterValue.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as RarityParameterValue).ToArray(),
                            { } v => new []{ v as RarityParameterValue },
                            _ => null
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
                return new SetRarityParameterStatusByUserId(
                    properties["namespaceName"].ToString(),
                    properties["parameterName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<RarityParameterValue[]>(() =>
                    {
                        return properties.TryGetValue("parameterValues", out var parameterValues) ? parameterValues switch {
                            Dictionary<string, object>[] v => v.Select(RarityParameterValue.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ RarityParameterValue.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(RarityParameterValue.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as RarityParameterValue).ToArray(),
                            { } v => new []{ v as RarityParameterValue },
                            _ => null
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
            return "Gs2Enchant:SetRarityParameterStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enchant:SetRarityParameterStatusByUserId";
        }
    }
}
