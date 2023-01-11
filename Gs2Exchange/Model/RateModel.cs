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

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Model.Enums;
using Gs2Cdk.Gs2Exchange.Model.Options;

namespace Gs2Cdk.Gs2Exchange.Model
{
    public class RateModel {
        private string name;
        private RateModelTimingType? timingType;
        private string metadata;
        private ConsumeAction[] consumeActions;
        private int? lockTime;
        private bool? enableSkip;
        private ConsumeAction[] skipConsumeActions;
        private AcquireAction[] acquireActions;

        public RateModel(
            string name,
            RateModelTimingType timingType,
            RateModelOptions options = null
        ){
            this.name = name;
            this.timingType = timingType;
            this.metadata = options?.metadata;
            this.consumeActions = options?.consumeActions;
            this.lockTime = options?.lockTime;
            this.enableSkip = options?.enableSkip;
            this.skipConsumeActions = options?.skipConsumeActions;
            this.acquireActions = options?.acquireActions;
        }

        public static RateModel TimingTypeIsImmediate(
            string name,
            RateModelTimingTypeIsImmediateOptions options = null
        ){
            return (new RateModel(
                name,
                RateModelTimingType.Immediate,
                new RateModelOptions {
                    metadata = options?.metadata,
                    consumeActions = options?.consumeActions,
                    skipConsumeActions = options?.skipConsumeActions,
                    acquireActions = options?.acquireActions,
                }
            ));
        }

        public static RateModel TimingTypeIsAwait(
            string name,
            int? lockTime,
            bool? enableSkip,
            RateModelTimingTypeIsAwaitOptions options = null
        ){
            return (new RateModel(
                name,
                RateModelTimingType.Await,
                new RateModelOptions {
                    lockTime = lockTime,
                    enableSkip = enableSkip,
                    metadata = options?.metadata,
                    consumeActions = options?.consumeActions,
                    skipConsumeActions = options?.skipConsumeActions,
                    acquireActions = options?.acquireActions,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.consumeActions != null) {
                properties["consumeActions"] = this.consumeActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.timingType != null) {
                properties["timingType"] = this.timingType?.Str(
                );
            }
            if (this.lockTime != null) {
                properties["lockTime"] = this.lockTime;
            }
            if (this.enableSkip != null) {
                properties["enableSkip"] = this.enableSkip;
            }
            if (this.skipConsumeActions != null) {
                properties["skipConsumeActions"] = this.skipConsumeActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v.Properties(
                        )).ToList();
            }

            return properties;
        }
    }
}