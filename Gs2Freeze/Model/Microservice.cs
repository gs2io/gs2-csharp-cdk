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
using Gs2Cdk.Gs2Freeze.Model;
using Gs2Cdk.Gs2Freeze.Model.Options;

namespace Gs2Cdk.Gs2Freeze.Model
{
    public class Microservice {
        private string name;
        private string version;

        public Microservice(
            string name,
            string version,
            MicroserviceOptions options = null
        ){
            this.name = name;
            this.version = version;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.version != null) {
                properties["version"] = this.version;
            }

            return properties;
        }

        public static Microservice FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Microservice(
                properties.TryGetValue("name", out var name) ? new Func<string>(() =>
                {
                    return (string) name;
                })() : default,
                properties.TryGetValue("version", out var version) ? new Func<string>(() =>
                {
                    return (string) version;
                })() : default,
                new MicroserviceOptions {
                }
            );

            return model;
        }
    }
}
