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
    
    public enum ScopedValueResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly
    }

    public static class ScopedValueResetTypeExt
    {
        public static string Str(this ScopedValueResetType self) {
            switch (self) {
                case ScopedValueResetType.NotReset:
                    return "notReset";
                case ScopedValueResetType.Daily:
                    return "daily";
                case ScopedValueResetType.Weekly:
                    return "weekly";
                case ScopedValueResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }

        public static ScopedValueResetType New(string value) {
            switch (value) {
                case "notReset":
                    return ScopedValueResetType.NotReset;
                case "daily":
                    return ScopedValueResetType.Daily;
                case "weekly":
                    return ScopedValueResetType.Weekly;
                case "monthly":
                    return ScopedValueResetType.Monthly;
            }
            return ScopedValueResetType.NotReset;
        }
    }
}
