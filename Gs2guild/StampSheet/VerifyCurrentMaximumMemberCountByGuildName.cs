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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Guild.Model;
using Gs2Cdk.Gs2Guild.StampSheet.Enums;

namespace Gs2Cdk.Gs2Guild.StampSheet
{
    public class VerifyCurrentMaximumMemberCountByGuildName : VerifyAction {
        private string namespaceName;
        private string guildModelName;
        private string guildName;
        private VerifyCurrentMaximumMemberCountByGuildNameVerifyType? verifyType;
        private int? value;
        private string valueString;
        private bool? multiplyValueSpecifyingQuantity;
        private string multiplyValueSpecifyingQuantityString;


        public VerifyCurrentMaximumMemberCountByGuildName(
            string namespaceName,
            string guildModelName,
            string guildName,
            VerifyCurrentMaximumMemberCountByGuildNameVerifyType verifyType,
            int? value = null,
            bool? multiplyValueSpecifyingQuantity = null
        ){

            this.namespaceName = namespaceName;
            this.guildModelName = guildModelName;
            this.guildName = guildName;
            this.verifyType = verifyType;
            this.value = value;
            this.multiplyValueSpecifyingQuantity = multiplyValueSpecifyingQuantity;
        }


        public VerifyCurrentMaximumMemberCountByGuildName(
            string namespaceName,
            string guildModelName,
            string guildName,
            VerifyCurrentMaximumMemberCountByGuildNameVerifyType verifyType,
            string value = null,
            string multiplyValueSpecifyingQuantity = null
        ){

            this.namespaceName = namespaceName;
            this.guildModelName = guildModelName;
            this.guildName = guildName;
            this.verifyType = verifyType;
            this.valueString = value;
            this.multiplyValueSpecifyingQuantityString = multiplyValueSpecifyingQuantity;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.guildModelName != null) {
                properties["guildModelName"] = this.guildModelName;
            }
            if (this.guildName != null) {
                properties["guildName"] = this.guildName;
            }
            if (this.verifyType != null) {
                properties["verifyType"] = this.verifyType.Value.Str(
                );
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }
            if (this.multiplyValueSpecifyingQuantityString != null) {
                properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantityString;
            } else {
                if (this.multiplyValueSpecifyingQuantity != null) {
                    properties["multiplyValueSpecifyingQuantity"] = this.multiplyValueSpecifyingQuantity;
                }
            }

            return properties;
        }

        public static VerifyCurrentMaximumMemberCountByGuildName FromProperties(Dictionary<string, object> properties) {
            try {
                return new VerifyCurrentMaximumMemberCountByGuildName(
                    (string)properties["namespaceName"],
                    (string)properties["guildModelName"],
                    (string)properties["guildName"],
                    new Func<VerifyCurrentMaximumMemberCountByGuildNameVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCurrentMaximumMemberCountByGuildNameVerifyType e => e,
                            string s => VerifyCurrentMaximumMemberCountByGuildNameVerifyTypeExt.New(s),
                            _ => VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Less
                        };
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("value", out var value) ? value switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new VerifyCurrentMaximumMemberCountByGuildName(
                    properties["namespaceName"].ToString(),
                    properties["guildModelName"].ToString(),
                    properties["guildName"].ToString(),
                    new Func<VerifyCurrentMaximumMemberCountByGuildNameVerifyType>(() =>
                    {
                        return properties["verifyType"] switch {
                            VerifyCurrentMaximumMemberCountByGuildNameVerifyType e => e,
                            string s => VerifyCurrentMaximumMemberCountByGuildNameVerifyTypeExt.New(s),
                            _ => VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Less
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("value", out var value) ? value.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("multiplyValueSpecifyingQuantity", out var multiplyValueSpecifyingQuantity) ? multiplyValueSpecifyingQuantity.ToString() : null;
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Guild:VerifyCurrentMaximumMemberCountByGuildName";
        }

        public static string StaticAction() {
            return "Gs2Guild:VerifyCurrentMaximumMemberCountByGuildName";
        }
    }
}
