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
    public class RefundHistory {
        private string transactionId;
        private int year;
        private string yearString;
        private int month;
        private string monthString;
        private int day;
        private string dayString;
        private RefundEvent detail;
        private string userId;

        public RefundHistory(
            string transactionId,
            int year,
            int month,
            int day,
            RefundEvent detail,
            RefundHistoryOptions options = null
        ){
            this.transactionId = transactionId;
            this.year = year;
            this.month = month;
            this.day = day;
            this.detail = detail;
            this.userId = options?.userId;
        }


        public RefundHistory(
            string transactionId,
            string year,
            string month,
            string day,
            RefundEvent detail,
            RefundHistoryOptions options = null
        ){
            this.transactionId = transactionId;
            this.yearString = year;
            this.monthString = month;
            this.dayString = day;
            this.detail = detail;
            this.userId = options?.userId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.transactionId != null) {
                properties["transactionId"] = this.transactionId;
            }
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
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.detail != null) {
                properties["detail"] = this.detail?.Properties(
                );
            }

            return properties;
        }

        public static RefundHistory FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new RefundHistory(
                properties.TryGetValue("transactionId", out var transactionId) ? new Func<string>(() =>
                {
                    return (string) transactionId;
                })() : default,
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
                properties.TryGetValue("detail", out var detail) ? new Func<RefundEvent>(() =>
                {
                    return detail switch {
                        RefundEvent v => v,
                        RefundEvent[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => RefundEvent.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? RefundEvent.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                new RefundHistoryOptions {
                    userId = properties.TryGetValue("userId", out var userId) ? (string)userId : null
                }
            );

            return model;
        }
    }
}
