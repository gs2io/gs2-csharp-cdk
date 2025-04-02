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
    
    public enum NamespaceCompleteMatchmakingTriggerType {
        None,
        Gs2Realtime,
        Gs2Script
    }

    public static class NamespaceCompleteMatchmakingTriggerTypeExt
    {
        public static string Str(this NamespaceCompleteMatchmakingTriggerType self) {
            switch (self) {
                case NamespaceCompleteMatchmakingTriggerType.None:
                    return "none";
                case NamespaceCompleteMatchmakingTriggerType.Gs2Realtime:
                    return "gs2_realtime";
                case NamespaceCompleteMatchmakingTriggerType.Gs2Script:
                    return "gs2_script";
            }
            return "unknown";
        }

        public static NamespaceCompleteMatchmakingTriggerType New(string value) {
            switch (value) {
                case "none":
                    return NamespaceCompleteMatchmakingTriggerType.None;
                case "gs2_realtime":
                    return NamespaceCompleteMatchmakingTriggerType.Gs2Realtime;
                case "gs2_script":
                    return NamespaceCompleteMatchmakingTriggerType.Gs2Script;
            }
            return NamespaceCompleteMatchmakingTriggerType.None;
        }
    }
}
