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
using Gs2Cdk.Gs2Distributor.Model;
using Gs2Cdk.Gs2Distributor.Model.Options;

namespace Gs2Cdk.Gs2Distributor.Model
{
    public class UserDataEntry {
        private string service;
        private string namespaceName;
        private string kind;
        private string payload;

        public UserDataEntry(
            string service,
            string namespaceName,
            string kind,
            string payload,
            UserDataEntryOptions options = null
        ){
            this.service = service;
            this.namespaceName = namespaceName;
            this.kind = kind;
            this.payload = payload;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.service != null) {
                properties["service"] = this.service;
            }
            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.kind != null) {
                properties["kind"] = this.kind;
            }
            if (this.payload != null) {
                properties["payload"] = this.payload;
            }

            return properties;
        }

        public static UserDataEntry FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new UserDataEntry(
                properties.TryGetValue("service", out var service) ? new Func<string>(() =>
                {
                    return (string) service;
                })() : default,
                properties.TryGetValue("namespaceName", out var namespaceName) ? new Func<string>(() =>
                {
                    return (string) namespaceName;
                })() : default,
                properties.TryGetValue("kind", out var kind) ? new Func<string>(() =>
                {
                    return (string) kind;
                })() : default,
                properties.TryGetValue("payload", out var payload) ? new Func<string>(() =>
                {
                    return (string) payload;
                })() : default,
                new UserDataEntryOptions {
                }
            );

            return model;
        }
    }
}
