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
using Gs2Cdk.Gs2Quest.Model;
using Gs2Cdk.Gs2Quest.Model.Options;

namespace Gs2Cdk.Gs2Quest.Model
{
    public class Reward {
        private string action;
        private string request;
        private string itemId;
        private int value;
        private string valueString;

        public Reward(
            string action,
            string request,
            string itemId,
            int value,
            RewardOptions options = null
        ){
            this.action = action;
            this.request = request;
            this.itemId = itemId;
            this.value = value;
        }


        public Reward(
            string action,
            string request,
            string itemId,
            string value,
            RewardOptions options = null
        ){
            this.action = action;
            this.request = request;
            this.itemId = itemId;
            this.valueString = value;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.action != null) {
                properties["action"] = this.action;
            }
            if (this.request != null) {
                properties["request"] = this.request;
            }
            if (this.itemId != null) {
                properties["itemId"] = this.itemId;
            }
            if (this.valueString != null) {
                properties["value"] = this.valueString;
            } else {
                if (this.value != null) {
                    properties["value"] = this.value;
                }
            }

            return properties;
        }

        public static Reward FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Reward(
                (string)properties["action"],
                (string)properties["request"],
                (string)properties["itemId"],
                new Func<int>(() =>
                {
                    return properties["value"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new RewardOptions {
                }
            );

            return model;
        }
    }
}
