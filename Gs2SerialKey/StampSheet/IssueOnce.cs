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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2SerialKey.Model;

namespace Gs2Cdk.Gs2SerialKey.StampSheet
{
    public class IssueOnce : AcquireAction {
        private string namespaceName;
        private string campaignModelName;
        private string metadata;


        public IssueOnce(
            string namespaceName,
            string campaignModelName,
            string metadata = null
        ){

            this.namespaceName = namespaceName;
            this.campaignModelName = campaignModelName;
            this.metadata = metadata;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.campaignModelName != null) {
                properties["campaignModelName"] = this.campaignModelName;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }

            return properties;
        }

        public static IssueOnce FromProperties(Dictionary<string, object> properties) {
            try {
                return new IssueOnce(
                    (string)properties["namespaceName"],
                    (string)properties["campaignModelName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("metadata", out var metadata) ? metadata as string : null;
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new IssueOnce(
                    properties["namespaceName"].ToString(),
                    properties["campaignModelName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("metadata", out var metadata) ? metadata.ToString() : null;
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2SerialKey:IssueOnce";
        }

        public static string StaticAction() {
            return "Gs2SerialKey:IssueOnce";
        }
    }
}
