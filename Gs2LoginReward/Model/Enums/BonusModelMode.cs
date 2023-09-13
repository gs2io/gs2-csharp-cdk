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
    
    public enum BonusModelMode {
        Schedule,
        Streaming
    }

    public static class BonusModelModeExt
    {
        public static string Str(this BonusModelMode self) {
            switch (self) {
                case BonusModelMode.Schedule:
                    return "schedule";
                case BonusModelMode.Streaming:
                    return "streaming";
            }
            return "unknown";
        }

        public static BonusModelMode New(string value) {
            switch (value) {
                case "schedule":
                    return BonusModelMode.Schedule;
                case "streaming":
                    return BonusModelMode.Streaming;
            }
            return BonusModelMode.Schedule;
        }
    }
}
