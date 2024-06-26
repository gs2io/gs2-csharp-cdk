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
using Gs2Cdk.Gs2Money2.Model;
using Gs2Cdk.Gs2Money2.Model.Options;

namespace Gs2Cdk.Gs2Money2.Model
{
    public class DailyTransactionHistory {
        private int year;
        private int month;
        private int day;
        private string currency;
        private float? depositAmount;
        private float? withdrawAmount;
        private long? revision;

        public DailyTransactionHistory(
            int year,
            int month,
            int day,
            string currency,
            float? depositAmount,
            float? withdrawAmount,
            DailyTransactionHistoryOptions options = null
        ){
            this.year = year;
            this.month = month;
            this.day = day;
            this.currency = currency;
            this.depositAmount = depositAmount;
            this.withdrawAmount = withdrawAmount;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.year != null) {
                properties["year"] = this.year;
            }
            if (this.month != null) {
                properties["month"] = this.month;
            }
            if (this.day != null) {
                properties["day"] = this.day;
            }
            if (this.currency != null) {
                properties["currency"] = this.currency;
            }
            if (this.depositAmount != null) {
                properties["depositAmount"] = this.depositAmount;
            }
            if (this.withdrawAmount != null) {
                properties["withdrawAmount"] = this.withdrawAmount;
            }

            return properties;
        }

        public static DailyTransactionHistory FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DailyTransactionHistory(
                new Func<int>(() =>
                {
                    return properties["year"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["month"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["day"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                (string)properties["currency"],
                new Func<float?>(() =>
                {
                    return properties["depositAmount"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<float?>(() =>
                {
                    return properties["withdrawAmount"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new DailyTransactionHistoryOptions {
                    revision = new Func<long?>(() =>
                    {
                        return properties.TryGetValue("revision", out var revision) ? revision switch {
                            long v => v,
                            string v => long.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
