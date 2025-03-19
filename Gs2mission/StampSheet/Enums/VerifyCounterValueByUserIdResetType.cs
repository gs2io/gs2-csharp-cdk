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


namespace Gs2Cdk.Gs2Mission.StampSheet.Enums
{
    
    public enum VerifyCounterValueByUserIdResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly,
        Days
    }

    public static class VerifyCounterValueByUserIdResetTypeExt
    {
        public static string Str(this VerifyCounterValueByUserIdResetType self) {
            switch (self) {
                case VerifyCounterValueByUserIdResetType.NotReset:
                    return "notReset";
                case VerifyCounterValueByUserIdResetType.Daily:
                    return "daily";
                case VerifyCounterValueByUserIdResetType.Weekly:
                    return "weekly";
                case VerifyCounterValueByUserIdResetType.Monthly:
                    return "monthly";
                case VerifyCounterValueByUserIdResetType.Days:
                    return "days";
            }
            return "unknown";
        }

        public static VerifyCounterValueByUserIdResetType New(string value) {
            switch (value) {
                case "notReset":
                    return VerifyCounterValueByUserIdResetType.NotReset;
                case "daily":
                    return VerifyCounterValueByUserIdResetType.Daily;
                case "weekly":
                    return VerifyCounterValueByUserIdResetType.Weekly;
                case "monthly":
                    return VerifyCounterValueByUserIdResetType.Monthly;
                case "days":
                    return VerifyCounterValueByUserIdResetType.Days;
            }
            return VerifyCounterValueByUserIdResetType.NotReset;
        }
    }
}
