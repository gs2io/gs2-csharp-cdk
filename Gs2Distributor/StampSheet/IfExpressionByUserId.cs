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
    public class IfExpressionByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private VerifyAction condition;
        private ConsumeAction[] trueActions;
        private ConsumeAction[] falseActions;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;
        private string timeOffsetToken;


        public IfExpressionByUserId(
            string namespaceName,
            VerifyAction condition,
            ConsumeAction[] trueActions = null,
            ConsumeAction[] falseActions = null,
            bool? multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.condition = condition;
            this.trueActions = trueActions;
            this.falseActions = falseActions;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public IfExpressionByUserId(
            string namespaceName,
            VerifyAction condition,
            ConsumeAction[] trueActions = null,
            ConsumeAction[] falseActions = null,
            string multiplyValueSpecifyingQuantity = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.condition = condition;
            this.trueActions = trueActions;
            this.falseActions = falseActions;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
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
            if (this.condition != null) {
                properties["condition"] = this.condition?.Properties(
                );
            }
            if (this.trueActions != null) {
                properties["trueActions"] = this.trueActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.falseActions != null) {
                properties["falseActions"] = this.falseActions.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static IfExpressionByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new IfExpressionByUserId(
                    (string)properties["namespaceName"],
                    new Func<VerifyAction>(() =>
                    {
                        return properties["condition"] switch {
                            VerifyAction v => v,
                            VerifyAction[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => VerifyAction.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? VerifyAction.FromProperties(v.First()) : null,
                            _ => null
                        };
                    })(),
                    new Func<ConsumeAction[]>(() =>
                    {
                        return properties.TryGetValue("trueActions", out var trueActions) ? trueActions switch {
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ConsumeAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ConsumeAction).ToArray(),
                            { } v => new []{ v as ConsumeAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<ConsumeAction[]>(() =>
                    {
                        return properties.TryGetValue("falseActions", out var falseActions) ? falseActions switch {
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ConsumeAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ConsumeAction).ToArray(),
                            { } v => new []{ v as ConsumeAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
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
                return new IfExpressionByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<VerifyAction>(() =>
                    {
                        return properties["condition"] switch {
                            VerifyAction v => v,
                            VerifyAction[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => VerifyAction.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? VerifyAction.FromProperties(v.First()) : null,
                            _ => null
                        };
                    })(),
                    new Func<ConsumeAction[]>(() =>
                    {
                        return properties.TryGetValue("trueActions", out var trueActions) ? trueActions switch {
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ConsumeAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ConsumeAction).ToArray(),
                            { } v => new []{ v as ConsumeAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<ConsumeAction[]>(() =>
                    {
                        return properties.TryGetValue("falseActions", out var falseActions) ? falseActions switch {
                            Dictionary<string, object>[] v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ ConsumeAction.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(ConsumeAction.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as ConsumeAction).ToArray(),
                            { } v => new []{ v as ConsumeAction },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
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
            return "Gs2Distributor:IfExpressionByUserId";
        }

        public static string StaticAction() {
            return "Gs2Distributor:IfExpressionByUserId";
        }
    }
}
