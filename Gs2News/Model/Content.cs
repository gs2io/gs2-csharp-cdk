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
    public class Content {
        private string section;
        private string content;
        private string frontMatter;

        public Content(
            string section,
            string content,
            string frontMatter,
            ContentOptions options = null
        ){
            this.section = section;
            this.content = content;
            this.frontMatter = frontMatter;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.section != null) {
                properties["section"] = this.section;
            }
            if (this.content != null) {
                properties["content"] = this.content;
            }
            if (this.frontMatter != null) {
                properties["frontMatter"] = this.frontMatter;
            }

            return properties;
        }

        public static Content FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Content(
                (string)properties["section"],
                (string)properties["content"],
                (string)properties["frontMatter"],
                new ContentOptions {
                }
            );

            return model;
        }
    }
}
