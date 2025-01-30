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
    
    public enum LimitModelResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly,
        Days
    }

    public static class LimitModelResetTypeExt
    {
        public static string Str(this LimitModelResetType self) {
            switch (self) {
                case LimitModelResetType.NotReset:
                    return "notReset";
                case LimitModelResetType.Daily:
                    return "daily";
                case LimitModelResetType.Weekly:
                    return "weekly";
                case LimitModelResetType.Monthly:
                    return "monthly";
                case LimitModelResetType.Days:
                    return "days";
            }
            return "unknown";
        }

        public static LimitModelResetType New(string value) {
            switch (value) {
                case "notReset":
                    return LimitModelResetType.NotReset;
                case "daily":
                    return LimitModelResetType.Daily;
                case "weekly":
                    return LimitModelResetType.Weekly;
                case "monthly":
                    return LimitModelResetType.Monthly;
                case "days":
                    return LimitModelResetType.Days;
            }
            return LimitModelResetType.NotReset;
        }
    }
}
