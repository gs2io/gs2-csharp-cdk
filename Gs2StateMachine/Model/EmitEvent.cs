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
    public class EmitEvent {
        private string event_;
        private string parameters;
        private long timestamp;

        public EmitEvent(
            string event_,
            string parameters,
            long timestamp,
            EmitEventOptions options = null
        ){
            this.event_ = event_;
            this.parameters = parameters;
            this.timestamp = timestamp;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.event_ != null) {
                properties["event"] = this.event_;
            }
            if (this.parameters != null) {
                properties["parameters"] = this.parameters;
            }
            if (this.timestamp != null) {
                properties["timestamp"] = this.timestamp;
            }

            return properties;
        }

        public static EmitEvent FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new EmitEvent(
                (string)properties["event"],
                (string)properties["parameters"],
                new Func<long>(() =>
                {
                    return properties["timestamp"] switch {
                        long v => v,
                        string v => long.Parse(v),
                        _ => 0
                    };
                })(),
                new EmitEventOptions {
                }
            );

            return model;
        }
    }
}
