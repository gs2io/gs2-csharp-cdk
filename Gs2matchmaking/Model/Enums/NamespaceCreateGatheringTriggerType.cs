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
    
    public enum NamespaceCreateGatheringTriggerType {
        None,
        Gs2Realtime,
        Gs2Script
    }

    public static class NamespaceCreateGatheringTriggerTypeExt
    {
        public static string Str(this NamespaceCreateGatheringTriggerType self) {
            switch (self) {
                case NamespaceCreateGatheringTriggerType.None:
                    return "none";
                case NamespaceCreateGatheringTriggerType.Gs2Realtime:
                    return "gs2_realtime";
                case NamespaceCreateGatheringTriggerType.Gs2Script:
                    return "gs2_script";
            }
            return "unknown";
        }

        public static NamespaceCreateGatheringTriggerType New(string value) {
            switch (value) {
                case "none":
                    return NamespaceCreateGatheringTriggerType.None;
                case "gs2_realtime":
                    return NamespaceCreateGatheringTriggerType.Gs2Realtime;
                case "gs2_script":
                    return NamespaceCreateGatheringTriggerType.Gs2Script;
            }
            return NamespaceCreateGatheringTriggerType.None;
        }
    }
}
