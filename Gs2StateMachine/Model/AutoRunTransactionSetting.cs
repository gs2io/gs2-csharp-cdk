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
using Gs2Cdk.Gs2StateMachine.Model;
using Gs2Cdk.Gs2StateMachine.Model.Options;

namespace Gs2Cdk.Gs2StateMachine.Model
{
    public class AutoRunTransactionSetting {
        private string distributorNamespaceId;
        private string queueNamespaceId;

        public AutoRunTransactionSetting(
            string distributorNamespaceId,
            AutoRunTransactionSettingOptions options = null
        ){
            this.distributorNamespaceId = distributorNamespaceId;
            this.queueNamespaceId = options?.queueNamespaceId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.distributorNamespaceId != null) {
                properties["distributorNamespaceId"] = this.distributorNamespaceId;
            }
            if (this.queueNamespaceId != null) {
                properties["queueNamespaceId"] = this.queueNamespaceId;
            }

            return properties;
        }

        public static AutoRunTransactionSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AutoRunTransactionSetting(
                (string)properties["distributorNamespaceId"],
                new AutoRunTransactionSettingOptions {
                    queueNamespaceId = properties.TryGetValue("queueNamespaceId", out var queueNamespaceId) ? (string)queueNamespaceId : null
                }
            );

            return model;
        }
    }
}
