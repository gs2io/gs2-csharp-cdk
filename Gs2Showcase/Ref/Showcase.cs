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

using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Showcase.Model;

namespace Gs2Cdk.Gs2Showcase.Ref
{
    public class ShowcaseRef {
        private string namespaceName;
        private string showcaseName;

        public ShowcaseRef(
            string namespaceName,
            string showcaseName
        ){
            this.namespaceName = namespaceName;
            this.showcaseName = showcaseName;
        }

        public DisplayItemRef DisplayItem(
            string displayItemId
        ){
            return (new DisplayItemRef(
                this.namespaceName,
                this.showcaseName,
                displayItemId
            ));
        }

        public string Grn(
        ){
            return (new Join(
                ":",
                new []
                {
                    "grn",
                    "gs2",
                    GetAttr.Region(
                    ).Str(
                    ),
                    GetAttr.OwnerId(
                    ).Str(
                    ),
                    "showcase",
                    this.namespaceName,
                    "showcase",
                    this.showcaseName
                }
            )).Str(
            );
        }
    }
}
