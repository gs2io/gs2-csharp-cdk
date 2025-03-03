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
    public class StoreSubscriptionContentModel {
        private string name;
        private string scheduleNamespaceId;
        private string triggerName;
        private int? reallocateSpanDays;
        private string reallocateSpanDaysString;
        private string metadata;
        private AppleAppStoreSubscriptionContent appleAppStore;
        private GooglePlaySubscriptionContent googlePlay;

        public StoreSubscriptionContentModel(
            string name,
            string scheduleNamespaceId,
            string triggerName,
            int? reallocateSpanDays,
            StoreSubscriptionContentModelOptions options = null
        ){
            this.name = name;
            this.scheduleNamespaceId = scheduleNamespaceId;
            this.triggerName = triggerName;
            this.reallocateSpanDays = reallocateSpanDays;
            this.metadata = options?.metadata;
            this.appleAppStore = options?.appleAppStore;
            this.googlePlay = options?.googlePlay;
        }


        public StoreSubscriptionContentModel(
            string name,
            string scheduleNamespaceId,
            string triggerName,
            string reallocateSpanDays,
            StoreSubscriptionContentModelOptions options = null
        ){
            this.name = name;
            this.scheduleNamespaceId = scheduleNamespaceId;
            this.triggerName = triggerName;
            this.reallocateSpanDaysString = reallocateSpanDays;
            this.metadata = options?.metadata;
            this.appleAppStore = options?.appleAppStore;
            this.googlePlay = options?.googlePlay;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.scheduleNamespaceId != null) {
                properties["scheduleNamespaceId"] = this.scheduleNamespaceId;
            }
            if (this.triggerName != null) {
                properties["triggerName"] = this.triggerName;
            }
            if (this.reallocateSpanDaysString != null) {
                properties["reallocateSpanDays"] = this.reallocateSpanDaysString;
            } else {
                if (this.reallocateSpanDays != null) {
                    properties["reallocateSpanDays"] = this.reallocateSpanDays;
                }
            }
            if (this.appleAppStore != null) {
                properties["appleAppStore"] = this.appleAppStore?.Properties(
                );
            }
            if (this.googlePlay != null) {
                properties["googlePlay"] = this.googlePlay?.Properties(
                );
            }

            return properties;
        }

        public static StoreSubscriptionContentModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new StoreSubscriptionContentModel(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("scheduleNamespaceId", out var scheduleNamespaceId) ? new Func<string>(() =>
                {
                    return (string) scheduleNamespaceId;
                })() : default,
                properties.TryGetValue("triggerName", out var triggerName) ? new Func<string>(() =>
                {
                    return (string) triggerName;
                })() : default,
                properties.TryGetValue("reallocateSpanDays", out var reallocateSpanDays) ? new Func<int?>(() =>
                {
                    return reallocateSpanDays switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new StoreSubscriptionContentModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    appleAppStore = properties.TryGetValue("appleAppStore", out var appleAppStore) ? new Func<AppleAppStoreSubscriptionContent>(() =>
                    {
                        return appleAppStore switch {
                            AppleAppStoreSubscriptionContent v => v,
                            Dictionary<string, object> v => AppleAppStoreSubscriptionContent.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    googlePlay = properties.TryGetValue("googlePlay", out var googlePlay) ? new Func<GooglePlaySubscriptionContent>(() =>
                    {
                        return googlePlay switch {
                            GooglePlaySubscriptionContent v => v,
                            Dictionary<string, object> v => GooglePlaySubscriptionContent.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
