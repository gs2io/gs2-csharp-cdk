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
    public class Progress {
        private string uploadToken;
        private int generated;
        private string generatedString;
        private int patternCount;
        private string patternCountString;
        private long? revision;
        private string revisionString;

        public Progress(
            string uploadToken,
            int generated,
            int patternCount,
            ProgressOptions options = null
        ){
            this.uploadToken = uploadToken;
            this.generated = generated;
            this.patternCount = patternCount;
            this.revision = options?.revision;
        }


        public Progress(
            string uploadToken,
            string generated,
            string patternCount,
            ProgressOptions options = null
        ){
            this.uploadToken = uploadToken;
            this.generatedString = generated;
            this.patternCountString = patternCount;
            this.revision = options?.revision;
            this.revisionString = options?.revisionString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.uploadToken != null) {
                properties["uploadToken"] = this.uploadToken;
            }
            if (this.generatedString != null) {
                properties["generated"] = this.generatedString;
            } else {
                if (this.generated != null) {
                    properties["generated"] = this.generated;
                }
            }
            if (this.patternCountString != null) {
                properties["patternCount"] = this.patternCountString;
            } else {
                if (this.patternCount != null) {
                    properties["patternCount"] = this.patternCount;
                }
            }

            return properties;
        }

        public static Progress FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Progress(
                (string)properties["uploadToken"],
                new Func<int>(() =>
                {
                    return properties["generated"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["patternCount"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new ProgressOptions {
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
