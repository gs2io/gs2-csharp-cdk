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


namespace Gs2Cdk.Gs2Enchant.StampSheet.Enums
{
    
    public enum RarityParameterStatusVerifyType {
        Havent,
        Have,
        Count
    }

    public static class RarityParameterStatusVerifyTypeExt
    {
        public static string Str(this RarityParameterStatusVerifyType self) {
            switch (self) {
                case RarityParameterStatusVerifyType.Havent:
                    return "havent";
                case RarityParameterStatusVerifyType.Have:
                    return "have";
                case RarityParameterStatusVerifyType.Count:
                    return "count";
            }
            return "unknown";
        }

        public static RarityParameterStatusVerifyType New(string value) {
            switch (value) {
                case "havent":
                    return RarityParameterStatusVerifyType.Havent;
                case "have":
                    return RarityParameterStatusVerifyType.Have;
                case "count":
                    return RarityParameterStatusVerifyType.Count;
            }
            return RarityParameterStatusVerifyType.Havent;
        }
    }
}
