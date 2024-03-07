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
using Gs2Cdk.Gs2Limit.Model;

namespace Gs2Cdk.Gs2Limit.StampSheet
{
    public class CountUpByUserId : ConsumeAction {
        private string namespaceName;
        private string limitName;
        private string counterName;
        private string userId;
        private int? countUpValue;
        private string? countUpValueString;
        private int? maxValue;
        private string? maxValueString;


        public CountUpByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            int? countUpValue = null,
            int? maxValue = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.countUpValue = countUpValue;
            this.maxValue = maxValue;
            this.userId = userId;
        }


        public CountUpByUserId(
            string namespaceName,
            string limitName,
            string counterName,
            string countUpValue = null,
            string maxValue = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.limitName = limitName;
            this.counterName = counterName;
            this.countUpValueString = countUpValue;
            this.maxValueString = maxValue;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.limitName != null) {
                properties["limitName"] = this.limitName;
            }
            if (this.counterName != null) {
                properties["counterName"] = this.counterName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.countUpValueString != null) {
                properties["countUpValue"] = this.countUpValueString;
            } else {
                if (this.countUpValue != null) {
                    properties["countUpValue"] = this.countUpValue;
                }
            }
            if (this.maxValueString != null) {
                properties["maxValue"] = this.maxValueString;
            } else {
                if (this.maxValue != null) {
                    properties["maxValue"] = this.maxValue;
                }
            }

            return properties;
        }

        public static CountUpByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new CountUpByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["limitName"],
                    (string)properties["counterName"],
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("countUpValue", out var countUpValue) ? countUpValue switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("maxValue", out var maxValue) ? maxValue switch {
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
                return new CountUpByUserId(
                    properties["namespaceName"].ToString(),
                    properties["limitName"].ToString(),
                    properties["counterName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("countUpValue", out var countUpValue) ? countUpValue.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("maxValue", out var maxValue) ? maxValue.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Limit:CountUpByUserId";
        }

        public static string StaticAction() {
            return "Gs2Limit:CountUpByUserId";
        }
    }
}
