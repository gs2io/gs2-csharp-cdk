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
using Gs2Cdk.Gs2Realtime.Model;
using Gs2Cdk.Gs2Realtime.Model.Options;

namespace Gs2Cdk.Gs2Realtime.Model
{
    public class SyncSetting {
        private string objectCatalog;

        public SyncSetting(
            SyncSettingOptions options = null
        ){
            this.objectCatalog = options?.objectCatalog;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.objectCatalog != null) {
                properties["objectCatalog"] = this.objectCatalog;
            }

            return properties;
        }

        public static SyncSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SyncSetting(
                new SyncSettingOptions {
                    objectCatalog = properties.TryGetValue("objectCatalog", out var objectCatalog) ? (string)objectCatalog : null
                }
            );

            return model;
        }
    }
}
