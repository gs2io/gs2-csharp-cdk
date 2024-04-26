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
using Gs2Cdk.Gs2Showcase.Model;

namespace Gs2Cdk.Gs2Showcase.StampSheet
{
    public class ForceReDrawByUserId : AcquireAction {
        private string namespaceName;
        private string showcaseName;
        private string userId;
        private string timeOffsetToken;


        public ForceReDrawByUserId(
            string namespaceName,
            string showcaseName,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.showcaseName = showcaseName;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.showcaseName != null) {
                properties["showcaseName"] = this.showcaseName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static ForceReDrawByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new ForceReDrawByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["showcaseName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new ForceReDrawByUserId(
                    properties["namespaceName"].ToString(),
                    properties["showcaseName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Showcase:ForceReDrawByUserId";
        }

        public static string StaticAction() {
            return "Gs2Showcase:ForceReDrawByUserId";
        }
    }
}
