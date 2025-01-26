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


namespace Gs2Cdk.Gs2Mission.Model.Enums
{
    
    public enum MissionTaskModelTargetResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly,
        Days
    }

    public static class MissionTaskModelTargetResetTypeExt
    {
        public static string Str(this MissionTaskModelTargetResetType self) {
            switch (self) {
                case MissionTaskModelTargetResetType.NotReset:
                    return "notReset";
                case MissionTaskModelTargetResetType.Daily:
                    return "daily";
                case MissionTaskModelTargetResetType.Weekly:
                    return "weekly";
                case MissionTaskModelTargetResetType.Monthly:
                    return "monthly";
                case MissionTaskModelTargetResetType.Days:
                    return "days";
            }
            return "unknown";
        }

        public static MissionTaskModelTargetResetType New(string value) {
            switch (value) {
                case "notReset":
                    return MissionTaskModelTargetResetType.NotReset;
                case "daily":
                    return MissionTaskModelTargetResetType.Daily;
                case "weekly":
                    return MissionTaskModelTargetResetType.Weekly;
                case "monthly":
                    return MissionTaskModelTargetResetType.Monthly;
                case "days":
                    return MissionTaskModelTargetResetType.Days;
            }
            return MissionTaskModelTargetResetType.NotReset;
        }
    }
}
