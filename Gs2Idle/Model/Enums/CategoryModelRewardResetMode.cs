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


namespace Gs2Cdk.Gs2Idle.Model.Enums
{
    
    public enum CategoryModelRewardResetMode {
        Reset,
        CarryOver
    }

    public static class CategoryModelRewardResetModeExt
    {
        public static string Str(this CategoryModelRewardResetMode self) {
            switch (self) {
                case CategoryModelRewardResetMode.Reset:
                    return "Reset";
                case CategoryModelRewardResetMode.CarryOver:
                    return "CarryOver";
            }
            return "unknown";
        }

        public static CategoryModelRewardResetMode New(string value) {
            switch (value) {
                case "Reset":
                    return CategoryModelRewardResetMode.Reset;
                case "CarryOver":
                    return CategoryModelRewardResetMode.CarryOver;
            }
            return CategoryModelRewardResetMode.Reset;
        }
    }
}
