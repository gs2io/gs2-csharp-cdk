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


namespace Gs2Cdk.Gs2Limit.Model.Enums
{
    
    public enum LimitModelResetDayOfWeek {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static class LimitModelResetDayOfWeekExt
    {
        public static string Str(this LimitModelResetDayOfWeek self) {
            switch (self) {
                case LimitModelResetDayOfWeek.Sunday:
                    return "sunday";
                case LimitModelResetDayOfWeek.Monday:
                    return "monday";
                case LimitModelResetDayOfWeek.Tuesday:
                    return "tuesday";
                case LimitModelResetDayOfWeek.Wednesday:
                    return "wednesday";
                case LimitModelResetDayOfWeek.Thursday:
                    return "thursday";
                case LimitModelResetDayOfWeek.Friday:
                    return "friday";
                case LimitModelResetDayOfWeek.Saturday:
                    return "saturday";
            }
            return "unknown";
        }
    }
}
