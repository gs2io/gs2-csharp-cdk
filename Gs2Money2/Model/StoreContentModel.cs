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
    public class StoreContentModel {
        private string name;
        private string metadata;
        private AppleAppStoreContent appleAppStore;
        private GooglePlayContent googlePlay;

        public StoreContentModel(
            string name,
            StoreContentModelOptions options = null
        ){
            this.name = name;
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

        public static StoreContentModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new StoreContentModel(
                (string)properties["name"],
                new StoreContentModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    appleAppStore = properties.TryGetValue("appleAppStore", out var appleAppStore) ? new Func<AppleAppStoreContent>(() =>
                    {
                        return appleAppStore switch {
                            AppleAppStoreContent v => v,
                            Dictionary<string, object> v => AppleAppStoreContent.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    googlePlay = properties.TryGetValue("googlePlay", out var googlePlay) ? new Func<GooglePlayContent>(() =>
                    {
                        return googlePlay switch {
                            GooglePlayContent v => v,
                            Dictionary<string, object> v => GooglePlayContent.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
