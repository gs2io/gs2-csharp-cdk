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


namespace Gs2Cdk.Gs2Enchant.Model.Enums
{
    
    public enum BalanceParameterModelInitialValueStrategy {
        Average,
        Lottery
    }

    public static class BalanceParameterModelInitialValueStrategyExt
    {
        public static string Str(this BalanceParameterModelInitialValueStrategy self) {
            switch (self) {
                case BalanceParameterModelInitialValueStrategy.Average:
                    return "average";
                case BalanceParameterModelInitialValueStrategy.Lottery:
                    return "lottery";
            }
            return "unknown";
        }

        public static BalanceParameterModelInitialValueStrategy New(string value) {
            switch (value) {
                case "average":
                    return BalanceParameterModelInitialValueStrategy.Average;
                case "lottery":
                    return BalanceParameterModelInitialValueStrategy.Lottery;
            }
            return BalanceParameterModelInitialValueStrategy.Average;
        }
    }
}
