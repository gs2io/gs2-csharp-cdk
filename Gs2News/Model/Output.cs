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
using Gs2Cdk.Gs2News.Model;
using Gs2Cdk.Gs2News.Model.Options;

namespace Gs2Cdk.Gs2News.Model
{
    public class Output {
        private string text;
        private long? revision;
        private string revisionString;

        public Output(
            string text,
            OutputOptions options = null
        ){
            this.text = text;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.text != null) {
                properties["text"] = this.text;
            }

            return properties;
        }

        public static Output FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Output(
                properties.TryGetValue("text", out var text) ? new Func<string>(() =>
                {
                    return (string) text;
                })() : default,
                new OutputOptions {
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
