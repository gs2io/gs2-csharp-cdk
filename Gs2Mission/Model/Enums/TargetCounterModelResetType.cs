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
    
    public enum TargetCounterModelResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly
    }

    public static class TargetCounterModelResetTypeExt
    {
        public static string Str(this TargetCounterModelResetType self) {
            switch (self) {
                case TargetCounterModelResetType.NotReset:
                    return "notReset";
                case TargetCounterModelResetType.Daily:
                    return "daily";
                case TargetCounterModelResetType.Weekly:
                    return "weekly";
                case TargetCounterModelResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }

        public static TargetCounterModelResetType New(string value) {
            switch (value) {
                case "notReset":
                    return TargetCounterModelResetType.NotReset;
                case "daily":
                    return TargetCounterModelResetType.Daily;
                case "weekly":
                    return TargetCounterModelResetType.Weekly;
                case "monthly":
                    return TargetCounterModelResetType.Monthly;
            }
            return TargetCounterModelResetType.NotReset;
        }
    }
}
