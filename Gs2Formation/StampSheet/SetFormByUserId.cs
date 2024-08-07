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

namespace Gs2Cdk.Gs2Formation.StampSheet
{
    public class SetFormByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string moldModelName;
        private int index;
        private string indexString;
        private Slot[] slots;
        private string timeOffsetToken;


        public SetFormByUserId(
            string namespaceName,
            string moldModelName,
            int index,
            Slot[] slots,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.index = index;
            this.slots = slots;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public SetFormByUserId(
            string namespaceName,
            string moldModelName,
            string index,
            Slot[] slots,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.moldModelName = moldModelName;
            this.indexString = index;
            this.slots = slots;
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
            if (this.slots != null) {
                properties["slots"] = this.slots.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SetFormByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SetFormByUserId(
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
                    new Func<Slot[]>(() =>
                    {
                        return properties["slots"] switch {
                            Dictionary<string, object>[] v => v.Select(Slot.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Slot.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Slot.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Slot).ToArray(),
                            { } v => new []{ v as Slot },
                            _ => null
                        };
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
                return new SetFormByUserId(
                    properties["namespaceName"].ToString(),
                    properties["moldModelName"].ToString(),
                    properties["index"].ToString(),
                    new Func<Slot[]>(() =>
                    {
                        return properties["slots"] switch {
                            Dictionary<string, object>[] v => v.Select(Slot.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Slot.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Slot.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Slot).ToArray(),
                            { } v => new []{ v as Slot },
                            _ => null
                        };
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
            return "Gs2Formation:SetFormByUserId";
        }

        public static string StaticAction() {
            return "Gs2Formation:SetFormByUserId";
        }
    }
}
