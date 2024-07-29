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
using Gs2Cdk.Gs2Distributor.Model;

namespace Gs2Cdk.Gs2Distributor.StampSheet
{
    public class OrExpressionByUserId : VerifyAction {
        private string namespaceName;
        private string userId;
        private VerifyAction[] actions;
        private string timeOffsetToken;


        public OrExpressionByUserId(
            string namespaceName,
            VerifyAction[] actions = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.actions = actions;
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
            if (this.actions != null) {
                properties["actions"] = this.actions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static OrExpressionByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new OrExpressionByUserId(
                    (string)properties["namespaceName"],
                    new Func<VerifyAction[]>(() =>
                    {
                        return properties.TryGetValue("actions", out var actions) ? actions switch {
                            Dictionary<string, object>[] v => v.Select(VerifyAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ VerifyAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(VerifyAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as VerifyAction).ToArray(),
                            { } v => new []{ v as VerifyAction },
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
                return new OrExpressionByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<VerifyAction[]>(() =>
                    {
                        return properties.TryGetValue("actions", out var actions) ? actions switch {
                            Dictionary<string, object>[] v => v.Select(VerifyAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ VerifyAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(VerifyAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as VerifyAction).ToArray(),
                            { } v => new []{ v as VerifyAction },
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
            return "Gs2Distributor:OrExpressionByUserId";
        }

        public static string StaticAction() {
            return "Gs2Distributor:OrExpressionByUserId";
        }
    }
}
