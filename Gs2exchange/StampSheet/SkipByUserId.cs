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
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.StampSheet.Enums;

namespace Gs2Cdk.Gs2Exchange.StampSheet
{
    public class SkipByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string awaitName;
        private SkipByUserIdSkipType? skipType;
        private int? minutes;
        private string minutesString;
        private float? rate;
        private string rateString;
        private string timeOffsetToken;


        public SkipByUserId(
            string namespaceName,
            string awaitName = null,
            SkipByUserIdSkipType? skipType = null,
            int? minutes = null,
            float? rate = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.awaitName = awaitName;
            this.skipType = skipType;
            this.minutes = minutes;
            this.rate = rate;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public SkipByUserId(
            string namespaceName,
            string awaitName = null,
            SkipByUserIdSkipType? skipType = null,
            string minutes = null,
            string rate = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.awaitName = awaitName;
            this.skipType = skipType;
            this.minutesString = minutes;
            this.rateString = rate;
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
            if (this.awaitName != null) {
                properties["awaitName"] = this.awaitName;
            }
            if (this.skipType != null) {
                properties["skipType"] = this.skipType.Value.Str(
                );
            }
            if (this.minutesString != null) {
                properties["minutes"] = this.minutesString;
            } else {
                if (this.minutes != null) {
                    properties["minutes"] = this.minutes;
                }
            }
            if (this.rateString != null) {
                properties["rate"] = this.rateString;
            } else {
                if (this.rate != null) {
                    properties["rate"] = this.rate;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static SkipByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new SkipByUserId(
                    (string)properties["namespaceName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("awaitName", out var awaitName) ? awaitName as string : null;
                    })(),
                    new Func<SkipByUserIdSkipType?>(() =>
                    {
                        return properties.TryGetValue("skipType", out var skipType) ? skipType switch {
                            SkipByUserIdSkipType e => e,
                            string s => SkipByUserIdSkipTypeExt.New(s),
                            _ => SkipByUserIdSkipType.Complete
                        } : null;
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("minutes", out var minutes) ? minutes switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
                        } : null;
                    })(),
                    new Func<float?>(() =>
                    {
                        return properties.TryGetValue("rate", out var rate) ? rate switch {
                            long v => (float)v,
                            int v => (float)v,
                            float v => (float)v,
                            double v => (float)v,
                            string v => float.Parse(v),
                            _ => 0
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
                return new SkipByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("awaitName", out var awaitName) ? awaitName.ToString() : null;
                    })(),
                    new Func<SkipByUserIdSkipType?>(() =>
                    {
                        return properties.TryGetValue("skipType", out var skipType) ? skipType switch {
                            SkipByUserIdSkipType e => e,
                            string s => SkipByUserIdSkipTypeExt.New(s),
                            _ => SkipByUserIdSkipType.Complete
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("minutes", out var minutes) ? minutes.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("rate", out var rate) ? rate.ToString() : null;
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
            return "Gs2Exchange:SkipByUserId";
        }

        public static string StaticAction() {
            return "Gs2Exchange:SkipByUserId";
        }
    }
}
