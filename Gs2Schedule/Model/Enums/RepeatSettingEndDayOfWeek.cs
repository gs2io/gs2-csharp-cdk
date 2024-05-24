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


namespace Gs2Cdk.Gs2Schedule.Model.Enums
{
    
    public enum RepeatSettingEndDayOfWeek {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static class RepeatSettingEndDayOfWeekExt
    {
        public static string Str(this RepeatSettingEndDayOfWeek self) {
            switch (self) {
                case RepeatSettingEndDayOfWeek.Sunday:
                    return "sunday";
                case RepeatSettingEndDayOfWeek.Monday:
                    return "monday";
                case RepeatSettingEndDayOfWeek.Tuesday:
                    return "tuesday";
                case RepeatSettingEndDayOfWeek.Wednesday:
                    return "wednesday";
                case RepeatSettingEndDayOfWeek.Thursday:
                    return "thursday";
                case RepeatSettingEndDayOfWeek.Friday:
                    return "friday";
                case RepeatSettingEndDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }

        public static RepeatSettingEndDayOfWeek New(string value) {
            switch (value) {
                case "sunday":
                    return RepeatSettingEndDayOfWeek.Sunday;
                case "monday":
                    return RepeatSettingEndDayOfWeek.Monday;
                case "tuesday":
                    return RepeatSettingEndDayOfWeek.Tuesday;
                case "wednesday":
                    return RepeatSettingEndDayOfWeek.Wednesday;
                case "thursday":
                    return RepeatSettingEndDayOfWeek.Thursday;
                case "friday":
                    return RepeatSettingEndDayOfWeek.Friday;
                case "saturday":
                    return RepeatSettingEndDayOfWeek.Saturday;
            }
            return RepeatSettingEndDayOfWeek.Sunday;
        }
    }
}
