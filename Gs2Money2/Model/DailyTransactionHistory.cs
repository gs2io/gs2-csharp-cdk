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
        private string yearString;
        private int month;
        private string monthString;
        private int day;
        private string dayString;
        private string currency;
        private float? depositAmount;
        private string depositAmountString;
        private float? withdrawAmount;
        private string withdrawAmountString;
        private long? revision;
        private string revisionString;

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


        public DailyTransactionHistory(
            string year,
            string month,
            string day,
            string currency,
            string depositAmount,
            string withdrawAmount,
            DailyTransactionHistoryOptions options = null
        ){
            this.yearString = year;
            this.monthString = month;
            this.dayString = day;
            this.currency = currency;
            this.depositAmountString = depositAmount;
            this.withdrawAmountString = withdrawAmount;
            this.revision = options?.revision;
            this.revisionString = options?.revisionString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.yearString != null) {
                properties["year"] = this.yearString;
            } else {
                if (this.year != null) {
                    properties["year"] = this.year;
                }
            }
            if (this.monthString != null) {
                properties["month"] = this.monthString;
            } else {
                if (this.month != null) {
                    properties["month"] = this.month;
                }
            }
            if (this.dayString != null) {
                properties["day"] = this.dayString;
            } else {
                if (this.day != null) {
                    properties["day"] = this.day;
                }
            }
            if (this.currency != null) {
                properties["currency"] = this.currency;
            }
            if (this.depositAmountString != null) {
                properties["depositAmount"] = this.depositAmountString;
            } else {
                if (this.depositAmount != null) {
                    properties["depositAmount"] = this.depositAmount;
                }
            }
            if (this.withdrawAmountString != null) {
                properties["withdrawAmount"] = this.withdrawAmountString;
            } else {
                if (this.withdrawAmount != null) {
                    properties["withdrawAmount"] = this.withdrawAmount;
                }
            }

            return properties;
        }

        public static DailyTransactionHistory FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new DailyTransactionHistory(
                properties.TryGetValue("year", out var year) ? new Func<int>(() =>
                {
                    return year switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("month", out var month) ? new Func<int>(() =>
                {
                    return month switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("day", out var day) ? new Func<int>(() =>
                {
                    return day switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("currency", out var currency) ? new Func<string>(() =>
                {
                    return (string) currency;
                })() : default,
                properties.TryGetValue("depositAmount", out var depositAmount) ? new Func<float?>(() =>
                {
                    return depositAmount switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("withdrawAmount", out var withdrawAmount) ? new Func<float?>(() =>
                {
                    return withdrawAmount switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })() : default,
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
