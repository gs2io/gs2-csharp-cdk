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
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Model.Options;

namespace Gs2Cdk.Gs2Version.Model
{
    public class Version_ {
        private int major;
        private int minor;
        private int micro;

        public Version_(
            int major,
            int minor,
            int micro,
            VersionOptions options = null
        ){
            this.major = major;
            this.minor = minor;
            this.micro = micro;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.major != null) {
                properties["major"] = this.major;
            }
            if (this.minor != null) {
                properties["minor"] = this.minor;
            }
            if (this.micro != null) {
                properties["micro"] = this.micro;
            }

            return properties;
        }

        public static Version_ FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Version_(
                new Func<int>(() =>
                {
                    return properties["major"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["minor"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["micro"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new VersionOptions {
                }
            );

            return model;
        }
    }
}
