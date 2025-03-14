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
    
    public enum VerifyRarityParameterStatusByUserIdVerifyType {
        Havent,
        Have,
        Count
    }

    public static class VerifyRarityParameterStatusByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyRarityParameterStatusByUserIdVerifyType self) {
            switch (self) {
                case VerifyRarityParameterStatusByUserIdVerifyType.Havent:
                    return "havent";
                case VerifyRarityParameterStatusByUserIdVerifyType.Have:
                    return "have";
                case VerifyRarityParameterStatusByUserIdVerifyType.Count:
                    return "count";
            }
            return "unknown";
        }

        public static VerifyRarityParameterStatusByUserIdVerifyType New(string value) {
            switch (value) {
                case "havent":
                    return VerifyRarityParameterStatusByUserIdVerifyType.Havent;
                case "have":
                    return VerifyRarityParameterStatusByUserIdVerifyType.Have;
                case "count":
                    return VerifyRarityParameterStatusByUserIdVerifyType.Count;
            }
            return VerifyRarityParameterStatusByUserIdVerifyType.Havent;
        }
    }
}
