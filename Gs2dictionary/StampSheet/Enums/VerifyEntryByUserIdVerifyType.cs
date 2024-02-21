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


namespace Gs2Cdk.Gs2Dictionary.StampSheet.Enums
{
    
    public enum VerifyEntryByUserIdVerifyType {
        Havent,
        Have
    }

    public static class VerifyEntryByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyEntryByUserIdVerifyType self) {
            switch (self) {
                case VerifyEntryByUserIdVerifyType.Havent:
                    return "havent";
                case VerifyEntryByUserIdVerifyType.Have:
                    return "have";
            }
            return "unknown";
        }

        public static VerifyEntryByUserIdVerifyType New(string value) {
            switch (value) {
                case "havent":
                    return VerifyEntryByUserIdVerifyType.Havent;
                case "have":
                    return VerifyEntryByUserIdVerifyType.Have;
            }
            return VerifyEntryByUserIdVerifyType.Havent;
        }
    }
}
