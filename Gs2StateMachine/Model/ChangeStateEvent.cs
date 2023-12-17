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
    public class ChangeStateEvent {
        private string taskName;
        private string hash;
        private long timestamp;

        public ChangeStateEvent(
            string taskName,
            string hash,
            long timestamp,
            ChangeStateEventOptions options = null
        ){
            this.taskName = taskName;
            this.hash = hash;
            this.timestamp = timestamp;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.taskName != null) {
                properties["taskName"] = this.taskName;
            }
            if (this.hash != null) {
                properties["hash"] = this.hash;
            }
            if (this.timestamp != null) {
                properties["timestamp"] = this.timestamp;
            }

            return properties;
        }

        public static ChangeStateEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new ChangeStateEvent(
                (string)properties["taskName"],
                (string)properties["hash"],
                new Func<long>(() =>
                {
                    return properties["timestamp"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new ChangeStateEventOptions {
                }
            );

            return model;
        }
    }
}
