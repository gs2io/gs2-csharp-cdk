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
    
    public enum RepeatSettingBeginDayOfWeek {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static class RepeatSettingBeginDayOfWeekExt
    {
        public static string Str(this RepeatSettingBeginDayOfWeek self) {
            switch (self) {
                case RepeatSettingBeginDayOfWeek.Sunday:
                    return "sunday";
                case RepeatSettingBeginDayOfWeek.Monday:
                    return "monday";
                case RepeatSettingBeginDayOfWeek.Tuesday:
                    return "tuesday";
                case RepeatSettingBeginDayOfWeek.Wednesday:
                    return "wednesday";
                case RepeatSettingBeginDayOfWeek.Thursday:
                    return "thursday";
                case RepeatSettingBeginDayOfWeek.Friday:
                    return "friday";
                case RepeatSettingBeginDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }

        public static RepeatSettingBeginDayOfWeek New(string value) {
            switch (value) {
                case "sunday":
                    return RepeatSettingBeginDayOfWeek.Sunday;
                case "monday":
                    return RepeatSettingBeginDayOfWeek.Monday;
                case "tuesday":
                    return RepeatSettingBeginDayOfWeek.Tuesday;
                case "wednesday":
                    return RepeatSettingBeginDayOfWeek.Wednesday;
                case "thursday":
                    return RepeatSettingBeginDayOfWeek.Thursday;
                case "friday":
                    return RepeatSettingBeginDayOfWeek.Friday;
                case "saturday":
                    return RepeatSettingBeginDayOfWeek.Saturday;
            }
            return RepeatSettingBeginDayOfWeek.Sunday;
        }
    }
}
