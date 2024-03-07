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


namespace Gs2Cdk.Gs2Matchmaking.Model.Enums
{
    
    public enum NamespaceEnableCollaborateSeasonRating {
        Enable,
        Disable
    }

    public static class NamespaceEnableCollaborateSeasonRatingExt
    {
        public static string Str(this NamespaceEnableCollaborateSeasonRating self) {
            switch (self) {
                case NamespaceEnableCollaborateSeasonRating.Enable:
                    return "enable";
                case NamespaceEnableCollaborateSeasonRating.Disable:
                    return "disable";
            }
            return "unknown";
        }

        public static NamespaceEnableCollaborateSeasonRating New(string value) {
            switch (value) {
                case "enable":
                    return NamespaceEnableCollaborateSeasonRating.Enable;
                case "disable":
                    return NamespaceEnableCollaborateSeasonRating.Disable;
            }
            return NamespaceEnableCollaborateSeasonRating.Enable;
        }
    }
}
