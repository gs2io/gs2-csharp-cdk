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
using Gs2Cdk.Gs2Version.Model;
using Gs2Cdk.Gs2Version.Model.Enums;

namespace Gs2Cdk.Gs2Version.Model.Options
{
    public class VersionModelOptions {
        public string metadata;
        public Version_ currentVersion;
        public Version_ warningVersion;
        public Version_ errorVersion;
        public ScheduleVersion[] scheduleVersions;
        public bool? needSignature;
        public string needSignatureString;
        public string signatureKeyId;
        public VersionModelApproveRequirement? approveRequirement;
    }
}
