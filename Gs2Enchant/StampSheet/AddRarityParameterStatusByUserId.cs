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
    public class AddRarityParameterStatusByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string parameterName;
        private string propertyId;
        private int? count;
        private string? countString;


        public AddRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            int? count = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.count = count;
            this.userId = userId;
        }


        public AddRarityParameterStatusByUserId(
            string namespaceName,
            string parameterName,
            string propertyId,
            string count = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.parameterName = parameterName;
            this.propertyId = propertyId;
            this.countString = count;
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
            if (this.countString != null) {
                properties["count"] = this.countString;
            } else {
                if (this.count != null) {
                    properties["count"] = this.count;
                }
            }

            return properties;
        }

        public static AddRarityParameterStatusByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AddRarityParameterStatusByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["parameterName"],
                    (string)properties["propertyId"],
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count switch {
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
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new AddRarityParameterStatusByUserId(
                    properties["namespaceName"].ToString(),
                    properties["parameterName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("count", out var count) ? count.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Enchant:AddRarityParameterStatusByUserId";
        }

        public static string StaticAction() {
            return "Gs2Enchant:AddRarityParameterStatusByUserId";
        }
    }
}
