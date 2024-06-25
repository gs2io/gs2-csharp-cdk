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


namespace Gs2Cdk.Gs2Money2.Model.Enums
{
    
    public enum NamespaceCurrencyUsagePriority {
        PrioritizeFree,
        PrioritizePaid
    }

    public static class NamespaceCurrencyUsagePriorityExt
    {
        public static string Str(this NamespaceCurrencyUsagePriority self) {
            switch (self) {
                case NamespaceCurrencyUsagePriority.PrioritizeFree:
                    return "PrioritizeFree";
                case NamespaceCurrencyUsagePriority.PrioritizePaid:
                    return "PrioritizePaid";
            }
            return "unknown";
        }

        public static NamespaceCurrencyUsagePriority New(string value) {
            switch (value) {
                case "PrioritizeFree":
                    return NamespaceCurrencyUsagePriority.PrioritizeFree;
                case "PrioritizePaid":
                    return NamespaceCurrencyUsagePriority.PrioritizePaid;
            }
            return NamespaceCurrencyUsagePriority.PrioritizeFree;
        }
    }
}
