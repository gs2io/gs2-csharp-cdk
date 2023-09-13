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


namespace Gs2Cdk.Gs2LoginReward.Model.Enums
{
    
    public enum BonusModelMissedReceiveRelief {
        Enabled,
        Disabled
    }

    public static class BonusModelMissedReceiveReliefExt
    {
        public static string Str(this BonusModelMissedReceiveRelief self) {
            switch (self) {
                case BonusModelMissedReceiveRelief.Enabled:
                    return "enabled";
                case BonusModelMissedReceiveRelief.Disabled:
                    return "disabled";
            }
            return "unknown";
        }

        public static BonusModelMissedReceiveRelief New(string value) {
            switch (value) {
                case "enabled":
                    return BonusModelMissedReceiveRelief.Enabled;
                case "disabled":
                    return BonusModelMissedReceiveRelief.Disabled;
            }
            return BonusModelMissedReceiveRelief.Enabled;
        }
    }
}
