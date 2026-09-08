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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Model.Options;

namespace Gs2Cdk.Gs2Experience.Model
{
    public class TransactionSettingV2 {
        private string distributorNamespaceId;
        private bool? enableParallelExecution;
        private string enableParallelExecutionString;

        public TransactionSettingV2(
            string distributorNamespaceId,
            bool? enableParallelExecution,
            TransactionSettingV2Options options = null
        ){
            this.distributorNamespaceId = distributorNamespaceId;
            this.enableParallelExecution = enableParallelExecution;
        }


        public TransactionSettingV2(
            string distributorNamespaceId,
            string enableParallelExecution,
            TransactionSettingV2Options options = null
        ){
            this.distributorNamespaceId = distributorNamespaceId;
            this.enableParallelExecutionString = enableParallelExecution;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.distributorNamespaceId != null) {
                properties["distributorNamespaceId"] = this.distributorNamespaceId;
            }
            if (this.enableParallelExecutionString != null) {
                properties["enableParallelExecution"] = this.enableParallelExecutionString;
            } else {
                if (this.enableParallelExecution != null) {
                    properties["enableParallelExecution"] = this.enableParallelExecution;
                }
            }

            return properties;
        }

        public static TransactionSettingV2 FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TransactionSettingV2(
                properties.TryGetValue("distributorNamespaceId", out var distributorNamespaceId) ? new Func<string>(() =>
                {
                    return (string) distributorNamespaceId;
                })() : default,
                properties.TryGetValue("enableParallelExecution", out var enableParallelExecution) ? new Func<bool?>(() =>
                {
                    return enableParallelExecution switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new TransactionSettingV2Options {
                }
            );

            return model;
        }
    }
}
