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


namespace Gs2Cdk.Gs2Version.Model.Enums
{
    
    public enum VersionModelApproveRequirement {
        Required,
        Optional
    }

    public static class VersionModelApproveRequirementExt
    {
        public static string Str(this VersionModelApproveRequirement self) {
            switch (self) {
                case VersionModelApproveRequirement.Required:
                    return "required";
                case VersionModelApproveRequirement.Optional:
                    return "optional";
            }
            return "unknown";
        }

        public static VersionModelApproveRequirement New(string value) {
            switch (value) {
                case "required":
                    return VersionModelApproveRequirement.Required;
                case "optional":
                    return VersionModelApproveRequirement.Optional;
            }
            return VersionModelApproveRequirement.Required;
        }
    }
}
