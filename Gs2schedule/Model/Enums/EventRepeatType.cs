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
    
    public enum EventRepeatType {
        Always,
        Daily,
        Weekly,
        Monthly
    }

    public static class EventRepeatTypeExt
    {
        public static string Str(this EventRepeatType self) {
            switch (self) {
                case EventRepeatType.Always:
                    return "always";
                case EventRepeatType.Daily:
                    return "daily";
                case EventRepeatType.Weekly:
                    return "weekly";
                case EventRepeatType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }

        public static EventRepeatType New(string value) {
            switch (value) {
                case "always":
                    return EventRepeatType.Always;
                case "daily":
                    return EventRepeatType.Daily;
                case "weekly":
                    return EventRepeatType.Weekly;
                case "monthly":
                    return EventRepeatType.Monthly;
            }
            return EventRepeatType.Always;
        }
    }
}
