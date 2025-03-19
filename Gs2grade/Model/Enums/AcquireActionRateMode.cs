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


namespace Gs2Cdk.Gs2Grade.Model.Enums
{
    
    public enum AcquireActionRateMode {
        Double,
        Big
    }

    public static class AcquireActionRateModeExt
    {
        public static string Str(this AcquireActionRateMode self) {
            switch (self) {
                case AcquireActionRateMode.Double:
                    return "double";
                case AcquireActionRateMode.Big:
                    return "big";
            }
            return "unknown";
        }

        public static AcquireActionRateMode New(string value) {
            switch (value) {
                case "double":
                    return AcquireActionRateMode.Double;
                case "big":
                    return AcquireActionRateMode.Big;
            }
            return AcquireActionRateMode.Double;
        }
    }
}
