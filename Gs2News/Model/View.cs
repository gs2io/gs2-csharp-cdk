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
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2News.Model;
using Gs2Cdk.Gs2News.Model.Options;

namespace Gs2Cdk.Gs2News.Model
{
    public class View {
        private Content[] contents;
        private Content[] removeContents;

        public View(
            ViewOptions options = null
        ){
            this.contents = options?.contents;
            this.removeContents = options?.removeContents;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.contents != null) {
                properties["contents"] = this.contents.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.removeContents != null) {
                properties["removeContents"] = this.removeContents.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }
    }
}
