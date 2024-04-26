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
using Gs2Cdk.Gs2Buff.Model;
using Gs2Cdk.Gs2Buff.Model.Options;

namespace Gs2Cdk.Gs2Buff.Model
{
    public class BuffTargetGrn {
        private string targetModelName;
        private string targetGrn;

        public BuffTargetGrn(
            string targetModelName,
            string targetGrn,
            BuffTargetGrnOptions options = null
        ){
            this.targetModelName = targetModelName;
            this.targetGrn = targetGrn;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.targetModelName != null) {
                properties["targetModelName"] = this.targetModelName;
            }
            if (this.targetGrn != null) {
                properties["targetGrn"] = this.targetGrn;
            }

            return properties;
        }

        public static BuffTargetGrn FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BuffTargetGrn(
                (string)properties["targetModelName"],
                (string)properties["targetGrn"],
                new BuffTargetGrnOptions {
                }
            );

            return model;
        }
    }
}
