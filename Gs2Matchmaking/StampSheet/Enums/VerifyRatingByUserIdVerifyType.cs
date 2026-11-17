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


namespace Gs2Cdk.Gs2Matchmaking.StampSheet.Enums
{
    
    public enum VerifyRatingByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyRatingByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyRatingByUserIdVerifyType self) {
            switch (self) {
                case VerifyRatingByUserIdVerifyType.Less:
                    return "less";
                case VerifyRatingByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyRatingByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyRatingByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyRatingByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyRatingByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyRatingByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyRatingByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyRatingByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyRatingByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyRatingByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyRatingByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyRatingByUserIdVerifyType.NotEqual;
            }
            return VerifyRatingByUserIdVerifyType.Less;
        }
    }
}
