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
    
    public enum EventRepeatEndDayOfWeek {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static class EventRepeatEndDayOfWeekExt
    {
        public static string Str(this EventRepeatEndDayOfWeek self) {
            switch (self) {
                case EventRepeatEndDayOfWeek.Sunday:
                    return "sunday";
                case EventRepeatEndDayOfWeek.Monday:
                    return "monday";
                case EventRepeatEndDayOfWeek.Tuesday:
                    return "tuesday";
                case EventRepeatEndDayOfWeek.Wednesday:
                    return "wednesday";
                case EventRepeatEndDayOfWeek.Thursday:
                    return "thursday";
                case EventRepeatEndDayOfWeek.Friday:
                    return "friday";
                case EventRepeatEndDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }
}
