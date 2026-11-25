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


namespace Gs2Cdk.Gs2Friend.StampSheet.Enums
{
    
    public enum VerifyFriendCountByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyFriendCountByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyFriendCountByUserIdVerifyType self) {
            switch (self) {
                case VerifyFriendCountByUserIdVerifyType.Less:
                    return "less";
                case VerifyFriendCountByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyFriendCountByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyFriendCountByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyFriendCountByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyFriendCountByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyFriendCountByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyFriendCountByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyFriendCountByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyFriendCountByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyFriendCountByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyFriendCountByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyFriendCountByUserIdVerifyType.NotEqual;
            }
            return VerifyFriendCountByUserIdVerifyType.Less;
        }
    }
}
