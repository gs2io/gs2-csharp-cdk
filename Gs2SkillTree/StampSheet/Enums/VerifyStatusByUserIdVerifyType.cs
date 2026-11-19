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


namespace Gs2Cdk.Gs2SkillTree.StampSheet.Enums
{
    
    public enum VerifyStatusByUserIdVerifyType {
        Released,
        NotReleased
    }

    public static class VerifyStatusByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyStatusByUserIdVerifyType self) {
            switch (self) {
                case VerifyStatusByUserIdVerifyType.Released:
                    return "released";
                case VerifyStatusByUserIdVerifyType.NotReleased:
                    return "notReleased";
            }
            return "unknown";
        }

        public static VerifyStatusByUserIdVerifyType New(string value) {
            switch (value) {
                case "released":
                    return VerifyStatusByUserIdVerifyType.Released;
                case "notReleased":
                    return VerifyStatusByUserIdVerifyType.NotReleased;
            }
            return VerifyStatusByUserIdVerifyType.Released;
        }
    }
}
