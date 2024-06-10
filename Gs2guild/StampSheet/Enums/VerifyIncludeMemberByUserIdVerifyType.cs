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


namespace Gs2Cdk.Gs2Guild.StampSheet.Enums
{
    
    public enum VerifyIncludeMemberByUserIdVerifyType {
        Include,
        NotInclude
    }

    public static class VerifyIncludeMemberByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyIncludeMemberByUserIdVerifyType self) {
            switch (self) {
                case VerifyIncludeMemberByUserIdVerifyType.Include:
                    return "include";
                case VerifyIncludeMemberByUserIdVerifyType.NotInclude:
                    return "notInclude";
            }
            return "unknown";
        }

        public static VerifyIncludeMemberByUserIdVerifyType New(string value) {
            switch (value) {
                case "include":
                    return VerifyIncludeMemberByUserIdVerifyType.Include;
                case "notInclude":
                    return VerifyIncludeMemberByUserIdVerifyType.NotInclude;
            }
            return VerifyIncludeMemberByUserIdVerifyType.Include;
        }
    }
}
