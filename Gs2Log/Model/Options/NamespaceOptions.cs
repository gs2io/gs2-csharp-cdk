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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Enums;

namespace Gs2Cdk.Gs2Log.Model.Options
{
    public class NamespaceOptions {
        public string description;
        public NamespaceType? type;
        public string gcpCredentialJson;
        public string bigQueryDatasetName;
        public int? logExpireDays;
        public string awsRegion;
        public string awsAccessKeyId;
        public string awsSecretAccessKey;
        public string firehoseStreamName;
        public NamespaceFirehoseCompressData? firehoseCompressData;
    }
}

