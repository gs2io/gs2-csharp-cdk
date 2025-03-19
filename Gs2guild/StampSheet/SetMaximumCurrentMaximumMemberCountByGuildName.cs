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

namespace Gs2Cdk.Gs2Guild.StampSheet
{
    public class SetMaximumCurrentMaximumMemberCountByGuildName : AcquireAction {
        private string namespaceName;
        private string guildName;
        private string guildModelName;
        private int? value;
        private string valueString;


        public SetMaximumCurrentMaximumMemberCountByGuildName(
            string namespaceName,
            string guildName,
            string guildModelName,
            int? value = null
        ){

            this.namespaceName = namespaceName;
            this.guildName = guildName;
            this.guildModelName = guildModelName;
            this.value = value;
        }


        public SetMaximumCurrentMaximumMemberCountByGuildName(
            string namespaceName,
            string guildName,
            string guildModelName,
            string value = null
        ){

            this.namespaceName = namespaceName;
            this.guildName = guildName;
            this.guildModelName = guildModelName;
            this.valueString = value;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.guildName != null) {
                properties["guildName"] = this.guildName;
            }
            if (this.guildModelName != null) {
                properties["guildModelName"] = this.guildModelName;
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }

            return properties;
        }

        public static SetMaximumCurrentMaximumMemberCountByGuildName FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetMaximumCurrentMaximumMemberCountByGuildName(
                    (string)properties["namespaceName"],
                    (string)properties["guildName"],
                    (string)properties["guildModelName"],
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
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new SetMaximumCurrentMaximumMemberCountByGuildName(
                    properties["namespaceName"].ToString(),
                    properties["guildName"].ToString(),
                    properties["guildModelName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("value", out var value) ? value.ToString() : null;
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Guild:SetMaximumCurrentMaximumMemberCountByGuildName";
        }

        public static string StaticAction() {
            return "Gs2Guild:SetMaximumCurrentMaximumMemberCountByGuildName";
        }
    }
}
