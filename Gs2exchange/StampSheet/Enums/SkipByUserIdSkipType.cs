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


namespace Gs2Cdk.Gs2Exchange.StampSheet.Enums
{
    
    public enum SkipByUserIdSkipType {
        Complete,
        Minutes,
        TotalRate,
        RemainRate
    }

    public static class SkipByUserIdSkipTypeExt
    {
        public static string Str(this SkipByUserIdSkipType self) {
            switch (self) {
                case SkipByUserIdSkipType.Complete:
                    return "complete";
                case SkipByUserIdSkipType.Minutes:
                    return "minutes";
                case SkipByUserIdSkipType.TotalRate:
                    return "totalRate";
                case SkipByUserIdSkipType.RemainRate:
                    return "remainRate";
            }
            return "unknown";
        }

        public static SkipByUserIdSkipType New(string value) {
            switch (value) {
                case "complete":
                    return SkipByUserIdSkipType.Complete;
                case "minutes":
                    return SkipByUserIdSkipType.Minutes;
                case "totalRate":
                    return SkipByUserIdSkipType.TotalRate;
                case "remainRate":
                    return SkipByUserIdSkipType.RemainRate;
            }
            return SkipByUserIdSkipType.Complete;
        }
    }
}
