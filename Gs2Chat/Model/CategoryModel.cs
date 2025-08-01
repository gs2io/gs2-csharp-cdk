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
using Gs2Cdk.Gs2Chat.Model;
using Gs2Cdk.Gs2Chat.Model.Enums;
using Gs2Cdk.Gs2Chat.Model.Options;

namespace Gs2Cdk.Gs2Chat.Model
{
    public class CategoryModel {
        private int category;
        private string categoryString;
        private CategoryModelRejectAccessTokenPost? rejectAccessTokenPost;

        public CategoryModel(
            int category,
            CategoryModelOptions options = null
        ){
            this.category = category;
            this.rejectAccessTokenPost = options?.rejectAccessTokenPost;
        }


        public CategoryModel(
            string category,
            CategoryModelOptions options = null
        ){
            this.categoryString = category;
            this.rejectAccessTokenPost = options?.rejectAccessTokenPost;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.categoryString != null) {
                properties["category"] = this.categoryString;
            } else {
                if (this.category != null) {
                    properties["category"] = this.category;
                }
            }
            if (this.rejectAccessTokenPost != null) {
                properties["rejectAccessTokenPost"] = this.rejectAccessTokenPost.Value.Str(
                );
            }

            return properties;
        }

        public static CategoryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new CategoryModel(
                properties.TryGetValue("category", out var category) ? new Func<int>(() =>
                {
                    return category switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                new CategoryModelOptions {
                    rejectAccessTokenPost = properties.TryGetValue("rejectAccessTokenPost", out var rejectAccessTokenPost) ? CategoryModelRejectAccessTokenPostExt.New(rejectAccessTokenPost as string) : null
                }
            );

            return model;
        }
    }
}
