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


        public SetRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            RarityParameterValue[] parameterValues = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.parameterValues = parameterValues;
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

            return properties;
        }

        public static SetRarityParameterStatusByUserId FromProperties(Dictionary<string, object> properties) {
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
                    return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                })()
            );
        }

        public override string Action() {
            return "Gs2Enchant:SetRarityParameterStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enchant:SetRarityParameterStatusByUserId";
        }
    }
}
