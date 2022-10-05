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
using Gs2Cdk.Gs2Experience.Model;
using Gs2Cdk.Gs2Experience.Ref;

namespace Gs2Cdk.Gs2Experience.Resource
{

    public class ExperienceModel {
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly long? _defaultExperience;
	    private readonly long? _defaultRankCap;
	    private readonly long? _maxRankCap;
	    private readonly Threshold _rankThreshold;

        public ExperienceModel(
                string name,
                long? defaultExperience,
                long? defaultRankCap,
                long? maxRankCap,
                Threshold rankThreshold,
                string metadata = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._defaultExperience = defaultExperience;
            this._defaultRankCap = defaultRankCap;
            this._maxRankCap = maxRankCap;
            this._rankThreshold = rankThreshold;
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
            if (this._defaultExperience != null) {
                properties["DefaultExperience"] = this._defaultExperience;
            }
            if (this._defaultRankCap != null) {
                properties["DefaultRankCap"] = this._defaultRankCap;
            }
            if (this._maxRankCap != null) {
                properties["MaxRankCap"] = this._maxRankCap;
            }
            if (this._rankThreshold != null) {
                properties["RankThreshold"] = this._rankThreshold.Properties();
            }
            return properties;
        }

        public ExperienceModelRef Ref(
                string namespaceName
        )
        {
            return new ExperienceModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
