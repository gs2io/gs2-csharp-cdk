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
    
    public enum RepeatSettingRepeatType {
        Always,
        Daily,
        Weekly,
        Monthly,
        Custom
    }

    public static class RepeatSettingRepeatTypeExt
    {
        public static string Str(this RepeatSettingRepeatType self) {
            switch (self) {
                case RepeatSettingRepeatType.Always:
                    return "always";
                case RepeatSettingRepeatType.Daily:
                    return "daily";
                case RepeatSettingRepeatType.Weekly:
                    return "weekly";
                case RepeatSettingRepeatType.Monthly:
                    return "monthly";
                case RepeatSettingRepeatType.Custom:
                    return "custom";
            }
            return "unknown";
        }

        public static RepeatSettingRepeatType New(string value) {
            switch (value) {
                case "always":
                    return RepeatSettingRepeatType.Always;
                case "daily":
                    return RepeatSettingRepeatType.Daily;
                case "weekly":
                    return RepeatSettingRepeatType.Weekly;
                case "monthly":
                    return RepeatSettingRepeatType.Monthly;
                case "custom":
                    return RepeatSettingRepeatType.Custom;
            }
            return RepeatSettingRepeatType.Always;
        }
    }
}
