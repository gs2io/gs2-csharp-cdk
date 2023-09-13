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
    
    public enum CounterScopeModelResetType {
        NotReset,
        Daily,
        Weekly,
        Monthly
    }

    public static class CounterScopeModelResetTypeExt
    {
        public static string Str(this CounterScopeModelResetType self) {
            switch (self) {
                case CounterScopeModelResetType.NotReset:
                    return "notReset";
                case CounterScopeModelResetType.Daily:
                    return "daily";
                case CounterScopeModelResetType.Weekly:
                    return "weekly";
                case CounterScopeModelResetType.Monthly:
                    return "monthly";
            }
            return "unknown";
        }

        public static CounterScopeModelResetType New(string value) {
            switch (value) {
                case "notReset":
                    return CounterScopeModelResetType.NotReset;
                case "daily":
                    return CounterScopeModelResetType.Daily;
                case "weekly":
                    return CounterScopeModelResetType.Weekly;
                case "monthly":
                    return CounterScopeModelResetType.Monthly;
            }
            return CounterScopeModelResetType.NotReset;
        }
    }
}
