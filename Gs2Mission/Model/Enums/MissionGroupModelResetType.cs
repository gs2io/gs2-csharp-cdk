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
    
    public enum MissionGroupModelResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly,
        Days
    }

    public static class MissionGroupModelResetTypeExt
    {
        public static string Str(this MissionGroupModelResetType self) {
            switch (self) {
                case MissionGroupModelResetType.NotReset:
                    return "notReset";
                case MissionGroupModelResetType.Daily:
                    return "daily";
                case MissionGroupModelResetType.Weekly:
                    return "weekly";
                case MissionGroupModelResetType.Monthly:
                    return "monthly";
                case MissionGroupModelResetType.Days:
                    return "days";
            }
            return "unknown";
        }

        public static MissionGroupModelResetType New(string value) {
            switch (value) {
                case "notReset":
                    return MissionGroupModelResetType.NotReset;
                case "daily":
                    return MissionGroupModelResetType.Daily;
                case "weekly":
                    return MissionGroupModelResetType.Weekly;
                case "monthly":
                    return MissionGroupModelResetType.Monthly;
                case "days":
                    return MissionGroupModelResetType.Days;
            }
            return MissionGroupModelResetType.NotReset;
        }
    }
}
