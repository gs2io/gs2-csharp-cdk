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


namespace Gs2Cdk.Gs2Grade.StampSheet.Enums
{
    
    public enum VerifyGradeByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyGradeByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyGradeByUserIdVerifyType self) {
            switch (self) {
                case VerifyGradeByUserIdVerifyType.Less:
                    return "less";
                case VerifyGradeByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyGradeByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyGradeByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyGradeByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyGradeByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyGradeByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyGradeByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyGradeByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyGradeByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyGradeByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyGradeByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyGradeByUserIdVerifyType.NotEqual;
            }
            return VerifyGradeByUserIdVerifyType.Less;
        }
    }
}
