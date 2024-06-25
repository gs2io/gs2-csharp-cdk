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
    public class PlatformSetting {
        private AppleAppStoreSetting appleAppStore;
        private GooglePlaySetting googlePlay;
        private FakeSetting fake;

        public PlatformSetting(
            PlatformSettingOptions options = null
        ){
            this.appleAppStore = options?.appleAppStore;
            this.googlePlay = options?.googlePlay;
            this.fake = options?.fake;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.appleAppStore != null) {
                properties["appleAppStore"] = this.appleAppStore?.Properties(
                );
            }
            if (this.googlePlay != null) {
                properties["googlePlay"] = this.googlePlay?.Properties(
                );
            }
            if (this.fake != null) {
                properties["fake"] = this.fake?.Properties(
                );
            }

            return properties;
        }

        public static PlatformSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new PlatformSetting(
                new PlatformSettingOptions {
                    appleAppStore = properties.TryGetValue("appleAppStore", out var appleAppStore) ? new Func<AppleAppStoreSetting>(() =>
                    {
                        return appleAppStore switch {
                            AppleAppStoreSetting v => v,
                            Dictionary<string, object> v => AppleAppStoreSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    googlePlay = properties.TryGetValue("googlePlay", out var googlePlay) ? new Func<GooglePlaySetting>(() =>
                    {
                        return googlePlay switch {
                            GooglePlaySetting v => v,
                            Dictionary<string, object> v => GooglePlaySetting.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    fake = properties.TryGetValue("fake", out var fake) ? new Func<FakeSetting>(() =>
                    {
                        return fake switch {
                            FakeSetting v => v,
                            Dictionary<string, object> v => FakeSetting.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
