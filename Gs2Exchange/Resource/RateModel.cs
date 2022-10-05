/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Exchange.Model;
using Gs2Cdk.Gs2Exchange.Ref;

namespace Gs2Cdk.Gs2Exchange.Resource
{

    public static class RateModelTimingTypeExt
    {
        public static string ToString(this RateModel.TimingType self)
        {
            switch (self) {
                case RateModel.TimingType.Immediate:
                    return "immediate";
                case RateModel.TimingType.Await:
                    return "await";
            }
            return "unknown";
        }
    }

    public class RateModel {

        public enum TimingType
        {
            Immediate,
            Await
        }
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly ConsumeAction[] _consumeActions;
	    private readonly TimingType _timingType;
	    private readonly int? _lockTime;
	    private readonly bool? _enableSkip;
	    private readonly ConsumeAction[] _skipConsumeActions;
	    private readonly AcquireAction[] _acquireActions;

        public RateModel(
                string name,
                TimingType timingType,
                string metadata = null,
                ConsumeAction[] consumeActions = null,
                int? lockTime = null,
                bool? enableSkip = null,
                ConsumeAction[] skipConsumeActions = null,
                AcquireAction[] acquireActions = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._consumeActions = consumeActions;
            this._timingType = timingType;
            this._lockTime = lockTime;
            this._enableSkip = enableSkip;
            this._skipConsumeActions = skipConsumeActions;
            this._acquireActions = acquireActions;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._consumeActions != null) {
                properties["ConsumeActions"] = this._consumeActions.Select(v => v.Properties()).ToArray();
            }
            if (this._timingType != null) {
                properties["TimingType"] = this._timingType.ToString();
            }
            if (this._lockTime != null) {
                properties["LockTime"] = this._lockTime;
            }
            if (this._enableSkip != null) {
                properties["EnableSkip"] = this._enableSkip;
            }
            if (this._skipConsumeActions != null) {
                properties["SkipConsumeActions"] = this._skipConsumeActions.Select(v => v.Properties()).ToArray();
            }
            if (this._acquireActions != null) {
                properties["AcquireActions"] = this._acquireActions.Select(v => v.Properties()).ToArray();
            }
            return properties;
        }

        public RateModelRef Ref(
                string namespaceName
        )
        {
            return new RateModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
