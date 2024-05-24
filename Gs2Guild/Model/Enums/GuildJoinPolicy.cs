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


namespace Gs2Cdk.Gs2Guild.Model.Enums
{
    
    public enum GuildJoinPolicy {
        Anybody,
        Approval
    }

    public static class GuildJoinPolicyExt
    {
        public static string Str(this GuildJoinPolicy self) {
            switch (self) {
                case GuildJoinPolicy.Anybody:
                    return "anybody";
                case GuildJoinPolicy.Approval:
                    return "approval";
            }
            return "unknown";
        }

        public static GuildJoinPolicy New(string value) {
            switch (value) {
                case "anybody":
                    return GuildJoinPolicy.Anybody;
                case "approval":
                    return GuildJoinPolicy.Approval;
            }
            return GuildJoinPolicy.Anybody;
        }
    }
}
