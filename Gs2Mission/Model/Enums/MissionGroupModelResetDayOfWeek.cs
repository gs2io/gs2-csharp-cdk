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
    
    public enum MissionGroupModelResetDayOfWeek {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static class MissionGroupModelResetDayOfWeekExt
    {
        public static string Str(this MissionGroupModelResetDayOfWeek self) {
            switch (self) {
                case MissionGroupModelResetDayOfWeek.Sunday:
                    return "sunday";
                case MissionGroupModelResetDayOfWeek.Monday:
                    return "monday";
                case MissionGroupModelResetDayOfWeek.Tuesday:
                    return "tuesday";
                case MissionGroupModelResetDayOfWeek.Wednesday:
                    return "wednesday";
                case MissionGroupModelResetDayOfWeek.Thursday:
                    return "thursday";
                case MissionGroupModelResetDayOfWeek.Friday:
                    return "friday";
                case MissionGroupModelResetDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }
}
